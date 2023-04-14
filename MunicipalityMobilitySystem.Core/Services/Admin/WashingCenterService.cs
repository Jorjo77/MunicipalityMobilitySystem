using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;
using static MunicipalityMobilitySystem.Data.DataConstants;
using RepairCenter = MunicipalityMobilitySystem.Infrasructure.Data.Entities.RepairCenter;
using Vehicle = MunicipalityMobilitySystem.Infrasructure.Data.Entities.Vehicle;
using WashingCenter = MunicipalityMobilitySystem.Infrasructure.Data.Entities.WashingCenter;

namespace MunicipalityMobility.Core.Services.Admin
{
    public class WashingCenterService : IWashingCenterService
    {
        private readonly IRepository repo;
        private readonly ILogger logger;

        public WashingCenterService(IRepository _repo,
            ILogger<WashingCenterService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }
        public async Task<IEnumerable<WashingCenterServiceModel>> GetWashingCenters()
        {
            return await repo.AllReadonly<WashingCenter>()
                .Select(rc => new WashingCenterServiceModel
                {
                    Id = rc.Id,
                    Name = rc.Name,
                    ImageUrl = rc.ImageUrl,
                    Adress = rc.VehiclePark.Adress,
                })
                .ToListAsync();
        }

        public async Task Create(WashingCenterDetailsServiceModel model)
        {
            var washingCenter = new WashingCenter
            {
                Id = model.Id,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                VehicleParkId = model.VehicleParkId,
            };//When create RepairCenter I do not add property Vehicles (like when I create Vehicle park)

            try
            {
                await repo.AddAsync(washingCenter);
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
            var washingCenter = await repo.GetByIdAsync<WashingCenter>(id);
            repo.Delete(washingCenter);

            await repo.SaveChangesAsync();
        }

        public async Task<WashingCenterServiceModel> GetWashingCenterById(int id)
        {
            return await repo.AllReadonly<WashingCenter>()
                .Where(rc => rc.Id == id)
                .Select(rc => new WashingCenterServiceModel
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
            return repo.AllReadonly<WashingCenter>()
                .Where(rc => rc.Id == id)
                .AnyAsync();
        }

        public async Task<IEnumerable<VehicleDetailsViewModel>> GetVehiclesForWashing(int washingCenterId)
        {
            return await repo.All<Vehicle>()
                .Where(v => v.ForCleaning == true 
                && v.VehicleParkId == washingCenterId
                && v.IsActive)
                .Select(v => new VehicleDetailsViewModel
                {
                    Id = v.Id,
                    RegistrationNumber= v.RegistrationNumber,
                    Model = v.Model,
                    ImageUrl = v.ImageUrl,
                    VehicleParkId = v.VehicleParkId,
                    CategoryId = v.CategoryId,
                    EngineType = v.EngineType,
                    Description = v.Description,
                    ForCleaning = v.ForCleaning,
                    ForRepearing = v.ForRepearing,
                })
                .ToListAsync();
        }

        public async Task WashVehicle(int id)
        {
            var vehicle = await repo.GetByIdAsync<Vehicle>(id);

            TimeSpan? rentPeriod = vehicle.MomenOfLeave - vehicle.MomenOfRent;

            double rentedPeriod = Math.Ceiling(rentPeriod.GetValueOrDefault().TotalHours);

            vehicle.RentedPeriod += rentedPeriod;

            vehicle.ForCleaning = false;
            vehicle.ForRepearing = false;
            vehicle.MomenOfLeave = null;
            vehicle.MomenOfRent = null;
            vehicle.RenterId = null;
            vehicle.FailureDescription= null;

            await repo.SaveChangesAsync();
        }
    }
}
