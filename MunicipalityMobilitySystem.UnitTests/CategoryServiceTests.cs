using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MunicipalityMobilitySystem.Core.Contracts.Category;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Category;
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

namespace MunicipalityMobilitySystem.UnitTests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private IRepository repo;
        private ICategoryService categoryService;
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
        public async Task AllCategoriesShuldRetutnAllCategoriesCountInDbCorrectly()
        {
            repo = new Repository(applicationDbContext);
            categoryService = new CategoryService(repo);

            var dbCategories = await categoryService.AllCategories();

            Assert.That(dbCategories.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task AllCategoriesShuldRetutnAllCategoriesInDbCorrectly()
        {
            repo = new Repository(applicationDbContext);
            categoryService = new CategoryService(repo);

            var seededCategory = new VehicleParkServiceModel()
            {
                Id = 1,
                Name = "Bike"
            };

            var seededCategory2 = new VehicleParkServiceModel()
            {
                Id = 2,
                Name = "Scooter"
            };

            var seededCategory3 = new VehicleParkServiceModel()
            {
                Id = 3,
                Name = "Car"
            };

            var dbCategories = await categoryService.AllCategories();

            Assert.IsTrue(dbCategories.First().Id == seededCategory.Id);
            Assert.IsTrue(dbCategories.First().Name == seededCategory.Name);


            Assert.IsTrue(dbCategories.Skip(1).First().Id == seededCategory2.Id);
            Assert.IsTrue(dbCategories.Skip(1).First().Name == seededCategory2.Name);

            Assert.IsTrue(dbCategories.Skip(2).First().Id == seededCategory3.Id);
            Assert.IsTrue(dbCategories.Skip(2).First().Name == seededCategory3.Name);
        }

        [Test]
        public async Task AllCategoryServiceNamesShouldReturnCorrectNames()
        {
            repo = new Repository(applicationDbContext);
            categoryService = new CategoryService(repo);

            var dbCategoryNames = await categoryService.AllCategoriesNames();

            Assert.IsTrue(dbCategoryNames.First() == "Bike");
            Assert.IsTrue(dbCategoryNames.Skip(1).First() == "Scooter");
            Assert.IsTrue(dbCategoryNames.Skip(2).First() == "Car");
        }

        //[Test]
        //public async Task TestLast3HousesInMemory()
        //{
        //    var loggerMock = new Mock<ILogger<HouseService>>();
        //    logger = loggerMock.Object;
        //    var repo = new Repository(applicationDbContext);
        //    houseService = new HouseService(repo, guard, logger);

        //    await repo.AddRangeAsync(new List<House>()
        //    {
        //        new House() { Id = 1, Address = "", ImageUrl = "", Title = "", Description = "" },
        //        new House() { Id = 3, Address = "", ImageUrl = "", Title = "", Description = "" },
        //        new House() { Id = 5, Address = "", ImageUrl = "", Title = "", Description = "" },
        //        new House() { Id = 2, Address = "", ImageUrl = "", Title = "", Description = "" }
        //    });

        //    await repo.SaveChangesAsync();
        //    var hoseCollection = await houseService.LastThreeHouses();

        //    Assert.That(3, Is.EqualTo(hoseCollection.Count()));
        //    Assert.That(hoseCollection.Any(h => h.Id == 1), Is.False);
        //}

        //[Test]
        //public async Task TestLast3HousesNumberAndOrder()
        //{
        //    var loggerMock = new Mock<ILogger<HouseService>>();
        //    logger = loggerMock.Object;
        //    var repoMock = new Mock<IRepository>();
        //    IQueryable<House> houses = new List<House>()
        //    {
        //        new House() { Id = 1 },
        //        new House() { Id = 3 },
        //        new House() { Id = 5 },
        //        new House() { Id = 2 }
        //    }.AsQueryable();
        //    repoMock.Setup(r => r.AllReadonly<House>())
        //        .Returns(houses);
        //    repo = repoMock.Object;
        //    houseService = new HouseService(repo, guard, logger);

        //    var hoseCollection = await houseService.LastThreeHouses();

        //    Assert.That(3, Is.EqualTo(hoseCollection.Count()));
        //    Assert.That(hoseCollection.Any(h => h.Id == 1), Is.False);
        //}

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
