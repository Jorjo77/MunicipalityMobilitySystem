using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;
using Expense = MunicipalityMobilitySystem.Infrasructure.Data.Entities.Expense;
using PartsOrder = MunicipalityMobilitySystem.Infrasructure.Data.Entities.PartsOrder;
using RepairCenter = MunicipalityMobilitySystem.Infrasructure.Data.Entities.RepairCenter;
using Vehicle = MunicipalityMobilitySystem.Infrasructure.Data.Entities.Vehicle;

namespace MunicipalityMobility.Core.Services.Admin
{
    public class RepairCenterService : IRepairCenterService
    {
        private readonly IRepository repo;
        private readonly ILogger logger;

        public RepairCenterService(IRepository _repo,
            ILogger<RepairCenterService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }
        public async Task<IEnumerable<RepairCenterServiceModel>> GetRepairCenters()
        {
            return await repo.AllReadonly<RepairCenter>()
                .Select(rc => new RepairCenterServiceModel
                {
                    Id = rc.Id,
                    Name = rc.Name,
                    ImageUrl = rc.ImageUrl,
                    Adress = rc.VehiclePark.Adress,
                })
                .ToListAsync();
        }
        public async Task Create(RepairCenterDetailsServiceModel model)
        {
            var repairCenter = new RepairCenter
            {
                Id = model.Id,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                VehicleParkId = model.VehicleParkId,
            };

            try
            {
                await repo.AddAsync(repairCenter);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
        }
        public async Task Delete(int id)
        {
            var repairCenter = await repo.GetByIdAsync<RepairCenter>(id);

            await repo.DeleteAsync<RepairCenter>(repairCenter);

            await repo.SaveChangesAsync();
        }
        public async Task<RepairCenterServiceModel> GetRepairCenterById(int id)
        {
            return await repo.AllReadonly<RepairCenter>()
                .Where(rc => rc.Id == id)
                .Select(rc => new RepairCenterServiceModel
                {
                    Id = rc.Id,
                    Name = rc.Name,
                    ImageUrl = rc.ImageUrl,
                    Adress = rc.VehiclePark.Adress
                })
                .FirstAsync();
        }
        public Task<bool> Exists(int id)
        {
            return repo.AllReadonly<RepairCenter>()
                .Where(rc => rc.Id == id)
                .AnyAsync();
        }
        public async Task<IEnumerable<VehicleDetailsViewModel>> GetVehiclesForRepair(int repairingCenterId)
        {
            return await repo.All<Vehicle>()
                .Where(v => v.ForRepearing == true
                && v.VehicleParkId == repairingCenterId
                && v.IsActive)
                .Select(v => new VehicleDetailsViewModel
                {
                    Id = v.Id,
                    Model = v.Model,
                    ImageUrl = v.ImageUrl,
                    VehicleParkId = v.VehicleParkId,
                    CategoryId = v.CategoryId,
                    EngineType = v.EngineType,
                    Description = v.Description,
                    ForCleaning = v.ForCleaning,
                    ForRepearing = v.ForRepearing,
                    RegistrationNumber = v.RegistrationNumber,
                    FailureDescription = v.FailureDescription,
                })
                .ToListAsync();
        }
        public async Task RepairVehicle(int id)
        {

            var vehicle = await repo.GetByIdAsync<Vehicle>(id);
            vehicle.ForCleaning = true;
            vehicle.ForRepearing = false;
            vehicle.MomenOfLeave = null;
            vehicle.MomenOfRent = null;
            vehicle.RenterId = null;
            vehicle.FailureDescription = null;

            await repo.SaveChangesAsync();
        }
        public async Task CreateOrder(PartsOrderServiceModel model)
        {

            var order = new PartsOrder
            {
                Title = model.Title,
                VehicleId = model.VehicleId,
            };

            foreach (var modelExpense in model.Expenses)
            {
                var expense = repo.All<Expense>()
                    .FirstOrDefault(e => e.Name == modelExpense.Name);
                if (expense == null)
                {
                    expense = new Expense
                    {
                        Name = modelExpense.Name,
                        Quantity = modelExpense.Quantity,
                        UnutPrice = modelExpense.UnutPrice, 
                    };
                }

                order.Expenses.Add(expense);
            }
            order.TotalPrice = order.Expenses.Sum(e => e.Quantity * e.UnutPrice);

            try
            {
                await repo.AddAsync<PartsOrder>(order);

                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(CreateOrder), ex);
                throw new ApplicationException("Database faild to save info", ex);
            }

        }
        public async Task<bool> ExistsOrder(PartsOrderServiceModel queryModel)
        {
            return await repo.AllReadonly<PartsOrder>()
                .Where(o => o.Title == queryModel.Title &&
                o.TotalPrice == queryModel.TotalPrice)
                .AnyAsync();
        }
        public async Task<VehicleDetailsViewModel> GetVehicleForRepairById(int vehicleId)
        {
            return await repo.AllReadonly<Vehicle>()
                .Where(v => v.Id == vehicleId
                && v.IsActive)
                .Select(v => new VehicleDetailsViewModel
                {
                    Id = v.Id,
                    Model = v.Model,
                    ImageUrl = v.ImageUrl,
                    VehicleParkId = v.VehicleParkId,
                    CategoryId = v.CategoryId,
                    EngineType = v.EngineType,
                    Description = v.Description,
                    ForCleaning = v.ForCleaning,
                    ForRepearing = v.ForRepearing,
                    RegistrationNumber = v.RegistrationNumber,
                    FailureDescription = v.FailureDescription,
                })
                .FirstAsync();
        }

        public async Task<bool> ExistsOrderById(int id)
        {
            return await repo.AllReadonly<PartsOrder>()
                .Where(o => o.Id == id)
                .AnyAsync();
        }

        public async Task<OrderViewModel> GetOrderById(int id)
        {
            return await repo.AllReadonly<PartsOrder>()
                .Where(o=>o.Id == id)
                .Select(o=> new OrderViewModel
                {
                    Id=o.Id,
                    Title = o.Title,
                    RegistrationNumber = o.Vehicle.RegistrationNumber,
                    TotalPrice = o.TotalPrice,
                })
                .FirstAsync();
        }
        public async Task<ICollection<OrderViewModel>> GetOrders()
        {
            return await repo.AllReadonly<PartsOrder>()
                .OrderBy(or=>or.VehicleId)
                .Select(or => new OrderViewModel 
                {
                    Id = or.Id,
                    Title = or.Title,
                    RegistrationNumber = or.Vehicle.RegistrationNumber,
                    TotalPrice = or.TotalPrice,
                })
                .ToListAsync();
        }
        public async Task DeleteOrder(int id)
        {
            var order = await repo.GetByIdAsync<PartsOrder>(id);

            await repo.DeleteAsync<PartsOrder> (order);
            await repo.SaveChangesAsync();
        }
    }
}
