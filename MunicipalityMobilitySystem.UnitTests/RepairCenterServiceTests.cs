using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MunicipalityMobility.Core.Services.Admin;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Data;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;
using RepairCenter = MunicipalityMobilitySystem.Infrasructure.Data.Entities.RepairCenter;
using Vehicle = MunicipalityMobilitySystem.Infrasructure.Data.Entities.Vehicle;

namespace MunicipalityMobilitySystem.UnitTests
{
    [TestFixture]
    public class RepairCenterServiceTests
    {
        private IRepository repo;
        private ILogger<RepairCenterService> logger;

        private IRepairCenterService repairCenterService;
        private MunicipalityMobilitySystemDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<MunicipalityMobilitySystemDbContext>()
                .UseInMemoryDatabase("MobSystemDB")
                .Options;

            applicationDbContext = new MunicipalityMobilitySystemDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task GetRepairCentersShuldRetutnAllRepairCentersCountInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

            var dbRepairCenters = await repairCenterService.GetRepairCenters();

            Assert.That(dbRepairCenters.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task GetRepairCentersShuldRetutnGetRepairCentersInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

            var seededRepairCenter2 = new RepairCenter()
            {
                Id = 2,
                Name = "Eastern repair center",
                ImageUrl = "https://mybayutcdn.bayut.com/mybayut/wp-content/uploads/Cars-lifted-in-a-service-centre.jpg",
            };

            var dbRepairCenter = await repairCenterService.GetRepairCenters();

            Assert.IsTrue(dbRepairCenter.Skip(1).First().Id == seededRepairCenter2.Id);
            Assert.IsTrue(dbRepairCenter.Skip(1).First().Name == seededRepairCenter2.Name);
            Assert.IsTrue(dbRepairCenter.Skip(1).First().ImageUrl == seededRepairCenter2.ImageUrl);
        }

        [Test]
        public async Task ExistsShouldReturnCorrectCondition()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

            Assert.That(await repairCenterService.Exists(1), Is.True);
            Assert.That(await repairCenterService.Exists(2), Is.True);
            Assert.That(await repairCenterService.Exists(3), Is.True);
            Assert.That(await repairCenterService.Exists(10), Is.False);
        }


        [Test]

        public async Task CreateShouldMakeAndSaveNewCorrectVehicleObject()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

            var createRepairCenterModel = new RepairCenterDetailsServiceModel
            {
                Id = 4,
                Name = "Test",
                ImageUrl = "Test",
                VehicleParkId = 1,
            };

            await repairCenterService.Create(createRepairCenterModel);

            var createdRepairCenter = await repairCenterService.GetRepairCenterById(4);

