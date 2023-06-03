using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MunicipalityMobility.Core.Services.Admin;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Data;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;
using RepairCenter = MunicipalityMobilitySystem.Infrasructure.Data.Entities.RepairCenter;
using Vehicle = MunicipalityMobilitySystem.Infrasructure.Data.Entities.Vehicle;

namespace MunicipalityMobilitySystem.UnitTests
{
    [TestFixture]
    public class WashingCenterServiceTests
    {
        private IRepository repo;
        private ILogger<WashingCenterService> logger;

        private IWashingCenterService washingCenterService;
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
        public async Task GetWashingCentersShuldRetutnAllWashingCentersInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<WashingCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            washingCenterService = new WashingCenterService(repo, logger);

            var dbWashingCenters = await washingCenterService.GetWashingCenters();

            Assert.That(dbWashingCenters.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(dbWashingCenters.First().Id, Is.EqualTo(1));
                Assert.That(dbWashingCenters.First().Name, Is.EqualTo("Central washing center"));
                Assert.That(dbWashingCenters.Skip(1).First().Id, Is.EqualTo(2));
                Assert.That(dbWashingCenters.Skip(1).First().Name, Is.EqualTo("Eastern washing center"));
                Assert.That(dbWashingCenters.Skip(2).First().Id, Is.EqualTo(3));
                Assert.That(dbWashingCenters.Skip(2).First().Name, Is.EqualTo("Western washing center"));
            });
        }


        [Test]

        public async Task CreateShouldMakeAndSaveNewCorrectWashingCenterObject()
        {
            var mokedLogger = new Mock<ILogger<WashingCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            washingCenterService = new WashingCenterService(repo, logger);

            var createWasingCenterModel = new WashingCenterDetailsServiceModel
            {
                Id = 4,
                Name = "Test",
                ImageUrl = "Test",
                VehicleParkId = 1,
            };

            await washingCenterService.Create(createWasingCenterModel);

            var createdWashingCenter = await washingCenterService.GetWashingCenterById(4);

            Assert.Multiple(() =>
            {
                Assert.That(createdWashingCenter.Name, Is.EqualTo("Test"));
                Assert.That(createdWashingCenter.ImageUrl, Is.EqualTo("Test"));
            });
        }

        [Test]

        public async Task CreateShouldThrowArgumentExeptinIfReceiveIncorrectObject()
        {
            var mokedLogger = new Mock<ILogger<WashingCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            washingCenterService = new WashingCenterService(repo, logger);

            var createWasingCenterModel = new WashingCenterDetailsServiceModel
            {
                Id = 1,
                Name = "Test",
                ImageUrl = "Test",
                VehicleParkId = 1,
            };

            Assert.ThrowsAsync<ApplicationException>(async () => await washingCenterService.Create(createWasingCenterModel));
        }

        [Test]
        public async Task ExistsShouldReturnCorrectCondition()
        {
            var mokedLogger = new Mock<ILogger<WashingCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            washingCenterService = new WashingCenterService(repo, logger);
            Assert.Multiple(async () =>
            {
                Assert.That(await washingCenterService.Exists(1), Is.True);
                Assert.That(await washingCenterService.Exists(2), Is.True);
                Assert.That(await washingCenterService.Exists(3), Is.True);
                Assert.That(await washingCenterService.Exists(10), Is.False);
            });
        }

        [Test]
        public async Task GetWashingCenterByIdShuldRetutnWashingCenterFromDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<WashingCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            washingCenterService = new WashingCenterService(repo, logger);

            var washingCenter = await washingCenterService.GetWashingCenterById(2);
            Assert.Multiple(() =>
            {
                Assert.That(washingCenter.Id == 2, Is.True);
                Assert.That(washingCenter.Name == "Eastern washing center", Is.True);
                Assert.That(washingCenter.ImageUrl == "http://ultrasonicexpress.com/wp-content/uploads/2020/12/DSC_4331-scaled.jpg", Is.True);
            });
        }

        [Test]
        public async Task DeleteShuldRemoveWashingCenterCorrectly()
        {
            var mokedLogger = new Mock<ILogger<WashingCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            washingCenterService = new WashingCenterService(repo, logger);

            var washingCenter = new WashingCenter
            {
                Id = 4,
                Name = "Test",
                ImageUrl = "Test",
                VehicleParkId = 1,
            };

            await repo.AddAsync(washingCenter);

            await repo.SaveChangesAsync();

            var dbWashingCentersBeforeDelete = await washingCenterService.GetWashingCenters();

            Assert.That(dbWashingCentersBeforeDelete.Count, Is.EqualTo(4));

            await washingCenterService.Delete(4);

            var dbWashingCentersAfterDelete = await washingCenterService.GetWashingCenters();
            Assert.Multiple(async () =>
            {
                Assert.That(dbWashingCentersAfterDelete.Count, Is.EqualTo(3));

                Assert.That(await washingCenterService.Exists(1), Is.True);
                Assert.That(await washingCenterService.Exists(2), Is.True);
                Assert.That(await washingCenterService.Exists(3), Is.True);
            });
        }

        [Test]
        public async Task DeleteShouldThrowApplicationExceptionIfRepairCenterDoNotExists()
        {
            var mokedLogger = new Mock<ILogger<WashingCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);
            washingCenterService = new WashingCenterService(repo, logger);

            Assert.ThrowsAsync<ApplicationException>(async () => await washingCenterService.Delete(7), "Database failed to delete info");
        }

        [Test]
        public async Task GetVehiclesForRepairShuldRetutnsVehiclesRorRepairFromDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<WashingCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            washingCenterService = new WashingCenterService(repo, logger);

            var vehicleRorWashing1 = new Vehicle
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
                ForCleaning= true,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            var vehicleRorWashing2 = new Vehicle
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
                ForCleaning = true,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicleRorWashing1);
            await repo.AddAsync(vehicleRorWashing2);

            await repo.SaveChangesAsync();

            var vehiclesForWash = await washingCenterService.GetVehiclesForWashing("Bulgaria Sofia City Mladost 4");
            Assert.Multiple(() =>
            {
                Assert.That(vehiclesForWash.First().Id == 10, Is.True);
                Assert.That(vehiclesForWash.Skip(1).First().Id == 11, Is.True);
                Assert.That(vehiclesForWash.Count, Is.EqualTo(2));

            });
        }

        [Test]
        public async Task RepairVehicleShuldWorksCorrectly()
        {
            var mokedLogger = new Mock<ILogger<WashingCenterService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            washingCenterService = new WashingCenterService(repo, logger);

            var vehicleRorWashing1 = new Vehicle
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
                ForCleaning = true,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            var vehicleRorWashing2 = new Vehicle
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
                ForCleaning = true,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicleRorWashing1);
            await repo.AddAsync(vehicleRorWashing2);

            await repo.SaveChangesAsync();

            await washingCenterService.WashVehicle(10);

            var vehiclesForWashing = await washingCenterService.GetVehiclesForWashing("Bulgaria Sofia City Mladost 4");
            Assert.Multiple(() =>
            {
                Assert.That(vehiclesForWashing.First().Id == 10, Is.False);
                Assert.That(vehiclesForWashing.First().Id == 11, Is.True);
                Assert.That(vehiclesForWashing.Count, Is.EqualTo(1));

            });
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
