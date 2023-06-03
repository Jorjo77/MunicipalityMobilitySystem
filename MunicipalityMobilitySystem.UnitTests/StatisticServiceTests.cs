using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MunicipalityMobility.Core.Services.Admin;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Core.Services;
using MunicipalityMobilitySystem.Core.Services.Admin;
using MunicipalityMobilitySystem.Data;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;
using Vehicle = MunicipalityMobilitySystem.Infrasructure.Data.Entities.Vehicle;

namespace MunicipalityMobilitySystem.UnitTests
{
    [TestFixture]
    public class StatisticServiceTests
    {
        private IRepository repo;
        private ILogger<StatisticService> logger;
        private ILogger<OfficeService> logger2;
        private ILogger<RepairCenterService> logger3;
        private ILogger<VehicleService> logger4;
        private IGuard guard;
        private IStatisticService statisticService;
        private IOfficeService officeService;
        private IRepairCenterService repairCenterService;
        private IVehicleService vehicleService;
        private MunicipalityMobilitySystemDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            guard = new Guard();
            var contextOptions = new DbContextOptionsBuilder<MunicipalityMobilitySystemDbContext>()
                .UseInMemoryDatabase("MobSystemDB")
                .Options;

            applicationDbContext = new MunicipalityMobilitySystemDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public void GetFreeVehiclesCountShuldRetutnAllFreeVehiclesInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<StatisticService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            statisticService = new StatisticService(logger, repo, guard);

            var freeVehicles = statisticService.GetFreeVehiclesCount();
            var rentedVehicles = statisticService.GetRentedVehiclesCount();

            Assert.That(freeVehicles, Is.EqualTo(9));
            Assert.That(rentedVehicles, Is.EqualTo(0));
        }

        [Test]
        public void GetVehicleParksCountShuldRetutnAllFreeVehicleParksInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<StatisticService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            statisticService = new StatisticService(logger, repo, guard);

            var vehicleParks = statisticService.GetVehicleParks();

            Assert.That(vehicleParks.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task GetTopBikeShuldRetutnMostProfitableBikeInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<StatisticService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            statisticService = new StatisticService(logger, repo, guard);

            var vehicle = new Vehicle
            {
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 1,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2019, 05, 09, 19, 15, 0),
                MomenOfRent = new DateTime(2019, 05, 09, 9, 15, 0),
                PricePerHour = 10,
                RentedPeriod = 10,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };


            await repo.AddAsync(vehicle);

            await repo.SaveChangesAsync();

            var topBike = statisticService.GetTopBike();

