using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Models.VehiclePark;
using MunicipalityMobilitySystem.Core.Services;
using MunicipalityMobilitySystem.Data;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;

namespace MunicipalityMobilitySystem.UnitTests
{
    [TestFixture]
    public class VehicleParkServiceTests
    {
        private IRepository repo;
        private ILogger<VehicleParkService> logger;
        private IVehicleParkService vehicleParkService;
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
        public async Task AllVehicleParksShuldRetutnAllVehicleParksCountInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<VehicleParkService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            vehicleParkService = new VehicleParkService(repo, logger);

            var dbVehicleParks = await vehicleParkService.AllVehicleParks();

            Assert.That(dbVehicleParks.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task AllVehicleParksShuldRetutnVehicleParksInDbCorrectly()
        {
            var mokedLogger = new Mock<ILogger<VehicleParkService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            vehicleParkService = new VehicleParkService(repo, logger);

            var seededVehiclePark = new VehicleParkDetailsModel()
            {
                Id = 1,
                Name = "Central Park",
                Adress = "Bulgaria Sofia City Iskar Str. 36",
                Email = "central_rent@abv.bg",
                Phone = "+359878128343",
                ImageUrl = "https://travelwest.info/app/uploads/2022/04/Portway-Park-Ride-Car-Park-1349x900.jpg.webp",
                Description = "Your central oportunity to find out the best ranting offer!"
            };

            var seededVehiclePark2 = new VehicleParkDetailsModel()
            { 
                Id = 2,
                Name = "Eastern Park",
                Adress = "Bulgaria Sofia City Mladost 4",
                Email = "eastern_rent@abv.bg",
                Phone = "+359878128344",
                ImageUrl = "https://s.driving-tests.org/wp-content/uploads/2012/02/back-parking.webp",
                Description = "Your eastern oportunity to find out the best ranting offer!"
            };

            var seededVehiclePark3 = new VehicleParkDetailsModel()
            {
                Id = 3,
                Name = "Western Park",
                Adress = "Bulgaria Sofia City Lulin 2",
                Email = "western_rent@abv.bg",
                Phone = "+359878128345",
                ImageUrl = "https://d193ppza2qrruo.cloudfront.net/production/images/Multi-storey-car-park-tips.jpg",
                Description = "Your western oportunity to find out the best ranting offer!",
            };

            var dbVehicleParks = await vehicleParkService.AllVehicleParks();

            Assert.IsTrue(dbVehicleParks.First().Id == seededVehiclePark.Id);
            Assert.IsTrue(dbVehicleParks.First().Name == seededVehiclePark.Name);
            Assert.IsTrue(dbVehicleParks.First().Adress == seededVehiclePark.Adress);
            Assert.IsTrue(dbVehicleParks.First().Email == seededVehiclePark.Email);
            Assert.IsTrue(dbVehicleParks.First().Phone == seededVehiclePark.Phone);
            Assert.IsTrue(dbVehicleParks.First().ImageUrl == seededVehiclePark.ImageUrl);
            Assert.IsTrue(dbVehicleParks.First().Description == seededVehiclePark.Description);

            Assert.IsTrue(dbVehicleParks.Skip(1).First().Id == seededVehiclePark2.Id);
            Assert.IsTrue(dbVehicleParks.Skip(1).First().Name == seededVehiclePark2.Name);
            Assert.IsTrue(dbVehicleParks.Skip(1).First().Adress == seededVehiclePark2.Adress);
            Assert.IsTrue(dbVehicleParks.Skip(1).First().Email == seededVehiclePark2.Email);
            Assert.IsTrue(dbVehicleParks.Skip(1).First().Phone == seededVehiclePark2.Phone);
            Assert.IsTrue(dbVehicleParks.Skip(1).First().ImageUrl == seededVehiclePark2.ImageUrl);
            Assert.IsTrue(dbVehicleParks.Skip(1).First().Description == seededVehiclePark2.Description);

            Assert.IsTrue(dbVehicleParks.Skip(2).First().Id == seededVehiclePark3.Id);         
            Assert.IsTrue(dbVehicleParks.Skip(2).First().Name == seededVehiclePark3.Name);       
            Assert.IsTrue(dbVehicleParks.Skip(2).First().Adress == seededVehiclePark3.Adress);     
            Assert.IsTrue(dbVehicleParks.Skip(2).First().Email == seededVehiclePark3.Email);      
            Assert.IsTrue(dbVehicleParks.Skip(2).First().Phone == seededVehiclePark3.Phone);      
            Assert.IsTrue(dbVehicleParks.Skip(2).First().ImageUrl == seededVehiclePark3.ImageUrl);   
            Assert.IsTrue(dbVehicleParks.Skip(2).First().Description == seededVehiclePark3.Description);
        }

        [Test]
        public async Task AllVehiclesByVehicleParkIdShouldReturnCorrectVehiclesNumber()
        {

            var mokedLogger = new Mock<ILogger<VehicleParkService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);
            
            vehicleParkService = new VehicleParkService(repo, logger);

            var vehiclesInDBinVehiclePark1 = await vehicleParkService.AllVehiclesByVehicleParkId(1);
            var vehiclesInDBinVehiclePark2 = await vehicleParkService.AllVehiclesByVehicleParkId(2);
            var vehiclesInDBinVehiclePark3 = await vehicleParkService.AllVehiclesByVehicleParkId(3);

            Assert.That(vehiclesInDBinVehiclePark1.TotalVehiclesCount, Is.EqualTo(3));
            Assert.That(vehiclesInDBinVehiclePark2.TotalVehiclesCount, Is.EqualTo(3));
            Assert.That(vehiclesInDBinVehiclePark3.TotalVehiclesCount, Is.EqualTo(3));
        }

