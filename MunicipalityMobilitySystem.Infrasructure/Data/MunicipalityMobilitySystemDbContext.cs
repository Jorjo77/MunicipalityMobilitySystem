using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;

namespace MunicipalityMobilitySystem.Data
{
    public class MunicipalityMobilitySystemDbContext : IdentityDbContext
    {
        public MunicipalityMobilitySystemDbContext(DbContextOptions<MunicipalityMobilitySystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<VehiclePark> VehicleParks { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Category> Categorys { get; set; } = null!;
        public DbSet<RepairCenter> RepairCenters { get; set; } = null!;
        private IdentityUser GuestUser { get; set; } = null!;
        private Category Bike { get; set; } = null!;
        private Category Scooter { get; set; } = null!;
        private Category Car { get; set; } = null!;
        private VehiclePark CentralPark { get; set; } = null!;
        private VehiclePark EasternPark { get; set; } = null!;
        private VehiclePark WesternPark { get; set; } = null!;
        private Vehicle FirstScooter { get; set; } = null!;
        private Vehicle SecondScooter { get; set; } = null!;
        private Vehicle ThirdScooter { get; set; } = null!;
        private Vehicle FirstBike { get; set; } = null!;
        private Vehicle SecondBike { get; set; } = null!;
        private Vehicle ThirdBike { get; set; } = null!;
        private Vehicle FirstCar { get; set; } = null!;
        private Vehicle SecondCar { get; set; } = null!;
        private Vehicle ThirdCar { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedUser();
            builder.Entity<IdentityUser>()
                .HasData(this.GuestUser);

            SeedCategories();
            builder.Entity<Category>()
                .HasData(this.Bike,
                this.Scooter,
                this.Car);

            SeedVehiclePark();
            builder.Entity<VehiclePark>()
                .HasData(this.CentralPark,
                this.EasternPark,
                this.WesternPark);

            SeedScooters();
            builder.Entity<Vehicle>()
                .HasData(this.FirstScooter,
                this.SecondScooter,
                this.ThirdScooter);

            SeedBikes();
            builder.Entity<Vehicle>()
                .HasData(this.FirstBike,
                this.SecondBike,
                this.ThirdBike);

            SeedCars();
            builder.Entity<Vehicle>()
                .HasData(this.FirstCar,
                this.SecondCar,
                this.ThirdCar);

            base.OnModelCreating(builder);
        }

        private void SeedUser()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            this.GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            this.GuestUser.PasswordHash =
            hasher.HashPassword(this.GuestUser, "guest123");
        }
        private void SeedCategories()
        {
            this.Bike = new Category()
            {
                Id = 1,
                Name = "Bike"
            };

            this.Scooter = new Category()
            {
                Id = 2,
                Name = "Scooter"
            };

            this.Car = new Category()
            {
                Id = 3,
                Name = "Car"
            };
        }

        private void SeedVehiclePark()
        {
            this.CentralPark = new VehiclePark()
            {
                Id = 1,
                Name = "Eastern Park", 
                Adress = "Bulgaria Sofia City Mladost 4",
                Email = "eastern_rent@abv.bg",
                Phone = "+359878128343", 
                ImageUrl = "https://travelwest.info/app/uploads/2022/04/Portway-Park-Ride-Car-Park-1349x900.jpg.webp",
                Description = "Your eastern oportunity to find out the best ranting offer!"
            };
            this.EasternPark = new VehiclePark()
            {
                Id = 2,
                Name = "Central Park",
                Adress = "Bulgaria Sofia City Iskar Str. 36",
                Email = "central_rent@abv.bg",
                Phone = "+359878128344",
                ImageUrl = "https://s.driving-tests.org/wp-content/uploads/2012/02/back-parking.webp",
                Description = "Your central oportunity to find out the best ranting offer!"
            };
            this.WesternPark = new VehiclePark()
            {
                Id = 3,
                Name = "Western Park",
                Adress = "Bulgaria Sofia City Lulin 2",
                Email = "estern_rent@abv.bg",
                Phone = "+359878128345",
                ImageUrl = "https://d193ppza2qrruo.cloudfront.net/production/images/Multi-storey-car-park-tips.jpg",
                Description = "Your western oportunity to find out the best ranting offer!",
            };
        }
        private void SeedScooters()
        {
            this.FirstScooter = new Vehicle()
            {
                Id = 1,
                RegistrationNumber = "Sk000001",
                EngineType = "Electric",
                Model = "Piaggo",
                Rating = 5,
                PricePerHour = 11.00M,
                CategoryId = this.Scooter.Id,
                VehicleParkId = 2,
                ImageUrl = "https://bg.e-scooter.co/i/17/72/ed/d5015b9723a5397c924e7b797d.jpg",
                Description = "Exellent transport solution for a city center.",
                RenterId = this.GuestUser.Id,

            };

            this.SecondScooter = new Vehicle()
            {
                Id = 2,
                RegistrationNumber = "Sk000002",
                EngineType = "Petrol",
                Model = "Piaggo",
                Rating = 5,
                PricePerHour = 10.00M,
                CategoryId = this.Scooter.Id,
                VehicleParkId = 1,
                ImageUrl = "https://images.piaggio.com/piaggio/vehicles/nclp000u15/nclp8znu15/nclp8znu15-01-s.png",
                Description = "A realy good transport solution for a city.",
                RenterId = this.GuestUser.Id,
            };
            this.ThirdScooter = new Vehicle()
            {
                Id = 3,
                RegistrationNumber = "Sk000003",
                EngineType = "Petrol",
                Model = "Vespa",
                Rating = 6,
                PricePerHour = 9.00M,
                CategoryId = this.Scooter.Id,
                VehicleParkId = 3,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4TbIp4RJgECS2py-M_zNjwLrXYIbcZ07XQA&usqp=CAU",
                Description = "A very good transport solution for a city and center.",
                RenterId = this.GuestUser.Id,
            };
        }

        private void SeedBikes()
        {
            this.FirstBike = new Vehicle()
            {
                Id = 4,
                RegistrationNumber = "B000001",
                Model = "Passati",
                Rating = 4,
                PricePerHour = 4.00M,
                CategoryId = this.Bike.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.home-max.bg/static/media/ups/cached/781e8afa44a58ec261abdd83455444f5c203f4c5.jpg",
                Description = "A very good transport solution for sport people.",
                RenterId = null,
            };
            this.SecondBike = new Vehicle()
            {
                Id = 5,
                RegistrationNumber = "B000002",
                Model = "Pinarello",
                Rating = 6,
                PricePerHour = 7.00M,
                CategoryId = this.Bike.Id,
                VehicleParkId = 2,
                ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/pinarello-dogma-f-tested-1624463882.jpg?crop=1.00xw:0.807xh;0,0.0629xh&resize=2048:*",
                Description = "A very good luxury transport solution for beasy people.",
                RenterId = null,

            };
            this.ThirdBike = new Vehicle()
            {
                Id = 6,
                RegistrationNumber = "B000003",
                Model = "Cross",
                Rating = 5,
                PricePerHour = 5.00M,
                CategoryId = this.Bike.Id,
                VehicleParkId = 3,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuinQIdRNjDVnCddYQFkMkFIkt3cyXVfVqPA&usqp=CAU",
                Description = "A realy good transport solution for sport people.",
                RenterId = null,
            };
        }
        private void SeedCars()
        {
            this.FirstCar = new Vehicle()
            {
                Id = 7,
                RegistrationNumber = "C000001",
                EngineType = "Electric",
                Model = "Hynday EON",
                Rating = 4,
                PricePerHour = 20.00M,
                CategoryId = this.Car.Id,
                VehicleParkId = 1,
                ImageUrl = "https://imgd.aeplcdn.com/1056x594/cw/ec/9692/Hyundai-Eon-Right-Front-Three-Quarter-94097.jpg?v=201711021421&q=75&wm=1",
                Description = "A very good and transport solution for a city center.",
                RenterId = null,
            };
            this.SecondCar = new Vehicle()
            {
                Id = 8,
                RegistrationNumber = "C000002",
                EngineType = "Diesel",
                Model = "VW Touran",
                Rating = 5,
                PricePerHour = 23.00M,
                CategoryId = this.Car.Id,
                VehicleParkId = 2,
                ImageUrl = "https://www.topgear.com/sites/default/files/cars-car/carousel/2016/03/vw_7422.jpg?w=976&h=549",
                Description = "A realy good and transport solution for a big family.",
                RenterId = null,
            };
            this.ThirdCar = new Vehicle()
            {
                Id = 9,
                RegistrationNumber = "C000003",
                EngineType = "Petrol",
                Model = "Mercedes CLS 180",
                Rating = 6,
                PricePerHour = 25.00M,
                CategoryId = this.Car.Id,
                VehicleParkId = 3,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU",
                Description = "A realy good and luxury transport solution.",
                RenterId = null,
            };
        }
    }
}