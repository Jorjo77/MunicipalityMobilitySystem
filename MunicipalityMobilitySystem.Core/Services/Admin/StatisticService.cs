﻿using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
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
                    Id = v.Id,
                    RentedPeriod = v.RentedPeriod,
                    RegistrationNumber = v.RegistrationNumber,
                    RentsCount = v.RentsCount,
                    RepairsCount = v.RepairsCount,
                    EngineType = v.EngineType,
                    PricePerHour = (int)v.PricePerHour,
                    Model = v.Model,
                    TotalExpenses = (double)v.OrderedParts.Sum(op => op.TotalPrice),
                    TotalIncome = (double)v.PricePerHour * v.RentedPeriod,
                    TotalProfit = ((double)v.PricePerHour * v.RentedPeriod) - (double)v.OrderedParts.Sum(op => op.TotalPrice)
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
                    Rating = (int)v.Rating,
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
                    Rating = (int)v.Rating,
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
                    Rating = (int)v.Rating,
                    TotalExpenses = (double)v.OrderedParts.Sum(op => op.TotalPrice),
                    TotalIncome = (double)v.PricePerHour * v.RentedPeriod,
                    TotalProfit = ((double)v.PricePerHour * v.RentedPeriod) - (double)v.OrderedParts.Sum(op => op.TotalPrice)
                })
                .OrderByDescending(v => v.TotalProfit)
                .ThenByDescending(v => v.RentedPeriod)
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
                        VehicleParkAdress = vehiclePark.Adress,
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

            return groupedVehicles.OrderByDescending(gv => gv.Sum(v => v.TotalProfit));
        }

        public IEnumerable<VehicleParkModel> GetVehicleParks()
        {
            return repo.AllReadonly<VehiclePark>()
                .Select(v => new VehicleParkModel
                {
                    Name = v.Name,
                    Id = v.Id,
                    ImageUrl = v.ImageUrl,
                    Adress = v.Adress,
                    Email = v.Email,
                    Phone = v.Phone,
                })
                .ToList();
        }

        public IEnumerable<StatisticVehicleModel> GetThreeMostReparedVehicles()
        {
            return repo.AllReadonly<Vehicle>()
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
                .OrderByDescending(v => v.RepairsCount)
                .ThenByDescending(v => v.TotalExpenses)
                .Take(3)
                .ToList();
        }

        public StatisticDetailsVehicleModel GetVehicleStatisticDetailsById(int id)
        {
            return repo.AllReadonly<Vehicle>()
                .Where(v => v.Id == id)
                .Select(v => new StatisticDetailsVehicleModel
                {
                    Model = v.Model,
                    EngineType = v.EngineType,
                    ImageUrl = v.ImageUrl,
                    PricePerHour = v.PricePerHour,
                    Rating = v.Rating,
                    RentedPeriod = v.RentedPeriod,
                    RepairsCount = v.RepairsCount,
                    RentsCount = v.RentsCount,
                    VehicleParkName = v.VehiclePark.Name,
                    VehicleParkAdress = v.VehiclePark.Adress,
                    TotalExpenses = (double)v.OrderedParts.Sum(op => op.TotalPrice),
                    TotalIncome = (double)v.PricePerHour * v.RentedPeriod,
                    TotalProfit = ((double)v.PricePerHour * v.RentedPeriod) - (double)v.OrderedParts.Sum(op => op.TotalPrice),
                })
                .First();
        }

        public ICollection<TheBillViewModel> AllBillsByVehicleId(int id)
        {
            return repo.AllReadonly<Bill>()
                .Where(b => b.VehicleId == id)
                .Select(b => new TheBillViewModel
                {
                    Id = b.Id,
                    VehicleId = b.VehicleId,
                    RenterId = b.RenterId,
                    RegistrationNumber = b.RegistrationNumber,
                    RentedPeriod = b.RentedPeriod,
                    Title = b.Title,
                    Model = b.Model,
                    MomenOfLeave = b.MomenOfLeave,
                    MomenOfRent = b.MomenOfRent,
                    PricePerHour = b.PricePerHour,
                    TotalPrice = b.TotalPrice
                })
                .ToList();
        }
        public ICollection<OrderViewModel> AllOrdersByVehicleId(int id)
        {
            return repo.AllReadonly<PartsOrder>()
                .Where(po => po.VehicleId == id)
                .Select(po => new OrderViewModel
                {
                    Id = po.Id,
                    RegistrationNumber = po.Vehicle.RegistrationNumber,
                    Title = po.Title,
                    TotalPrice = po.TotalPrice
                })
                .ToList();
        }
        public ICollection<VehicleDetailsFeedbackServiceModel> AllCustomerFeedbacksByVehicleId(int id)
        {
            return repo.AllReadonly<CustomerFeedback>()
                .Where(cf => cf.VehicleId == id)
                .Select(cf => new VehicleDetailsFeedbackServiceModel
                {
                    Id = cf.Id,
                    Model = cf.Vehicle.Model,
                    Rating = cf.Vehicle.Rating,
                    ImageUrl = cf.Vehicle.ImageUrl,
                    UserId = cf.UserId,
                    Feedback = cf.Feedback,
                    Vote = cf.Vote
                })
                .ToList();
        }
    }
}
