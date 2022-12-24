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
        private IdentityUser GuestUser { get; set; } = null!;
        private Category Bike { get; set; } = null!;
        private Category Scooter { get; set; } = null!;
        private Category Car { get; set; } = null!;
        private VehiclePark CentralPark { get; set; } = null!;
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
                .HasData(this.CentralPark);

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
                Name = "Central", 
                Adress = "Bulgaria, Sofia City, Iskar Str. 36",
                Email = "vehicles_for_rent@abv.bg",
                Phone = "+359878128344"
            };
        }
        private void SeedScooters()
        {
            this.FirstScooter = new Vehicle()
            {
                Id = 1,
                EngineType = "Electric",
                Model = "Piaggo",
                Rating = 5,
                PricePerHour = 11.00M,
                CategoryId = this.Scooter.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fbg.e-scooter.co%2Fi%2F17%2F72%2Fed%2Fd5015b9723a5397c924e7b797d.jpg&imgrefurl=https%3A%2F%2Fbg.e-scooter.co%2Fpiaggio-one-active%2F&tbnid=yaQ2lq0vl1LETM&vet=12ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygZegUIARCZAg..i&docid=LeZmqaBlOwjRIM&w=474&h=415&q=Piaggio&ved=2ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygZegUIARCZAg",
                Description = "Exellent transport solution for a city center.",
                RenterId = this.GuestUser.Id,

            };

            this.SecondScooter = new Vehicle()
            {
                Id = 2,
                EngineType = "Petrol",
                Model = "Piaggo",
                Rating = 5,
                PricePerHour = 10.00M,
                CategoryId = this.Scooter.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fimages.piaggio.com%2Fpiaggio%2Fvehicles%2Fnclp000u15%2Fnclp8znu15%2Fnclp8znu15-01-s.png&imgrefurl=https%3A%2F%2Fwww.piaggio.com%2Fbg_BG%2Fmodels%2Fliberty%2Fliberty-50-4s3v-2021%2F&tbnid=dIb-qyhP2vh5mM&vet=12ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygFegUIARDsAQ..i&docid=un13zXQdXG3kwM&w=750&h=500&q=Piaggio&ved=2ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygFegUIARDsAQ",
                Description = "A realy good transport solution for a city center.",
                RenterId = this.GuestUser.Id,
            };
            this.ThirdScooter = new Vehicle()
            {
                Id = 3,
                EngineType = "Petrol",
                Model = "Vespa",
                Rating = 6,
                PricePerHour = 9.00M,
                CategoryId = this.Scooter.Id,
                VehicleParkId = 1,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4TbIp4RJgECS2py-M_zNjwLrXYIbcZ07XQA&usqp=CAU",
                Description = "A very good transport solution for a city center.",
                RenterId = this.GuestUser.Id,
            };
        }

        private void SeedBikes()
        {
            this.FirstBike = new Vehicle()
            {
                Id = 4,
                Model = "Passati",
                Rating = 4,
                PricePerHour = 4.00M,
                CategoryId = this.Bike.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.home-max.bg%2Fstatic%2Fmedia%2Fups%2Fcached%2F781e8afa44a58ec261abdd83455444f5c203f4c5.jpg&imgrefurl=https%3A%2F%2Fwww.home-max.bg%2Fvelosiped-passati-26-mtb-3700%2F&tbnid=kA6ZVlURPKhh4M&vet=12ahUKEwj8q-zhyYX8AhXlxwIHHRaND0gQMygBegUIARC1AQ..i&docid=CRixMubXhzLYzM&w=640&h=480&q=Passati&ved=2ahUKEwj8q-zhyYX8AhXlxwIHHRaND0gQMygBegUIARC1AQ",
                Description = "A very good transport solution for sport people.",
                RenterId = null,
            };
            this.SecondBike = new Vehicle()
            {
                Id = 5,
                Model = "Pinarello",
                Rating = 6,
                PricePerHour = 7.00M,
                CategoryId = this.Bike.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fhips.hearstapps.com%2Fhmg-prod%2Fimages%2Fpinarello-dogma-f-tested-1624463882.jpg&imgrefurl=https%3A%2F%2Fwww.bicycling.com%2Fbikes-gear%2Fa36815265%2Fpinarello-dogma-f-review%2F&tbnid=gkQMZzUwYV_bTM&vet=12ahUKEwjNk57LyYX8AhXdxgIHHYRAAgwQMygBegUIARDdAQ..i&docid=w0vXcmsF9jyIAM&w=7030&h=4912&q=Pinarello&ved=2ahUKEwjNk57LyYX8AhXdxgIHHYRAAgwQMygBegUIARDdAQ",
                Description = "A very good luxury transport solution for beasy people.",
                RenterId = null,

            };
            this.ThirdBike = new Vehicle()
            {
                Id = 6,
                Model = "Cross",
                Rating = 5,
                PricePerHour = 5.00M,
                CategoryId = this.Bike.Id,
                VehicleParkId = 1,
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
                EngineType = "Electric",
                Model = "Hynday EON",
                Rating = 4,
                PricePerHour = 20.00M,
                CategoryId = this.Car.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Ffichasmotor.com%2Fimages%2Fhyundai%2Fhyundai-eon-0-8-56-cv.webp&imgrefurl=https%3A%2F%2Ffichasmotor.com%2Fen%2Fhyundai%2Fhyundai-eon-0-8-56-cv%2F&tbnid=b5rmBwPhiJED7M&vet=12ahUKEwjonf6Hy4X8AhXSQeUKHaRRCAsQMygTegUIARCHAg..i&docid=VCMCK7OUZxeDiM&w=960&h=542&q=Hynday%20EON&ved=2ahUKEwjonf6Hy4X8AhXSQeUKHaRRCAsQMygTegUIARCHAg",
                Description = "A very good and transport solution for a city center.",
                RenterId = null,
            };
            this.SecondCar = new Vehicle()
            {
                Id = 8,
                EngineType = "Diesel",
                Model = "VW Touran",
                Rating = 5,
                PricePerHour = 23.00M,
                CategoryId = this.Car.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fm.atcdn.co.uk%2Fect%2Fmedia%2Fw1920%2Fbrand-store%2Fvolkswagen%2Ftouran%2Fhero.jpg&imgrefurl=https%3A%2F%2Fwww.autotrader.co.uk%2Fcars%2Fuk%2Fvolkswagen%2Ftouran&tbnid=iBeoqxiXOpMDuM&vet=12ahUKEwjsp8L6y4X8AhV0_rsIHYlCCyMQMygJegUIARDxAQ..i&docid=C8aG3aQ2P98X8M&w=1920&h=980&q=VW%20Touran&ved=2ahUKEwjsp8L6y4X8AhV0_rsIHYlCCyMQMygJegUIARDxAQ",
                Description = "A realy good and transport solution for a big family.",
                RenterId = null,
            };
            this.ThirdCar = new Vehicle()
            {
                Id = 9,
                EngineType = "Petrol",
                Model = "Mercedes CLS 180",
                Rating = 6,
                PricePerHour = 25.00M,
                CategoryId = this.Car.Id,
                VehicleParkId = 1,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU",
                Description = "A realy good and luxury transport solution.",
                RenterId = null,
            };
        }
    }
}