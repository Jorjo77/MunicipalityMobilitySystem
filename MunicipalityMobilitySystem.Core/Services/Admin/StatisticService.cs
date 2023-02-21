using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;

namespace MunicipalityMobilitySystem.Core.Services.Admin
{

    public class StatisticService : IStatisticService
    {
        private readonly ILogger logger;
        private readonly IRepository repo;
        private readonly IGuard guard;

        public StatisticService(ILogger<StatisticService> _logger,
                            IRepository _repo,
                            IGuard _guard)
        {
            logger = _logger;
            repo = _repo;
            guard = _guard;
        }
        public int GetFreeVehiclesCount()
        {
            return repo.AllReadonly<Vehicle>()
                .Where(v => v.IsActive
                        && v.RenterId == null)
                .Count();
        }

        public int GetRentedVehiclesCount()
        {
            return repo.AllReadonly<Vehicle>()
                .Where(v => v.IsActive
                        && v.RenterId != null)
                .Count();
            
        }
        public int GetVehicleParksCount() 
        {
            return repo.AllReadonly<VehiclePark>().Count();
        }
        public IEnumerable<StatisticVehicleModel> GetTopVehicles()
        {
            return repo.AllReadonly<Vehicle>()
                .Where(v => v.IsActive)
                .OrderByDescending(v => v.RentedPeriod)
                .ThenByDescending(v => v.PricePerHour)
                .Select(v => new StatisticVehicleModel
                {
                    RentedPeriod = v.RentedPeriod,
                    RegistrationNumber = v.RegistrationNumber,
                    RentsCount = v.RentsCount,
                    RepairsCount = v.RepairsCount,
                    EngineType = v.EngineType,
                    PricePerHour = (int)v.PricePerHour,
                    Model = v.Model,
                })
                .ToList();
        }
        public StatisticVehicleModel GetTopBike()
        {
            return repo.AllReadonly<Vehicle>()
                .Where(v => v.Category.Name == "Bike"
                && v.IsActive)
                .OrderByDescending(v => v.RentedPeriod)
                .ThenByDescending(v => v.PricePerHour)
                .Select(v => new StatisticVehicleModel
                {
                    RegistrationNumber = v.RegistrationNumber,
                    RentedPeriod = v.RentedPeriod,
                    RentsCount = v.RentsCount,
                    RepairsCount = v.RepairsCount,
                    PricePerHour = (int)v.PricePerHour,
                    ImageUrl = v.ImageUrl,
                    Model = v.Model
                })
                .First();
        }

        public StatisticVehicleModel GetTopCar()
        {
            return repo.AllReadonly<Vehicle>()
                .Where(v => v.Category.Name == "Car"
                && v.IsActive)
                .OrderByDescending(v => v.RentedPeriod)
                .ThenByDescending(v => v.PricePerHour)
                .Select(v => new StatisticVehicleModel
                {
                    RegistrationNumber = v.RegistrationNumber,
                    RentedPeriod = v.RentedPeriod,
                    RentsCount = v.RentsCount,
                    RepairsCount = v.RepairsCount,
                    PricePerHour = (int)v.PricePerHour,
                    ImageUrl = v.ImageUrl,
                    Model = v.Model
                })
                .First();
        }

        public StatisticVehicleModel GetTopScooter()
        {
            return repo.AllReadonly<Vehicle>()
                .Where(v => v.Category.Name == "Scooter"
                && v.IsActive)
                .OrderByDescending(v => v.RentedPeriod)
                .ThenByDescending(v => v.PricePerHour)
                .Select(v => new StatisticVehicleModel
                {
                    RegistrationNumber = v.RegistrationNumber,
                    RentedPeriod = v.RentedPeriod,
                    RentsCount = v.RentsCount,
                    RepairsCount = v.RepairsCount,
                    PricePerHour = (int)v.PricePerHour,
                    ImageUrl = v.ImageUrl,
                    Model = v.Model
                })
                .First();
        }
        public StatisticViewModel GetStatistic()
        {

            var statisticModel = new StatisticViewModel
            {
                TotalVehicleParks = GetVehicleParksCount(),
                TotalRentedVehicles = GetRentedVehiclesCount(),
                TotalFreeVehicles = GetFreeVehiclesCount(),
                TopBike = GetTopBike(),
                TopCar = GetTopCar(),
                TopScooter = GetTopScooter(),
                TopVehicles = GetTopVehicles()
            };

            return statisticModel;
        }  
    }
}
