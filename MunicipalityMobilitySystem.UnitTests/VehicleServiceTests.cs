using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Core.Models.VehiclePark;
using MunicipalityMobilitySystem.Core.Services;
using MunicipalityMobilitySystem.Data;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;
using static MunicipalityMobilitySystem.Data.DataConstants;

namespace MunicipalityMobilitySystem.UnitTests
{
    [TestFixture]
    public class VehicleServiceTests
    {
        private IRepository repo;
        private ILogger<VehicleService> logger;
        private IGuard guard;
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
        public async Task AllVehiclesShuldRetutnAllVehiclesCountInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            var dbVehicles = await vehicleService.AllVehicles();

            Assert.That(dbVehicles.TotalVehiclesCount, Is.EqualTo(9));
        }

        [Test]
        public async Task AllVehiclesShuldRetutnVehiclesInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            var seededVehicle9 = new VehicleServiceModel()
            {
                Id = 9,
                RegistrationNumber = "C000003",
                EngineType = "Petrol",
                Model = "Mercedes CLS 180",
                PricePerHour = 25.00M,
                CategoryId = 3,
                VehicleParkId = 3,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU",
                Description = "A realy good and luxury transport solution.",
                RenterId = null
            };

            var dbVehicles = await vehicleService.AllVehicles();

