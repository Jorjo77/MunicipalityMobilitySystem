using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Core.Services.Admin;
using MunicipalityMobilitySystem.Data;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;


namespace MunicipalityMobilitySystem.UnitTests
{
    [TestFixture]
    public class OfficeServiceTests
    {
        private IRepository repo;
        private ILogger<OfficeService> logger;
        private IGuard guard;
        private IOfficeService officeService;
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
        public async Task EditLeftVehicleByIdShouldChangeVehicleCorrectly()
        {
            var mokedLogger = new Mock<ILogger<OfficeService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            officeService = new OfficeService(logger, guard, repo);

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
                FailureDescription = "",
                IsActive = true
            };

            await repo.AddAsync(vehicle);

            await repo.SaveChangesAsync();

            var model = new VehicleDetailsViewModel
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
                FailureDescription = "Test",
                IsActive = true
            };

            await officeService.EditLeftVehicleById(model);

            var editedVehicle = await officeService.GetLeftVehicleById(10);

            Assert.That(editedVehicle.FailureDescription, Is.EqualTo("Test"));
        }

        [Test]
        public async Task GetLeftVehicleByIdShouldReturnCorrectVehicle()
        {
            var mokedLogger = new Mock<ILogger<OfficeService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            officeService = new OfficeService(logger, guard, repo);

            var vehicle = new Vehicle
            {
                Id = 10,
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 0,
                Description = "Testvane",
                EngineType = "Test",
                ImageUrl = "Test",
                PricePerHour = 0,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "",
                IsActive = true
            };

            await repo.AddAsync(vehicle);

            await repo.SaveChangesAsync();

            var gettedVehicle = await officeService.GetLeftVehicleById(10);
            Assert.Multiple(() =>
            {
                Assert.That(gettedVehicle.Id, Is.EqualTo(10));
                Assert.That(gettedVehicle.RegistrationNumber, Is.EqualTo("Test"));
                Assert.That(gettedVehicle.CategoryId, Is.EqualTo(0));
                Assert.That(gettedVehicle.PricePerHour, Is.EqualTo(0));
                Assert.That(gettedVehicle.VehicleParkId, Is.EqualTo(0));
                Assert.That(gettedVehicle.RenterId, Is.EqualTo("004bb11b-754a-422d-917b-27729dd1af3c"));
                Assert.That(gettedVehicle.FailureDescription, Is.EqualTo(""));
            });
        }

        [Test]
        public async Task GetLeftVehiclesShouldReturnCorrectVehicles()
        {
            var mokedLogger = new Mock<ILogger<OfficeService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            officeService = new OfficeService(logger, guard, repo);

            var vehicle1 = new Vehicle
            {
                Id = 10,
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 0,
                Description = "Testvane",
                EngineType = "Test",
                ImageUrl = "Test",
                PricePerHour = 0,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "",
                MomenOfLeave = null,
                ForCleaning = true,
                ForRepearing = true,
                IsActive = true
            };
            var vehicle2 = new Vehicle
            {
                Id = 11,
                RegistrationNumber = "Test2",
                Model = "Test2",
                CategoryId = 1,
                Description = "Testvane2",
                EngineType = "Test2",
                ImageUrl = "Test2",
                PricePerHour = 0,
                VehicleParkId = 0,
                RenterId = "",
                FailureDescription = "",
                MomenOfLeave = DateTime.UtcNow,
                ForCleaning = false,
                ForRepearing = false,
                IsActive = true
            };
            var vehicle3 = new Vehicle
            {
                Id = 12,
                RegistrationNumber = "Test3",
                Model = "Test3",
                CategoryId = 0,
                Description = "Testvane3",
                EngineType = "Test3",
                ImageUrl = "Test3",
                PricePerHour = 0,
                VehicleParkId = 0,
                RenterId = "004bb11b",
                FailureDescription = "",
                MomenOfLeave = null,
                ForCleaning = true,
                ForRepearing = true,
                IsActive = true
            };

            await repo.AddAsync(vehicle1);
            await repo.AddAsync(vehicle2);
            await repo.AddAsync(vehicle3);

            await repo.SaveChangesAsync();

            var gettedVehicles = await officeService.GetLeftVehicles();

            Assert.Multiple(() =>
            {
                Assert.That(gettedVehicles.Count, Is.EqualTo(1));
                Assert.That(gettedVehicles.First().Id, Is.EqualTo(11));
            });
        }

        [Test]
        public async Task SetVehicleForCleaningShouldSetCorrectly()
        {
            var mokedLogger = new Mock<ILogger<OfficeService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            officeService = new OfficeService(logger, guard, repo);

            var vehicle1 = new Vehicle
            {
                Id = 10,
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 0,
                Description = "Testvane",
                EngineType = "Test",
                ImageUrl = "Test",
                PricePerHour = 0,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "",
                MomenOfLeave = DateTime.UtcNow,
                ForCleaning = false,
                ForRepearing = false,
                IsActive = true
            };
            var vehicle2 = new Vehicle
            {
                Id = 11,
                RegistrationNumber = "Test2",
                Model = "Test2",
                CategoryId = 1,
                Description = "Testvane2",
                EngineType = "Test2",
                ImageUrl = "Test2",
                PricePerHour = 0,
                VehicleParkId = 0,
                RenterId = "",
                FailureDescription = "",
                MomenOfLeave = DateTime.UtcNow,
                ForCleaning = false,
                ForRepearing = false,
                IsActive = true
            };
            var vehicle3 = new Vehicle
            {
                Id = 12,
                RegistrationNumber = "Test3",
                Model = "Test3",
                CategoryId = 0,
                Description = "Testvane3",
                EngineType = "Test3",
                ImageUrl = "Test3",
                PricePerHour = 0,
                VehicleParkId = 0,
                RenterId = "004bb11b",
                FailureDescription = "",
                MomenOfLeave = DateTime.UtcNow,
                ForCleaning = false,
                ForRepearing = false,
                IsActive = true
            };

            await repo.AddAsync(vehicle1);
            await repo.AddAsync(vehicle2);
            await repo.AddAsync(vehicle3);

            await repo.SaveChangesAsync();

            await officeService.SetVehicleForCleaning(11);

            var vehicleForCleaning = await repo.GetByIdAsync<Vehicle>(11);

            var getLeftVehicles = await officeService.GetLeftVehicles();

            Assert.Multiple(() =>
            {
                Assert.That(getLeftVehicles.Count, Is.EqualTo(2));
                Assert.That(getLeftVehicles.First().Id, Is.EqualTo(10));
                Assert.That(vehicleForCleaning.ForCleaning, Is.True);
            });
        }

        [Test]
        public async Task SetVehicleForRepairingShouldSetCorrectly()
        {
            var mokedLogger = new Mock<ILogger<OfficeService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            officeService = new OfficeService(logger, guard, repo);

            var vehicle1 = new Vehicle
            {
                Id = 10,
                RegistrationNumber = "Test",
                Model = "Test",
                CategoryId = 0,
                Description = "Testvane",
                EngineType = "Test",
                ImageUrl = "Test",
                PricePerHour = 0,
                VehicleParkId = 0,
                RenterId = "004bb11b-754a-422d-917b-27729dd1af3c",
                FailureDescription = "",
                MomenOfLeave = DateTime.UtcNow,
                ForCleaning = false,
                ForRepearing = false,
                IsActive = true
            };
            var vehicle2 = new Vehicle
            {
                Id = 11,
                RegistrationNumber = "Test2",
                Model = "Test2",
                CategoryId = 1,
                Description = "Testvane2",
                EngineType = "Test2",
                ImageUrl = "Test2",
                PricePerHour = 0,
                VehicleParkId = 0,
                RenterId = "",
                FailureDescription = "",
                MomenOfLeave = DateTime.UtcNow,
                ForCleaning = false,
                ForRepearing = false,
                IsActive = true
            };
            var vehicle3 = new Vehicle
            {
                Id = 12,
                RegistrationNumber = "Test3",
                Model = "Test3",
                CategoryId = 0,
                Description = "Testvane3",
                EngineType = "Test3",
                ImageUrl = "Test3",
                PricePerHour = 0,
                VehicleParkId = 0,
                RenterId = "004bb11b",
                FailureDescription = "",
                MomenOfLeave = DateTime.UtcNow,
                ForCleaning = false,
                ForRepearing = false,
                IsActive = true
            };

            await repo.AddAsync(vehicle1);
            await repo.AddAsync(vehicle2);
            await repo.AddAsync(vehicle3);

            await repo.SaveChangesAsync();

            await officeService.SetVehicleForRepairing(11);

            var vehicleForRepairing = await repo.GetByIdAsync<Vehicle>(11);

            var getLeftVehicles = await officeService.GetLeftVehicles();

            Assert.Multiple(() =>
            {
                Assert.That(getLeftVehicles.Count, Is.EqualTo(2));
                Assert.That(getLeftVehicles.First().Id, Is.EqualTo(10));
                Assert.That(vehicleForRepairing.ForRepearing, Is.True);
            });
        }

        [Test]
        public async Task MakeAndPostTheBillShouldWorkCorrectly()
        {
            var mokedLogger = new Mock<ILogger<OfficeService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            officeService = new OfficeService(logger, guard, repo);

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
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicle);

            await repo.SaveChangesAsync();

            await officeService.MakeAndPostTheBill(model, "User");

            var bill = await officeService.GetBillById(1);

            var billTotalPrice = await officeService.GetTheBill(10);

            Assert.Multiple(async () =>
            {
                Assert.That(await officeService.BillExists(model), Is.True);
                Assert.That(bill, Is.Not.Null);
                Assert.That(billTotalPrice, Is.EqualTo(100));

            });
        }

        [Test]
        public async Task GetTheBillsShouldWorkCorrectly()
        {
            var mokedLogger = new Mock<ILogger<OfficeService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            officeService = new OfficeService(logger, guard, repo);

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
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicle);

            await repo.SaveChangesAsync();

            await officeService.MakeAndPostTheBill(model, "User");

            var bills = await officeService.GetTheBills();

            Assert.Multiple(() =>
            {
                Assert.That(bills.Any(), Is.True);
                Assert.That(bills.Count, Is.EqualTo(1));
                Assert.That(bills.First().TotalPrice, Is.EqualTo(100));
            });
        }

        [Test]
        public async Task DeleteBillByIdShouldThrowApplicationExceptionIfBillDoNotExists()
        {
            var mokedLogger = new Mock<ILogger<OfficeService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            officeService = new OfficeService(logger, guard, repo);

            Assert.ThrowsAsync<ApplicationException>(async () => await officeService.DeleteBillById(7), "Database failed to delete info");
        }

        [Test]
        public async Task DeleteBillByIdShouldWorkCorrectly()
        {
            var mokedLogger = new Mock<ILogger<OfficeService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            officeService = new OfficeService(logger, guard, repo);

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
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicle);

            await repo.SaveChangesAsync();

            await officeService.MakeAndPostTheBill(model, "User");

            await officeService.DeleteBillById(1);

            var bills = await officeService.GetTheBills();

            Assert.Multiple(() =>
            {
                Assert.That(bills.Any(), Is.False);
                Assert.That(bills.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task AllBillsByUserIdShouldWorkCorrectly()
        {
            var mokedLogger = new Mock<ILogger<OfficeService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            officeService = new OfficeService(logger, guard, repo);

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
                FailureDescription = "Test",
                IsActive = true
            };

            await repo.AddAsync(vehicle);

            await repo.SaveChangesAsync();

            await officeService.MakeAndPostTheBill(model, "User");


            var bills = await officeService.AllBillsByUserId("004bb11b-754a-422d-917b-27729dd1af3c");

            Assert.Multiple(() =>
            {
                Assert.That(bills.Any(), Is.True);
                Assert.That(bills.Count, Is.EqualTo(1));
                Assert.That(bills.First().TotalPrice, Is.EqualTo(100));
            });
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
