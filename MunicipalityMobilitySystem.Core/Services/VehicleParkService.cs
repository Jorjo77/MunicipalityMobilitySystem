using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.VehiclePark;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;

namespace MunicipalityMobilitySystem.Core.Services
{
    public class VehicleParkService : IVehicleParkService
    {
        private readonly IRepository repo;

        private readonly IGuard guard;

        private readonly ILogger logger;

        public VehicleParkService(IRepository repo,
                                  IGuard guard,
                                  ILogger<VehicleParkService> logger)
        {
            this.repo = repo;
            this.guard = guard;
            this.logger = logger;
        }

        public async Task<IEnumerable<VehicleParkModel>> AllVehicleParks()
        {
            return await repo.AllReadonly<VehiclePark>()
                .OrderBy(vp => vp.Name)
                .Select(vp => new VehicleParkModel
                {
                    Id = vp.Id,
                    Name = vp.Name,
                    Adress = vp.Adress,
                    Email = vp.Email,
                    Phone = vp.Phone,
                    ImageUrl = vp.ImageUrl
                }).ToListAsync();
        }

        public async Task<VehicleParkDetailsModel> DetailsById(int Id)
        {
            return await repo.AllReadonly<VehiclePark>()
                .Where(vp => vp.Id == Id)
                .Select(vp => new VehicleParkDetailsModel
                {
                    Id = vp.Id,
                    Name = vp.Name,
                    Adress = vp.Adress,
                    Email = vp.Email,
                    Phone = vp.Phone,
                    ImageUrl = vp.ImageUrl,
                    Description = vp.Description
                }).FirstAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<VehiclePark>()
                .AnyAsync(vp => vp.Id == id);
        }

        public async Task<VehicleParkDetailsModel> VehicleParkDetailsById(int id)
        {
            return await repo.AllReadonly<VehiclePark>()
                .Where(vp => vp.Id == id)
                .Select(vp => new VehicleParkDetailsModel
                {
                    Id = vp.Id,
                    Name = vp.Name,
                    Email = vp.Email,
                    Phone = vp.Phone,
                    Adress = vp.Adress,
                    ImageUrl = vp.ImageUrl,
                    Description = vp.Description
                }).FirstAsync();
        }
    }
}