            Assert.IsTrue(dbVehicles.Vehicles.First().Id == seededVehicle9.Id);
            Assert.IsTrue(dbVehicles.Vehicles.First().RegistrationNumber == seededVehicle9.RegistrationNumber);
            Assert.IsTrue(dbVehicles.Vehicles.First().EngineType == seededVehicle9.EngineType);
            Assert.IsTrue(dbVehicles.Vehicles.First().Model == seededVehicle9.Model);
            Assert.IsTrue(dbVehicles.Vehicles.First().PricePerHour == seededVehicle9.PricePerHour);
            Assert.IsTrue(dbVehicles.Vehicles.First().ImageUrl == seededVehicle9.ImageUrl);
            Assert.IsTrue(dbVehicles.Vehicles.First().Description == seededVehicle9.Description);
            Assert.IsTrue(dbVehicles.Vehicles.First().CategoryId == seededVehicle9.CategoryId);
            Assert.IsTrue(dbVehicles.Vehicles.First().VehicleParkId == seededVehicle9.VehicleParkId);
            Assert.IsTrue(dbVehicles.Vehicles.First().RenterId == seededVehicle9.RenterId);
        }

        [Test]
        public async Task ExistsShouldReturnCorrectCondition()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            Assert.That(await vehicleService.Exists(1), Is.True);
            Assert.That(await vehicleService.Exists(2), Is.True);
            Assert.That(await vehicleService.Exists(3), Is.True);
            Assert.That(await vehicleService.Exists(10), Is.False);
        }

        [Test]
        public async Task RentShouldThrowArgumentExceptionWhenRentAlreadyRentedVehicle()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            var repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            await vehicleService.Rent(1, "TestRenter");

            Assert.ThrowsAsync<ArgumentException>(async () => await vehicleService.Rent(1, "TestRenter"));
        }

        [Test]
        public async Task RentShouldWorkCorrectly()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            var repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            await vehicleService.Rent(1, "TestRenter");

            Assert.IsTrue(await vehicleService.IsRented(1));
            Assert.IsFalse(await vehicleService.IsRented(2));
        }

        [Test]
        public async Task IsRentedShouldReturnsCorrectly()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            var repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            await vehicleService.Rent(1, "TestRenter");

            Assert.IsTrue(await vehicleService.IsRented(1));
            Assert.IsFalse(await vehicleService.IsRented(2));
        }

        [Test]
        public async Task IsRentedByUserWithIdShouldReturnsCorrectly()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            var repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            await vehicleService.Rent(1, "TestRenter");

            Assert.IsTrue(await vehicleService.IsRentedByUserWithId(1, "TestRenter"));
            Assert.IsFalse(await vehicleService.IsRentedByUserWithId(2, "TestRenter"));
        }


        [Test]
        public async Task LeaveShouldThrowArgumentExceptionWhenLeaveNotRentedVehicle()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            var repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            Assert.ThrowsAsync<ArgumentException>(async () => await vehicleService.Leave(1));
        }

        [Test]
        public async Task VehicleDetailsShouldReturnCorrectVehicle()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            var repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            var seededVehicle9 = new VehicleServiceModel()
            {
                Id = 9,
                RegistrationNumber = "C000003",
                EngineType = "Petrol",
                Model = "Mercedes CLS 180",
                PricePerHour = 25.00M,
                CategoryId = 3,
                VehicleParkId = 3,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU",
                Description = "A realy good and luxury transport solution.",
                RenterId = null
            };

            var vehicle = await vehicleService.VehicleDetails(9);

            Assert.That(seededVehicle9.Id, Is.EqualTo(vehicle.Id));
            Assert.Multiple(() =>
            {
                Assert.That(seededVehicle9.Id, Is.EqualTo(vehicle.Id));
                Assert.That(seededVehicle9.RegistrationNumber, Is.EqualTo(vehicle.RegistrationNumber));
                Assert.That(seededVehicle9.EngineType, Is.EqualTo(vehicle.EngineType));
                Assert.That(seededVehicle9.Model, Is.EqualTo(vehicle.Model));
                Assert.That(seededVehicle9.PricePerHour, Is.EqualTo(vehicle.PricePerHour));
                Assert.That(seededVehicle9.CategoryId, Is.EqualTo(vehicle.CategoryId));
                Assert.That(seededVehicle9.VehicleParkId, Is.EqualTo(vehicle.VehicleParkId));
                Assert.That(seededVehicle9.ImageUrl, Is.EqualTo(vehicle.ImageUrl));
                Assert.That(seededVehicle9.Description, Is.EqualTo(vehicle.Description));
                Assert.That(seededVehicle9.RenterId, Is.EqualTo(vehicle.RenterId));
            });

        }

        [Test]
        public async Task CategoryExistsShouldReturnsCorrectly()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            var repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            Assert.IsTrue(await vehicleService.CategoryExists(1));
            Assert.IsFalse(await vehicleService.CategoryExists(4));
        }

        [Test]

        public async Task CreateShouldMakeAndSaveNewCorrectVehicleObject()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            var createVehicleModel = new CreateVehicleModel
            {
                RegistrationNumber = "Test",
                ModelName = "Test",
                CategoryId = 0,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                PricePerHour = 0,
                VehicleParkId = 0,
                IsActive = true
            };

            await vehicleService.Create(createVehicleModel);
  
            var createdVehicle = await vehicleService.VehicleDetails(10);
            Assert.Multiple(() =>
            {
                Assert.That(createdVehicle.RegistrationNumber, Is.EqualTo("Test"));
                Assert.That(createdVehicle.Model, Is.EqualTo("Test"));
                Assert.That(createdVehicle.CategoryId, Is.EqualTo(0));
                Assert.That(createdVehicle.Description, Is.EqualTo("Test"));
                Assert.That(createdVehicle.EngineType, Is.EqualTo("Test"));
                Assert.That(createdVehicle.ImageUrl, Is.EqualTo("Test"));
                Assert.That(createdVehicle.PricePerHour, Is.EqualTo(0));
                Assert.That(createdVehicle.VehicleParkId, Is.EqualTo(0));
                Assert.That(createdVehicle.IsActive, Is.True);
            });
        }

        [Test]

        public async Task CreateShouldThrowArgumentExeptinIfReceiveInCorrectObject()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            var createVehicleModel = new CreateVehicleModel
            {
                RegistrationNumber = "Test",
                ModelName = "Test",
            };

            Assert.ThrowsAsync<ApplicationException>(async () => await vehicleService.Create(createVehicleModel));
        }

        [Test]
        public async Task VehiceExistsShouldReturnsCorrectly()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            var repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            Assert.IsTrue(await vehicleService.VehiceExists("C000002"));
            Assert.IsFalse(await vehicleService.VehiceExists("Test"));
        }

        [Test]
        public async Task DeleteShouldRemoveVehicleFromDB()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            var repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            await vehicleService.Delete(1);

            var vehiclesInMemory = await vehicleService.AllVehicles();

            Assert.That(vehiclesInMemory.TotalVehiclesCount, Is.EqualTo(8));

            await vehicleService.Delete(2);

            vehiclesInMemory = await vehicleService.AllVehicles();

            Assert.That(vehiclesInMemory.TotalVehiclesCount, Is.EqualTo(7));
        }

        [Test]
        public async Task GetVehicleCategoryId()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            var repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            int categoryIdCar = await vehicleService.GetVehicleCategoryId(8);
            int categoryIdBike = await vehicleService.GetVehicleCategoryId(6);
            int categoryIdScooter= await vehicleService.GetVehicleCategoryId(3);
            Assert.Multiple(() =>
            {
                Assert.That(categoryIdCar, Is.EqualTo(3));
                Assert.That(categoryIdBike, Is.EqualTo(1));
                Assert.That(categoryIdScooter, Is.EqualTo(2));
            });
        }

        [Test]
        public async Task EditShouldChangeCorrectVehicle()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            var repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            var model = new CreateVehicleModel
            {
                RegistrationNumber = "Test",
                ModelName = "Test",
                CategoryId = 0,
                Description = "Test",
                EngineType = "Test",
                ImageUrl = "Test",
                PricePerHour = 0,
                VehicleParkId = 0,
                IsActive = true
            };

            await vehicleService.Edit(1, model);

            var editedVehicle = await vehicleService.VehicleDetails(1);

            Assert.That(editedVehicle.RegistrationNumber, Is.EqualTo("Test"));
            Assert.That(editedVehicle.Model, Is.EqualTo("Test"));
            Assert.That(editedVehicle.CategoryId, Is.EqualTo(0));
            Assert.That(editedVehicle.Description, Is.EqualTo("Test"));
            Assert.That(editedVehicle.EngineType, Is.EqualTo("Test"));
            Assert.That(editedVehicle.ImageUrl, Is.EqualTo("Test"));
            Assert.That(editedVehicle.PricePerHour, Is.EqualTo(0));
            Assert.That(editedVehicle.VehicleParkId, Is.EqualTo(0));
            Assert.That(editedVehicle.IsActive, Is.EqualTo(true));
        }

        [Test]
        public async Task AddFeedbackShouldChangeCorrectVehicle()
        {
            var mokedLogger = new Mock<ILogger<VehicleService>>();
            logger = mokedLogger.Object;
            var repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard, logger);

            var vehicle = new Infrasructure.Data.Entities.Vehicle
            {
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
            await vehicleService.AddFeedback(10, model);

            var customerFeedback = await vehicleService.CustomerVotesByVehicleId(10);

            Assert.That(customerFeedback.Count(), Is.EqualTo(1));
            Assert.That(customerFeedback.First().Id, Is.EqualTo(1));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