            Assert.That(topBike.RegistrationNumber, Is.EqualTo("Test"));
            Assert.That(topBike.PricePerHour, Is.EqualTo(10));
            Assert.That(topBike.RentedPeriod, Is.EqualTo(10));
        }

        [Test]
        public async Task GetTopCarShuldRetutnMostProfitableCarInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<StatisticService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            statisticService = new StatisticService(logger, repo, guard);

            var vehicle = new Vehicle
            {
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 3,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2019, 05, 09, 19, 15, 0),
                MomenOfRent = new DateTime(2019, 05, 09, 9, 15, 0),
                PricePerHour = 10,
                RentedPeriod = 10,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };


            await repo.AddAsync(vehicle);

            await repo.SaveChangesAsync();

            var topCar = statisticService.GetTopCar();

            Assert.That(topCar.RegistrationNumber, Is.EqualTo("Test"));
            Assert.That(topCar.PricePerHour, Is.EqualTo(10));
            Assert.That(topCar.RentedPeriod, Is.EqualTo(10));
        }

        [Test]
        public async Task GetTopScooterShuldRetutnMostProfitableScooterInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<StatisticService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            statisticService = new StatisticService(logger, repo, guard);

            var vehicle = new Vehicle
            {
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 2,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2019, 05, 09, 19, 15, 0),
                MomenOfRent = new DateTime(2019, 05, 09, 9, 15, 0),
                PricePerHour = 10,
                RentedPeriod = 10,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };


            await repo.AddAsync(vehicle);

            await repo.SaveChangesAsync();

            var topScooter = statisticService.GetTopScooter();

            Assert.That(topScooter.RegistrationNumber, Is.EqualTo("Test"));
            Assert.That(topScooter.PricePerHour, Is.EqualTo(10));
            Assert.That(topScooter.RentedPeriod, Is.EqualTo(10));
        }

        [Test]
        public void GetVehicleParksShuldRetutnAllVehicleParksInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<StatisticService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            statisticService = new StatisticService(logger, repo, guard);

            var vehicleParks = statisticService.GetVehicleParks();

            Assert.That(vehicleParks.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task GetThreeMostReparedVehiclesShuldRetutnMostReparedVehiclesInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<StatisticService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            statisticService = new StatisticService(logger, repo, guard);

            var vehicle1 = new Vehicle
            {
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 2,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                RepairsCount = 1,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };
            var vehicle2 = new Vehicle
            {
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 1,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                RepairsCount = 2,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            var vehicle3 = new Vehicle
            {
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 3,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                RepairsCount = 3,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicle1);
            await repo.AddAsync(vehicle2);
            await repo.AddAsync(vehicle3);

            await repo.SaveChangesAsync();

            var threeMostRepairedVehicles = statisticService.GetThreeMostReparedVehicles();

            Assert.That(threeMostRepairedVehicles.Count, Is.EqualTo(3));
            Assert.That(threeMostRepairedVehicles.First().RepairsCount, Is.EqualTo(3));
            Assert.That(threeMostRepairedVehicles.Skip(1).First().RepairsCount, Is.EqualTo(2));
            Assert.That(threeMostRepairedVehicles.Skip(2).First().RepairsCount, Is.EqualTo(1));

        }

        [Test]
        public async Task GetTopVehicleParksShuldRetutnMostProfitableVehicleParksInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<StatisticService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            statisticService = new StatisticService(logger, repo, guard);

            var vehicle1 = new Vehicle
            {
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 2,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2019, 05, 09, 19, 15, 0),
                MomenOfRent = new DateTime(2019, 05, 09, 9, 15, 0),
                PricePerHour = 10,
                RentedPeriod = 10,
                VehicleParkId = 1,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            var vehicle2 = new Vehicle
            {
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 2,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2019, 05, 09, 22, 15, 0),
                MomenOfRent = new DateTime(2019, 05, 09, 2, 15, 0),
                PricePerHour = 20,
                RentedPeriod = 20,
                VehicleParkId = 2,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            var vehicle3 = new Vehicle
            {
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 2,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2019, 06, 09, 07, 15, 0),
                MomenOfRent = new DateTime(2019, 05, 09, 1, 15, 0),
                PricePerHour = 30,
                RentedPeriod = 30,
                VehicleParkId = 3,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicle1);
            await repo.AddAsync(vehicle2);
            await repo.AddAsync(vehicle3);

            await repo.SaveChangesAsync();

            var topThreedVehicleParks = statisticService.GetTopVehicleParks();

            Assert.That(topThreedVehicleParks.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(topThreedVehicleParks.First().Sum(v => v.RentedPeriod), Is.EqualTo(30.0d));
                Assert.That(topThreedVehicleParks.Skip(1).First().Sum(v => v.RentedPeriod), Is.EqualTo(20.0d));
                Assert.That(topThreedVehicleParks.Skip(2).First().Sum(v => v.RentedPeriod), Is.EqualTo(10.0d));
            });
        }

        [Test]
        public async Task GetVehicleStatisticDetailsByIdShuldRetutVehicleStatisticFromDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<StatisticService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            statisticService = new StatisticService(logger, repo, guard);

            var vehicle1 = new Vehicle
            {
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 2,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2019, 05, 09, 19, 15, 0),
                MomenOfRent = new DateTime(2019, 05, 09, 9, 15, 0),
                PricePerHour = 10,
                RentedPeriod = 10,
                VehicleParkId = 1,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            var vehicle2 = new Vehicle
            {
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 2,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2019, 05, 09, 22, 15, 0),
                MomenOfRent = new DateTime(2019, 05, 09, 2, 15, 0),
                PricePerHour = 20,
                RentedPeriod = 20,
                VehicleParkId = 2,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            var vehicle3 = new Vehicle
            {
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 2,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2019, 06, 09, 07, 15, 0),
                MomenOfRent = new DateTime(2019, 05, 09, 1, 15, 0),
                PricePerHour = 30,
                RentedPeriod = 30,
                VehicleParkId = 3,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicle1);
            await repo.AddAsync(vehicle2);
            await repo.AddAsync(vehicle3);

            await repo.SaveChangesAsync();

            var vehicle1Statistic = statisticService.GetVehicleStatisticDetailsById(10);
            var vehicle2Statistic = statisticService.GetVehicleStatisticDetailsById(11);
            var vehicle3Statistic = statisticService.GetVehicleStatisticDetailsById(12);


            Assert.That(vehicle1Statistic.PricePerHour, Is.EqualTo(10.0m));
            Assert.That(vehicle1Statistic.TotalProfit, Is.EqualTo(100.0d));
            Assert.That(vehicle2Statistic.PricePerHour, Is.EqualTo(20.0m));
            Assert.That(vehicle2Statistic.TotalProfit, Is.EqualTo(400.0d));
            Assert.That(vehicle3Statistic.PricePerHour, Is.EqualTo(30.0m));
            Assert.That(vehicle3Statistic.TotalProfit, Is.EqualTo(900.0d));
        }

        [Test]
        public async Task AllBillsByVehicleIdShuldRetutnAllBillsByVehicleIdInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<StatisticService>>();
            logger = mokedLogger.Object;
            var mokedLogger2 = new Mock<ILogger<OfficeService>>();
            logger2 = mokedLogger2.Object;
            repo = new Repository(applicationDbContext);

            statisticService = new StatisticService(logger, repo, guard);

            officeService = new OfficeService(logger2, guard, repo);

            var vehicle = new Vehicle
            {
                Id = 10,
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 0,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2019, 05, 09, 19, 15, 0),
                MomenOfRent = new DateTime(2019, 05, 09, 9, 15, 0),
                PricePerHour = 10,
                RentedPeriod = 10,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };


            var model = new VehicleDetailsViewModel
            {
                Id = 10,
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 0,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2019, 05, 09, 19, 15, 0),
                MomenOfRent = new DateTime(2019, 05, 09, 9, 15, 0),
                PricePerHour = 10m,
                RentedPeriod = 10,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test2",
                IsActive = true
            };

            var model2 = new VehicleDetailsViewModel
            {
                Id = 10,
                RegistrationNumber = "Test2",
                Model = "Test2",
                CategoryId = 0,
                Description = "Test2",
                EngineType = "Test2",
                ImageUrl = "Test2",
                MomenOfLeave = new DateTime(2020, 05, 09, 15, 15, 0),
                MomenOfRent = new DateTime(2020, 05, 09, 9, 15, 0),
                PricePerHour = 10m,
                RentedPeriod = 6,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicle);

            await repo.SaveChangesAsync();

            await officeService.MakeAndPostTheBill(model, "User");

            await officeService.MakeAndPostTheBill(model2, "User");

            var allbillsByVehicleId = statisticService.AllBillsByVehicleId(vehicle.Id);

            Assert.Multiple(() =>
            {
                Assert.That(allbillsByVehicleId.First().Id, Is.EqualTo(1));
                Assert.That(allbillsByVehicleId.First().RentedPeriod, Is.EqualTo(10));

                Assert.That(allbillsByVehicleId.Skip(1).First().Id, Is.EqualTo(2));
                Assert.That(allbillsByVehicleId.Skip(1).First().RentedPeriod, Is.EqualTo(6));
            });
        }

        [Test]

        public async Task AllOrdersByVehicleIdShouldReturnCorrectOrders()
        {
            var mokedLogger3 = new Mock<ILogger<RepairCenterService>>();
            logger3 = mokedLogger3.Object;
            repo = new Repository(applicationDbContext);

            var mokedLogger = new Mock<ILogger<StatisticService>>();
            logger = mokedLogger.Object;

            repairCenterService = new RepairCenterService(repo, logger3);
            statisticService = new StatisticService(logger, repo, guard);

            var expense = new ExpenseServiceModel
            {
                Name = "TestName",
                Quantity = 1,
                UnutPrice = 10,
            };

            var model = new PartsOrderServiceModel
            {
                VehicleId = 1,
                RegistrationNumber = "01",
                Title = "Test",
                TotalPrice = 10,
            };

            var expense2 = new ExpenseServiceModel
            {
                Name = "TestName2",
                Quantity = 1,
                UnutPrice = 20,
            };

            var model2 = new PartsOrderServiceModel
            {
                VehicleId = 1,
                RegistrationNumber = "01",
                Title = "Test2",
                TotalPrice = 20,
            };

            model.Expenses.Add(expense);
            model2.Expenses.Add(expense2);

            await repairCenterService.CreateOrder(model);
            await repairCenterService.CreateOrder(model2);

            var existOrder = await repairCenterService.ExistsOrder(model);
            var existOrder2 = await repairCenterService.ExistsOrder(model2);

            var ordrsByVehicleId = statisticService.AllOrdersByVehicleId(1);

            Assert.Multiple(() =>
            {
                Assert.That(existOrder, Is.True);
                Assert.That(existOrder2, Is.True);

                Assert.That(ordrsByVehicleId.First().Id, Is.EqualTo(1));
                Assert.That(ordrsByVehicleId.First().TotalPrice, Is.EqualTo(10));
                Assert.That(ordrsByVehicleId.Skip(1).First().Id, Is.EqualTo(2));
                Assert.That(ordrsByVehicleId.Skip(1).First().TotalPrice, Is.EqualTo(20));
            });

        }

        [Test]
        public async Task AllCustomerFeedbacksByVehicleIdShouldReturnCustomerFeedbacksCorrectly()
        {
            var mokedLogger4 = new Mock<ILogger<VehicleService>>();
            logger4 = mokedLogger4.Object;
            repo = new Repository(applicationDbContext);

            var mokedLogger = new Mock<ILogger<StatisticService>>();
            logger = mokedLogger.Object;

            vehicleService = new VehicleService(repo, guard, logger4);
            statisticService = new StatisticService(logger, repo, guard);

            var vehicle = new Vehicle
            {
                Id = 10,
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 0,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                PricePerHour = 0,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                IsActive = true
            };

            await repo.AddAsync(vehicle);

            await repo.SaveChangesAsync();

            var model = new VehicleDetailsFeedbackServiceModel
            {
                Id = 1,
                Model = "Test",
                VehicleId = 10,
                Rating = 0.1,
                Feedback = "Test",
                ImageUrl = "Test",
                Vote = 1,
                UserId = "004bb11b-754a-422d-917b-27729dd1af3c",
            };

            var model2 = new VehicleDetailsFeedbackServiceModel
            {
                Id = 2,
                Model = "Test2",
                VehicleId = 10,
                Rating = 2,
                Feedback = "Test2",
                ImageUrl = "Test2",
                Vote = 2,
                UserId = "004bb11b-754a-422d-917b-27729dd1af3c",
            };

            await vehicleService.AddFeedback(10, model);
            await vehicleService.AddFeedback(10, model2);

            var customerFeedback = await vehicleService.CustomerVotesByVehicleId(10);

            var allCustomerFeedbacks = statisticService.AllCustomerFeedbacksByVehicleId(10);

            Assert.That(customerFeedback.Count(), Is.EqualTo(2));
            Assert.That(customerFeedback.First().Id, Is.EqualTo(1));
            Assert.That(customerFeedback.Skip(1).First().Id, Is.EqualTo(2));

            Assert.That(allCustomerFeedbacks.First().Id, Is.EqualTo(1));
            Assert.That(allCustomerFeedbacks.First().Vote, Is.EqualTo(1));
            Assert.That(allCustomerFeedbacks.Skip(1).First().Id, Is.EqualTo(2));
            Assert.That(allCustomerFeedbacks.Skip(1).First().Vote, Is.EqualTo(2));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}