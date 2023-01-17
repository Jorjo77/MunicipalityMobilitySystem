using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;

namespace MunicipalityMobilitySystem.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repo;

        private readonly IGuard guard;

        private readonly ILogger logger;

        public VehicleService(
            IRepository repo,
            IGuard guard,
            ILogger<VehicleService> logger)
        {
            this.repo = repo;
            this.logger = logger;
            this.guard = guard;
        }

        public async Task<IEnumerable<VehicleServiceModel>> AllVehiclesByUserId(string id)
        {
            return await repo.AllReadonly<Vehicle>()
                .Where(v=> v.RenterId == id)
                .Select(v => new VehicleServiceModel
                {
                    Id= v.Id,
                    ImageUrl= v.ImageUrl,
                    VehicleParkId= v.VehicleParkId,
                    CategoryId= v.CategoryId,
                    Description= v.Description,
                    EngineType= v.EngineType,
                    Model=v.Model,
                    PricePerHour= v.PricePerHour,
                    Rating= v.Rating,
                    RenterId= v.RenterId
                })
                .ToListAsync();
        }

        public async Task<VehicleServiceModel> VehicleDetails( int id)
        {
            return await repo.AllReadonly<Vehicle>()
                        .Where(v=>v.Id == id)
                        .Select(v => new VehicleServiceModel
                        {
                            Id = v.Id,
                            ImageUrl = v.ImageUrl,
                            VehicleParkId = v.VehicleParkId,
                            CategoryId = v.CategoryId,
                            Description = v.Description,
                            EngineType = v.EngineType,
                            Model = v.Model,
                            PricePerHour = v.PricePerHour,
                            Rating = v.Rating,
                            RenterId = v.RenterId
                        })
                        .FirstAsync();
        }
    }
}
