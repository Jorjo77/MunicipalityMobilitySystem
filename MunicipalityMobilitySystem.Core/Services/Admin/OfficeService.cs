using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;
using static MunicipalityMobilitySystem.Data.DataConstants;
using Bill = MunicipalityMobilitySystem.Infrasructure.Data.Entities.Bill;
using Vehicle = MunicipalityMobilitySystem.Infrasructure.Data.Entities.Vehicle;

namespace MunicipalityMobilitySystem.Core.Services.Admin
{
    public class OfficeService : IOfficeService
    {
        private readonly ILogger logger;
        private readonly IRepository repo;
        private readonly IGuard guard;

        public OfficeService(ILogger<OfficeService> _logger,
            IGuard _guard,
            IRepository _repo)
        {
            logger= _logger;
            guard= _guard;
            repo= _repo;
        }

        public async Task EditLeftVehicleById(VehicleDetailsViewModel model)
        {
            var vehicle = await repo.GetByIdAsync<Vehicle>(model.Id);

            vehicle.FailureDescription= model.FailureDescription;

            await repo.SaveChangesAsync();
        }

        public async Task<VehicleDetailsViewModel> GetLeftVehicleById(int vehicleId)
        {
            var vehicle =  await repo.All<Vehicle>()
                .Where(v=>v.MomenOfLeave != null && v.IsActive)
                .Select( v => new VehicleDetailsViewModel 
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber,
                    Model = v.Model,
                    VehicleParkId = v.VehicleParkId,
                    ForCleaning = v.ForCleaning,
                    ForRepearing = v.ForRepearing,
                    RentedPeriod = v.RentedPeriod,
                    RenterId = v.RenterId,
                    PricePerHour = v.PricePerHour,
                    MomenOfLeave = v.MomenOfLeave,
                    MomenOfRent = v.MomenOfRent,
                    FailureDescription= v.FailureDescription,
                }).FirstOrDefaultAsync();


            guard.AgainstNull(vehicle, "Vehicle can not be found");

            return vehicle;

        }

        public async Task<IEnumerable<VehicleDetailsViewModel>> GetLeftVehicles()
        {
            return await repo.All<Vehicle>()
                .Where(v=>v.MomenOfLeave != null 
                && v. ForCleaning == false
                && v.ForRepearing == false
                && v.IsActive)
                .Select(v=> new VehicleDetailsViewModel
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber,
                    Model = v.Model,
                    VehicleParkId = v.VehicleParkId,
                    ForCleaning = v.ForCleaning,
                    ForRepearing = v.ForRepearing,
                    RentedPeriod= v.RentedPeriod,
                    RenterId= v.RenterId,
                    PricePerHour= v.PricePerHour,
                    MomenOfLeave = v.MomenOfLeave,
                    MomenOfRent = v.MomenOfRent,
                    FailureDescription= v.FailureDescription
                })
                .ToListAsync();
        }

        public async Task<decimal> GetTheBill(int vehicleId)
        {
            var rentedVehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);

            TimeSpan? rentedPeriod = rentedVehicle.MomenOfLeave - rentedVehicle.MomenOfRent;

            decimal theBill = (decimal)rentedPeriod.Value.TotalHours * rentedVehicle.PricePerHour;

            return theBill;
        }

        public async Task<IEnumerable<TheBillViewModel>> GetTheBills()
        {
            return await repo.AllReadonly<Bill>()
                .Select(b => new TheBillViewModel
                {
                    Id= b.Id,
                    Title= b.Title,
                    RegistrationNumber = b.RegistrationNumber,
                    Model = b.Model,
                    MomenOfLeave= b.MomenOfLeave,
                    MomenOfRent= b.MomenOfRent,
                    PricePerHour = b.PricePerHour,
                    RentedPeriod= b.RentedPeriod,
                    RenterId= b.RenterId,
                    VehicleId= b.VehicleId,
                    TotalPrice= b.TotalPrice
                })
                .ToListAsync();
        }

        public async Task MakeAndPostTheBill(VehicleDetailsViewModel vehicle)
        {
            var model = new TheBillViewModel
            {
                RegistrationNumber = vehicle.RegistrationNumber,
                Model = vehicle.Model,
                Title = vehicle.RegistrationNumber,
                //Title = String.Format("The bill for your rented {0}, with Reg. Number: {1}", vehicle.Model, vehicle.RegistrationNumber),
                MomenOfRent = vehicle.MomenOfRent,
                MomenOfLeave = vehicle.MomenOfLeave,
                PricePerHour = vehicle.PricePerHour,
                RentedPeriod = vehicle.RentedPeriod,
                RenterId = vehicle.RenterId,
                VehicleId = vehicle.Id,
                TotalPrice = await GetTheBill(vehicle.Id)
            };

            var theBill = new Bill
            {
                Title = model.Title,
                RegistrationNumber= model.RegistrationNumber,
                Model = model.Model,
                MomenOfRent = model.MomenOfRent,
                MomenOfLeave = model.MomenOfLeave,
                PricePerHour = model.PricePerHour,
                RentedPeriod = model.RentedPeriod,
                RenterId = model.RenterId,
                VehicleId = model.VehicleId,
                TotalPrice = model.TotalPrice
            };

            await repo.AddAsync<Bill>(theBill);

            await repo.SaveChangesAsync();
        }

        public async Task SetVehicleForCleaning(int vehicleId)
        {

            var vehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);

            TimeSpan? rentedPeriod = vehicle.MomenOfLeave - vehicle.MomenOfRent;

            vehicle.ForCleaning = true;

            vehicle.RentedPeriod= rentedPeriod;

            await repo.SaveChangesAsync();
        }

        public async Task SetVehicleForRepairing(int vehicleId)
        {
            var vehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);

            TimeSpan? rentedPeriod = vehicle.MomenOfLeave - vehicle.MomenOfRent;

            vehicle.ForRepearing = true;

            vehicle.RentedPeriod = rentedPeriod;

            vehicle.RepairsCount++;

            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<TheBillViewModel>> AllBillsByUserId(string id)
        {
            return await repo.AllReadonly<Bill>()
                .Where(b => b.RenterId == id)
                .Select(b => new TheBillViewModel
                {
                    Id = b.Id,
                    Title= b.Title,
                    RegistrationNumber = b.RegistrationNumber,
                    VehicleId = b.VehicleId,
                    Model = b.Model,
                    PricePerHour = b.PricePerHour,
                    RenterId = b.RenterId,
                    MomenOfRent= b.MomenOfRent,
                    MomenOfLeave= b.MomenOfLeave,
                    RentedPeriod= b.RentedPeriod,
                    TotalPrice= b.TotalPrice
                })
                .ToListAsync();
        }

        public async Task DeleteBillById(int id)
        {
            var bill = await repo.GetByIdAsync<Bill>(id);

            try
            {
                repo.Delete(bill);

                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(DeleteBillById), ex);
                throw new ApplicationException("Database failed to delete info", ex);
            }
        }
    }
}
