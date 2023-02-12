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
            };//When create RepairCenter I do not add property Vehicles (like when I create Vehicle park)

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

        public async Task<IEnumerable<VehicleDetailsViewModel>> GetVehiclesForRepair()
        {
            return await repo.AllReadonly<Vehicle>()
                .Where(v => v.ForRepearing == true)
                .Select(v=> new VehicleDetailsViewModel
                {
                    Id= v.Id,
                    Model = v.Model,
                    ImageUrl= v.ImageUrl,
                    VehicleParkId= v.VehicleParkId,
                    CategoryId= v.CategoryId,
                    EngineType = v.EngineType,
                    Description= v.Description,
                    ForCleaning= v.ForCleaning,
                    ForRepearing= v.ForRepearing,
                })
                .ToListAsync();
        }
    }
}