        [Test]

        public async Task CreateShouldMakeAndSaveNewCorrectVehiclePark()
        {
            var mokedLogger = new Mock<ILogger<VehicleParkService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            vehicleParkService = new VehicleParkService(repo, logger);

            await vehicleParkService.Create(new VehicleParkDetailsModel()
            {
                Name = "TestName",
                Adress = "TestAdress",
                ImageUrl = "TestImageUrl",
                Phone = "TestPhone",
                Email = "TestEmail",
                Description = "This vehicle park is created",
            });

            var createdVehiclePark = await vehicleParkService.VehicleParkDetailsById(4);

            Assert.That(createdVehiclePark.Description, Is.EqualTo("This vehicle park is created"));
            Assert.That(createdVehiclePark.Name, Is.EqualTo("TestName"));
            Assert.That(createdVehiclePark.Adress, Is.EqualTo("TestAdress"));
            Assert.That(createdVehiclePark.ImageUrl, Is.EqualTo("TestImageUrl"));
            Assert.That(createdVehiclePark.Phone, Is.EqualTo("TestPhone"));
            Assert.That(createdVehiclePark.Email, Is.EqualTo("TestEmail"));
        }

        [Test]
        public async Task DeleteShouldRemoveVehicleParkFromDB()
        {
            var mokedLogger = new Mock<ILogger<VehicleParkService>>();
            logger = mokedLogger.Object;

            repo = new Repository(applicationDbContext);

            vehicleParkService = new VehicleParkService(repo, logger);

            await vehicleParkService.Delete(1);

            var vehicleParksInMemory = await vehicleParkService.AllVehicleParks();

            Assert.That(vehicleParksInMemory.Count(), Is.EqualTo(2));

            await vehicleParkService.Delete(2);

            vehicleParksInMemory = await vehicleParkService.AllVehicleParks();

            Assert.That(vehicleParksInMemory.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task EditShouldChangeCorrectVP()
        {
            var mokedLogger = new Mock<ILogger<VehicleParkService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            vehicleParkService = new VehicleParkService(repo, logger);

            var model = new VehicleParkDetailsModel()
            {
                Id = 1,
                Name = "TestName",
                Adress = "TestAdress",
                ImageUrl = "TestImageUrl",
                Phone = "TestPhone",
                Email = "TestEmail",
                Description = "This vehicle park is edited"
            };

            await vehicleParkService.EditVehiclePark(1, model);

            var editedVehiclePark = await vehicleParkService.VehicleParkDetails(1);

            Assert.That(editedVehiclePark.Name, Is.EqualTo("TestName"));
            Assert.That(editedVehiclePark.Adress, Is.EqualTo("TestAdress"));
            Assert.That(editedVehiclePark.ImageUrl, Is.EqualTo("TestImageUrl"));
            Assert.That(editedVehiclePark.Phone, Is.EqualTo("TestPhone"));
            Assert.That(editedVehiclePark.Email, Is.EqualTo("TestEmail"));
            Assert.That(editedVehiclePark.Description, Is.EqualTo("This vehicle park is edited"));
        }

        [Test]
        public async Task ExistsShouldReturnCorrectCondition()
         {
            var mokedLogger = new Mock<ILogger<VehicleParkService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            vehicleParkService = new VehicleParkService(repo, logger);

            Assert.That(await vehicleParkService.Exists(1), Is.True);
            Assert.That(await vehicleParkService.Exists(2), Is.True);
            Assert.That(await vehicleParkService.Exists(3), Is.True);
            Assert.That(await vehicleParkService.Exists(4), Is.False);
        }

        [Test]
        public async Task ExistsByNameEmailAndDescriptionShouldReturnCorrectCondition()
        {
            var mokedLogger = new Mock<ILogger<VehicleParkService>>();
            logger = mokedLogger.Object;
            repo = new Repository(applicationDbContext);

            vehicleParkService = new VehicleParkService(repo, logger);

            Assert.That(await vehicleParkService.VehiceParkExistsByNameEmailAndDescription("North park", "park@abv.bg", "Your best northen possibility for renting a vehicle!"), Is.False);
            Assert.That(await vehicleParkService.VehiceParkExistsByNameEmailAndDescription("Test", "", ""), Is.False);
            Assert.That(await vehicleParkService.VehiceParkExistsByNameEmailAndDescription("Western Park", "western_rent@abv.bg", "Your western oportunity to find out the best ranting offer!"), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
