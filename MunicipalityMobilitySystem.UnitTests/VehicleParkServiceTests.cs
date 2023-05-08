using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MunicipalityMobilitySystem.Core.Contracts.Category;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Category;
using MunicipalityMobilitySystem.Core.Models.VehiclePark;
using MunicipalityMobilitySystem.Core.Services;
using MunicipalityMobilitySystem.Data;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
