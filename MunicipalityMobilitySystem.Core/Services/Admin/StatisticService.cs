using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Models.VehiclePark;
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
                .Select(v => new StatisticVehicleModel
                {
                    RentedPeriod = v.RentedPeriod,
                    RegistrationNumber = v.RegistrationNumber,
                    RentsCount = v.RentsCount,
                    RepairsCount = v.RepairsCount,
                    EngineType = v.EngineType,
                    PricePerHour = (int)v.PricePerHour,
                    Model = v.Model,
                    TotalExpenses = (double)v.OrderedParts.Sum(op=>op.TotalPrice),
                    TotalIncome = (double)v.PricePerHour * v.RentedPeriod,
                    TotalProfit = ((double)v.PricePerHour * v.RentedPeriod)- (double)v.OrderedParts.Sum(op => op.TotalPrice)
                })
                .OrderByDescending(v => v.TotalProfit)
                .ThenByDescending(v => v.RentedPeriod)
                .ToList();
        }
        public StatisticVehicleModel GetTopBike()
        {
            return repo.AllReadonly<Vehicle>()
                .Where(v => v.Category.Name == "Bike"
                && v.IsActive)
                .Select(v => new StatisticVehicleModel
                {
                    RegistrationNumber = v.RegistrationNumber,
                    RentedPeriod = v.RentedPeriod,
                    RentsCount = v.RentsCount,
                    RepairsCount = v.RepairsCount,
                    PricePerHour = (int)v.PricePerHour,
                    ImageUrl = v.ImageUrl,
                    Model = v.Model,
                    TotalExpenses = (double)v.OrderedParts.Sum(op => op.TotalPrice),
                    TotalIncome = (double)v.PricePerHour * v.RentedPeriod,
                    TotalProfit = ((double)v.PricePerHour * v.RentedPeriod) - (double)v.OrderedParts.Sum(op => op.TotalPrice)
                })
                .OrderByDescending(v => v.TotalProfit)
                .ThenByDescending(v => v.RentedPeriod)
                .First();
        }

        public StatisticVehicleModel GetTopCar()
        {
            return repo.AllReadonly<Vehicle>()
                .Where(v => v.Category.Name == "Car"
                && v.IsActive)
                .Select(v => new StatisticVehicleModel
                {
                    RegistrationNumber = v.RegistrationNumber,
                    RentedPeriod = v.RentedPeriod,
                    RentsCount = v.RentsCount,
                    RepairsCount = v.RepairsCount,
                    PricePerHour = (int)v.PricePerHour,
                    ImageUrl = v.ImageUrl,
                    Model = v.Model,
                    TotalExpenses = (double)v.OrderedParts.Sum(op => op.TotalPrice),
                    TotalIncome = (double)v.PricePerHour * v.RentedPeriod,
                    TotalProfit = ((double)v.PricePerHour * v.RentedPeriod) - (double)v.OrderedParts.Sum(op => op.TotalPrice)
                })
                .OrderByDescending(v => v.TotalProfit)
                .ThenByDescending(v => v.RentedPeriod)
                .First();
        }

        public StatisticVehicleModel GetTopScooter()
        {
            return repo.AllReadonly<Vehicle>()
                .Where(v => v.Category.Name == "Scooter" 
                && v.IsActive)
                .Select(v => new StatisticVehicleModel
                {
                    RegistrationNumber = v.RegistrationNumber,
                    RentedPeriod = v.RentedPeriod,
                    RentsCount = v.RentsCount,
                    RepairsCount = v.RepairsCount,
                    PricePerHour = (int)v.PricePerHour,
                    ImageUrl = v.ImageUrl,
                    Model = v.Model,
                    TotalExpenses = (double)v.OrderedParts.Sum(op => op.TotalPrice),
                    TotalIncome = (double)v.PricePerHour * v.RentedPeriod,
                    TotalProfit = ((double)v.PricePerHour * v.RentedPeriod) - (double)v.OrderedParts.Sum(op => op.TotalPrice)
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
                TopVehicles = GetTopVehicles(),
                TopVehicleParks = GetTopVehicleParks(),
                ThreeMostReparedVehicles = GetThreeMostReparedVehicles(),
            };

            return statisticModel;
        }

        public IEnumerable<IEnumerable<StatisticVehicleParkModel>> GetTopVehicleParks()
        {
            var groupedVehicles = new List<List<StatisticVehicleParkModel>>();
            var vehicleParks = GetVehicleParks();

            foreach (var vehiclePark in vehicleParks)
            {
                var vehiclesStatistic = repo.AllReadonly<Vehicle>()
                    .Where(v => v.VehicleParkId == vehiclePark.Id)
                    .Select(v => new StatisticVehicleParkModel
                    {
                        VehicleParkName = vehiclePark.Name,
                        VehicleParkAdress= vehiclePark.Adress,
                        PricePerHour = (int)v.PricePerHour,
                        RentedPeriod = v.RentedPeriod,
                        RentsCount = v.RentsCount,
                        RepairsCount = v.RepairsCount,
                        TotalExpenses = (double)v.OrderedParts.Sum(op => op.TotalPrice),
                        TotalIncome = (double)v.PricePerHour * v.RentedPeriod,
                        TotalProfit = ((double)v.PricePerHour * v.RentedPeriod) - (double)v.OrderedParts.Sum(op => op.TotalPrice)
                    })
                    .ToList();

                groupedVehicles.Add(vehiclesStatistic);
            }

            //var orderedVehicles = groupedVehicles.OrderByDescending(vg=>vg.OrderByDescending(v=>v.TotalProfit));

            return groupedVehicles;
        }

        public IEnumerable<VehicleParkModel> GetVehicleParks()
        {
            return repo.AllReadonly<VehiclePark>()
                .Select(v=> new VehicleParkModel
                {
                    Name= v.Name,
                    Id= v.Id,
                    ImageUrl= v.ImageUrl,
                    Adress= v.Adress,
                    Email= v.Email,
                    Phone= v.Phone,
                })
                .ToList();
        }

        public IEnumerable<StatisticVehicleModel> GetThreeMostReparedVehicles()
        {
            return repo.AllReadonly<Vehicle>()
                .Select(v=> new StatisticVehicleModel
                {
                    RegistrationNumber = v.RegistrationNumber,
                    RentedPeriod = v.RentedPeriod,
                    RentsCount = v.RentsCount,
                    RepairsCount = v.RepairsCount,
                    PricePerHour = (int)v.PricePerHour,
                    ImageUrl = v.ImageUrl,
                    Model = v.Model,
                    TotalExpenses = (double)v.OrderedParts.Sum(op => op.TotalPrice),
                    TotalIncome = (double)v.PricePerHour * v.RentedPeriod,
                    TotalProfit = ((double)v.PricePerHour * v.RentedPeriod) - (double)v.OrderedParts.Sum(op => op.TotalPrice)
                })
                .OrderByDescending(v=>v.TotalExpenses)
                .ThenByDescending(v => v.RepairsCount)
                .Take(3)
                .ToList();
        }
    }
}
