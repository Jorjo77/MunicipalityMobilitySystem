using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models;
using MunicipalityMobilitySystem.Data;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;
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

        public async Task<IEnumerable<VehicleHomeModel>> LastTopRankedVehicles()
        {


            return await repo.VehicleParks
                .SelectMany(x => x.Cars)
                .Include(x => x.VehiclePark.Trucks)
                .Include(x => x.VehiclePark.Bikes)
                .Include(x => x.VehiclePark.Scooters)
                .OrderByDescending(x => x.Id)
                .ThenByDescending(x => x.Rating)
                .Select(v => new VehicleHomeModel
                {
                    Id = v.Id,
                    Type = v.Type,
                    ImageUrl = v.ImageUrl,
                    Rating = v.Rating
                }).Take(4)
                .ToListAsync();

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

             return topByke=null!;
        }

        public Task<IEnumerable<VehicleHomeModel>> LastTopRankedVehicles(VehicleHomeModel topBike, VehicleHomeModel topScooter, VehicleHomeModel topCar, VehicleHomeModel topTruck)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleHomeModel> LastTopRankedScooter()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleHomeModel> LastTopRankedCar()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleHomeModel> LastTopRankedTruck()
        {
            throw new NotImplementedException();
        }
    }
}