            Assert.Multiple(() =>
            {
                Assert.That(createdRepairCenter.Name, Is.EqualTo("Test"));
                Assert.That(createdRepairCenter.ImageUrl, Is.EqualTo("Test"));
            });
        }

        [Test]

        public async Task CreateShouldThrowArgumentExeptinIfReceiveIncorrectObject()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

            var createRepairCenterModel = new RepairCenterDetailsServiceModel
            {
                Id = 1,
                Name = "Test",
                ImageUrl = "Test",
                VehicleParkId = 1,
            };

            Assert.ThrowsAsync<ApplicationException>(async () => await repairCenterService.Create(createRepairCenterModel));
        }

        [Test]
        public async Task GetRepairCenterByIdShuldRetutnGetRepairCenterFromDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

            var repairCenter = await repairCenterService.GetRepairCenterById(2);
            Assert.Multiple(() =>
            {
                Assert.That(repairCenter.Id == 2, Is.True);
                Assert.That(repairCenter.Name == "Eastern repair center", Is.True);
                Assert.That(repairCenter.ImageUrl == "https://mybayutcdn.bayut.com/mybayut/wp-content/uploads/Cars-lifted-in-a-service-centre.jpg", Is.True);
            });
        }

        [Test]
        public async Task DeleteShuldRemoveRepairCenterCorrectly()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

            var repairCenter = new RepairCenter
            {
                Id = 4,
                Name = "Test",
                ImageUrl = "Test",
                VehicleParkId = 1,
            };

            await repo.AddAsync(repairCenter);

            await repo.SaveChangesAsync();

            var dbRepairCentersBeforeDelete = await repairCenterService.GetRepairCenters();

            Assert.That(dbRepairCentersBeforeDelete.Count, Is.EqualTo(4));

            await repairCenterService.Delete(4);

            var dbRepairCentersAfterDelete = await repairCenterService.GetRepairCenters();

            Assert.That(dbRepairCentersAfterDelete.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task DeleteShouldThrowApplicationExceptionIfRepairCenterDoNotExists()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);
            repairCenterService = new RepairCenterService(repo, logger);

            Assert.ThrowsAsync<ApplicationException>(async () => await repairCenterService.Delete(7), "Database failed to delete info");
        }

        [Test]
        public async Task GetVehiclesForRepairShuldRetutnsVehiclesRorRepairFromDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

            var vehicleRorRepair1 = new Vehicle
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
                VehicleParkId = 2,
                ForRepearing = true,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            var vehicleRorRepair2 = new Vehicle
            {
                Id = 11,
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 0,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2020, 05, 09, 19, 15, 0),
                MomenOfRent = new DateTime(2020, 05, 09, 9, 15, 0),
                PricePerHour = 9,
                RentedPeriod = 10,
                VehicleParkId = 2,
                ForRepearing = true,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicleRorRepair1);
            await repo.AddAsync(vehicleRorRepair2);

            await repo.SaveChangesAsync();

            var vehiclesForRepair = await repairCenterService.GetVehiclesForRepair(2);
            Assert.Multiple(() =>
            {
                Assert.That(vehiclesForRepair.First().Id == 10, Is.True);
                Assert.That(vehiclesForRepair.Skip(1).First().Id == 11, Is.True);
                Assert.That(vehiclesForRepair.Count, Is.EqualTo(2));

            });
        }


        [Test]
        public async Task RepairVehicleShuldWorksCorrectly()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

            var vehicleRorRepair1 = new Vehicle
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
                VehicleParkId = 2,
                ForRepearing = true,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            var vehicleRorRepair2 = new Vehicle
            {
                Id = 11,
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 0,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2020, 05, 09, 19, 15, 0),
                MomenOfRent = new DateTime(2020, 05, 09, 9, 15, 0),
                PricePerHour = 9,
                RentedPeriod = 10,
                VehicleParkId = 2,
                ForRepearing = true,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicleRorRepair1);
            await repo.AddAsync(vehicleRorRepair2);

            await repo.SaveChangesAsync();

            await repairCenterService.RepairVehicle(10);

            var vehiclesForRepair = await repairCenterService.GetVehiclesForRepair(2);
            Assert.Multiple(() =>
            {
                Assert.That(vehiclesForRepair.First().Id == 10, Is.False);
                Assert.That(vehiclesForRepair.First().Id == 11, Is.True);
                Assert.That(vehiclesForRepair.Count, Is.EqualTo(1));

            });
        }

        [Test]
        public async Task GetVehicleForRepairByIdShuldWorksCorrectly()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

            var vehicleRorRepair1 = new Vehicle
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
                VehicleParkId = 2,
                ForRepearing = true,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            var vehicleRorRepair2 = new Vehicle
            {
                Id = 11,
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 0,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                MomenOfLeave = new DateTime(2020, 05, 09, 19, 15, 0),
                MomenOfRent = new DateTime(2020, 05, 09, 9, 15, 0),
                PricePerHour = 9,
                RentedPeriod = 10,
                VehicleParkId = 2,
                ForRepearing = true,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicleRorRepair1);
            await repo.AddAsync(vehicleRorRepair2);

            await repo.SaveChangesAsync();

            await repairCenterService.RepairVehicle(10);

            var vehicleForRepair = await repairCenterService.GetVehicleForRepairById(11);
            var vehiclesForRepair = await repairCenterService.GetVehiclesForRepair(2);  
            Assert.Multiple(() =>
            {
                Assert.That(vehicleForRepair.Id == 10, Is.False);
                Assert.That(vehicleForRepair.Id == 11, Is.True);
                Assert.That(vehiclesForRepair.Count, Is.EqualTo(1));
            });
        }

        [Test]

        public async Task CreateOrderShouldMakeAndSaveNewCorrectOrder()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

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

            model.Expenses.Add(expense);

            await repairCenterService.CreateOrder(model);

            var existOrder= await repairCenterService.ExistsOrder(model);
            var existsOrderById= await repairCenterService.ExistsOrderById(10);
            var orderById= await repairCenterService.GetOrderById(1);
            var orders= await repairCenterService.GetOrders();

            Assert.Multiple(() =>
            {
                Assert.That(existOrder, Is.True);
                Assert.That(existsOrderById, Is.False);
                Assert.That(orderById.Id, Is.EqualTo(1));
                Assert.That(orders.Count, Is.EqualTo(1));
            });

        }

        [Test]

        public async Task CreateOrderShouldThrowArgumentExeptinIfReceiveIncorrectObject()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

            var model = new PartsOrderServiceModel
            {
                RegistrationNumber = "01",
                TotalPrice = 10,
            };

            var expense = new ExpenseServiceModel
            {
                Name = "TestName",
                Quantity = 1,
                UnutPrice = 10,
            };

            model.Expenses.Add(expense);

            Assert.ThrowsAsync<ApplicationException>(async () => await repairCenterService.CreateOrder(model));
        }

        [Test]
        public async Task DeleteOrderShuldRemoveRepairCenterCorrectly()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            repairCenterService = new RepairCenterService(repo, logger);

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

            model.Expenses.Add(expense);

            await repairCenterService.CreateOrder(model);

            var dbOrdersBeforeDelete = await repairCenterService.GetOrders();

            Assert.That(dbOrdersBeforeDelete.Count, Is.EqualTo(1));

            await repairCenterService.DeleteOrder(1);

            var dbOrdersAftereDelete = await repairCenterService.GetOrders();

            Assert.That(dbOrdersAftereDelete.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task DeleteOrderShouldThrowApplicationExceptionIfRepairCenterDoNotExists()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);
            repairCenterService = new RepairCenterService(repo, logger);

            Assert.ThrowsAsync<ApplicationException>(async () => await repairCenterService.DeleteOrder(7), "Database failed to delete info");
        }

        [Test]
        public async Task GetExpensesByOrderIdShouldReturnsCorrectly()
        {
            var mokedLogger = new Mock<ILogger<RepairCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);
            repairCenterService = new RepairCenterService(repo, logger);

            var expense1 = new ExpenseServiceModel
            {
                Name = "TestName",
                Quantity = 1,
                UnutPrice = 10,
            };

            var expense2 = new ExpenseServiceModel
            {
                Name = "TestName2",
                Quantity = 2,
                UnutPrice = 20,
            };

            var model = new PartsOrderServiceModel
            {
                VehicleId = 1,
                RegistrationNumber = "01",
                Title = "Test",
                TotalPrice = 10,
            };

            model.Expenses.Add(expense1);
            model.Expenses.Add(expense2);

            await repairCenterService.CreateOrder(model);

            var expenses = await repairCenterService.GetExpensesByOrderId(1);

            Assert.That(expenses.Count, Is.EqualTo(2));
            Assert.That(expenses.First().Name, Is.EqualTo("TestName"));
            Assert.That(expenses.Skip(1).First().Name, Is.EqualTo("TestName2"));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
