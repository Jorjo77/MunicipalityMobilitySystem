using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts;
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

        public async Task<VehicleHomeModel> GetOneBike()
        {

            var bike = await repo.AllReadonly<Vehicle>()
                .Where(v => v.Category.Name == "Bike")
            .Select(b => new VehicleHomeModel
            {
                Id = b.Id,
                Model = b.Model,
                Rating = b.Rating,
                ImageUrl = b.ImageUrl
            })
            .FirstOrDefaultAsync();

            guard.AgainstNull(bike, "Bike can not be found");

            return bike;
        }

        public async Task<VehicleHomeModel> GetOneCar()
        {
            var car = await repo.AllReadonly<Vehicle>()
                .Where(v => v.Category.Name == "Car")
            .Select(b => new VehicleHomeModel
            {
                Id = b.Id,
                Model = b.Model,
                Rating = b.Rating,
                ImageUrl = b.ImageUrl
            })
            .FirstOrDefaultAsync();

            guard.AgainstNull(car, "Car can not be found");

            return car;
        }

        public async Task<VehicleHomeModel> GetOneScooter()
        {
            var scooter = await repo.AllReadonly<Vehicle>()
                .Where(v => v.Category.Name == "Scooter")
            .Select(b => new VehicleHomeModel
            {
                Id = b.Id,
                Model = b.Model,
                Rating = b.Rating,
                ImageUrl = b.ImageUrl
            })
            .FirstOrDefaultAsync();

            guard.AgainstNull(scooter, "Scooter can not be found");

            return scooter;
        }

        public async Task<IEnumerable<VehicleHomeModel>> LastThreeTopRankedVehicles()
        {
            var vehicles = await repo.AllReadonly<Vehicle>()
                .OrderByDescending(v => v.Id)
                .ThenByDescending(v => v.Rating)
                .Select(v => new VehicleHomeModel
                {
                    Id = v.Id,
                    Model = v.Model,
                    Rating = v.Rating,
                    ImageUrl = v.ImageUrl
                })
                .Take(3)
                .ToListAsync();

            return vehicles;
        }
    }
}
