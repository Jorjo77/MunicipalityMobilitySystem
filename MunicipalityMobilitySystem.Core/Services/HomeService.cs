using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models;
using MunicipalityMobilitySystem.Data;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;

namespace MunicipalityMobilitySystem.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IRepository repo;

        private readonly IGuard guard;

        private readonly ILogger logger;

        public HomeService(
            IRepository repo,
            IGuard guard,
            ILogger<TruckService> logger)
        {
            this.repo = repo;
            this.logger = logger;
            this.guard = guard;
        }

        public async Task<VehicleHomeModel> LastTopRankedBike()
        {



            var topByke = await repo.AllReadonly<Bike>()
            .OrderByDescending(b => b.Id)
            .ThenByDescending(b => b.Rating)
            .Select(b => new VehicleHomeModel
            {
                Id = b.Id,
                Type = b.Type,
                Rating = b.Rating,
                ImageUrl = b.ImageUrl
            })
            .Take(1)
            .FirstOrDefaultAsync();

            guard.AgainstNull(topByke, "Bike can not be found");

            return topByke;
        }

        public async Task<VehicleHomeModel> LastTopRankedScooter()
        {

            var topScooter = await repo.AllReadonly<Scooter>()
            .OrderByDescending(s => s.Id)
            .ThenByDescending(b => b.Rating)
            .Select(b => new VehicleHomeModel
            {
                Id = b.Id,
                Type = b.Type,
                Rating = b.Rating,
                ImageUrl = b.ImageUrl
            })
            .Take(1)
            .FirstOrDefaultAsync();

            guard.AgainstNull(topScooter, "Scoorer can not be found");

            return topScooter;
        }

        public async Task<VehicleHomeModel> LastTopRankedCar()
        {

            var topCar = await repo.AllReadonly<Car>()
            .OrderByDescending(s => s.Id)
            .ThenByDescending(b => b.Rating)
            .Select(b => new VehicleHomeModel
            {
                Id = b.Id,
                Type = b.Type,
                Rating = b.Rating,
                ImageUrl = b.ImageUrl
            })
            .Take(1)
            .FirstOrDefaultAsync();

            guard.AgainstNull(topCar, "Car can not be found");

            return topCar;
        }

        public async Task<VehicleHomeModel> LastTopRankedTruck()
        {

            var topTruck = await repo.AllReadonly<Truck>()
            .OrderByDescending(s => s.Id)
            .ThenByDescending(b => b.Rating)
            .Select(b => new VehicleHomeModel
            {
                Id = b.Id,
                Type = b.Type,
                Rating = b.Rating,
                ImageUrl = b.ImageUrl
            })
            .Take(1)
            .FirstOrDefaultAsync();

            guard.AgainstNull(topTruck, "Truck can not be found");

            return topTruck;
        }

    }
}
