using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using System;

namespace MunicipalityMobilitySystem.Data
{
    public class MunicipalityMobilitySystemDbContext : IdentityDbContext
    {
        public MunicipalityMobilitySystemDbContext(DbContextOptions<MunicipalityMobilitySystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<VehiclePark> VehicleParks { get; set; } = null!;
        public DbSet<Scooter> Scooters { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Truck> Trucks { get; set; } = null!;
        public DbSet<Bike> Bikes { get; set; } = null!;
        public DbSet<Category> Categorys { get; set; } = null!;

        private IdentityUser GuestUser { get; set; } = null!;
        private Category SmallCategory { get; set; } = null!;
        private Category MiddleCategory { get; set; } = null!;
        private Category LargeCategory { get; set; } = null!;
        private VehiclePark CentralPark { get; set; } = null!;
        private Scooter FirstScooter { get; set; } = null!;
        private Scooter SecondScooter { get; set; } = null!;
        private Scooter ThirdScooter { get; set; } = null!;
        private Bike FirstBike { get; set; } = null!;
        private Bike SecondBike { get; set; } = null!;
        private Bike ThirdBike { get; set; } = null!;
        private Car FirstCar { get; set; } = null!;
        private Car SecondCar { get; set; } = null!;
        private Car ThirdCar { get; set; } = null!;
        private Truck FirstTruck { get; set; } = null!;
        private Truck SecondTruck { get; set; } = null!;
        private Truck ThirdTruck { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedUser();
            builder.Entity<IdentityUser>()
                .HasData(this.GuestUser);

            SeedCategories();
            builder.Entity<Category>()
                .HasData(this.SmallCategory,
                this.MiddleCategory,
                this.LargeCategory);

            SeedVehiclePark();
            builder.Entity<VehiclePark>()
                .HasData(this.CentralPark);

            SeedScooters();
            builder.Entity<Scooter>()
                .HasData(this.FirstScooter,
                this.SecondScooter,
                this.ThirdScooter);

            SeedBikes();
            builder.Entity<Bike>()
                .HasData(this.FirstBike,
                this.SecondBike,
                this.ThirdBike);

            SeedCars();
            builder.Entity<Car>()
                .HasData(this.FirstCar,
                this.SecondCar,
                this.ThirdCar);

            SeedTrucks();
            builder.Entity<Truck>()
                .HasData(this.FirstTruck,
                this.SecondTruck,
                this.ThirdTruck
                );

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
            this.SmallCategory = new Category()
            {
                Id = 1,
                Name = "Small"
            };

            this.MiddleCategory = new Category()
            {
                Id = 2,
                Name = "Middle"
            };

            this.LargeCategory = new Category()
            {
                Id = 3,
                Name = "Large"
            };
        }

        private void SeedVehiclePark()
        {
            this.CentralPark = new VehiclePark()
            {
                Id = 1,
                ParkName = "Central"
            };
        }
        private void SeedScooters()
        {
            this.FirstScooter = new Scooter()
            {
                Id = 1,
                EngineType = "Petrol",
                Type = "Vespa",
                Rating = 6,
                PricePerHour = 9.00M,
                CategoryId = this.SmallCategory.Id,
                VehicleParkId = 1,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4TbIp4RJgECS2py-M_zNjwLrXYIbcZ07XQA&usqp=CAU",
                Description = "A very good transport solution for a city center.",
                RenterId = this.GuestUser.Id,
            };

            this.SecondScooter = new Scooter()
            {
                Id = 2,
                EngineType = "Petrol",
                Type = "Piaggo",
                Rating = 5,
                PricePerHour = 10.00M,
                CategoryId = this.SmallCategory.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fcdn.motor1.com%2Fimages%2Fmgl%2FP3GnXX%2Fs3%2F2022-vespa-elettrica-red---main.jpg&imgrefurl=https%3A%2F%2Fwww.rideapart.com%2Fnews%2F562600%2Fvespa-brand-906million-euros%2F&tbnid=CPQTR3BmwOmqPM&vet=12ahUKEwiTi8mXn4P8AhUYxgIHHRheDBwQMygQegUIARDWAQ..i&docid=oNKLqZ2kpDMT7M&w=1280&h=720&q=Piaggo&ved=2ahUKEwiTi8mXn4P8AhUYxgIHHRheDBwQMygQegUIARDWAQ",
                Description = "A realy good transport solution for a city center.",
                RenterId = this.GuestUser.Id,
            };
            this.ThirdScooter = new Scooter()
            {
                Id = 3,
                EngineType = "Electric",
                Type = "Piaggo",
                Rating = 5,
                PricePerHour = 11.00M,
                CategoryId = this.MiddleCategory.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fbg.e-scooter.co%2Fi%2F96%2F0c%2F0a%2F95d8f798a27fb6ad77c11b8ec2.jpg&imgrefurl=https%3A%2F%2Fbg.e-scooter.co%2Fpiaggio-one%2F&tbnid=5Mt_ltA3Pdl3sM&vet=12ahUKEwiTi8mXn4P8AhUYxgIHHRheDBwQMygBegUIARC3AQ..i&docid=zsJorUwAg6RoyM&w=753&h=771&q=Piaggo&ved=2ahUKEwiTi8mXn4P8AhUYxgIHHRheDBwQMygBegUIARC3AQ",
                Description = "Exellent transport solution for a city center.",
                RenterId = this.GuestUser.Id,
            };
        }

        private void SeedBikes()
        {
            this.FirstBike = new Bike()
            {
                Id = 1,
                Type = "Passati",
                Rating = 4,
                PricePerHour = 4.00M,
                CategoryId = this.MiddleCategory.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.home-max.bg%2Fstatic%2Fmedia%2Fups%2Fproducts%2Fmain%2F06054168_y.JPG%3Fv%3D0.31&imgrefurl=https%3A%2F%2Fwww.home-max.bg%2Faluminiev-mtb-velosiped-passati-24%2F&tbnid=2yQM2U2uluMNsM&vet=12ahUKEwiCgv78nYP8AhWFIMUKHXm7AhMQMygGegUIARDNAQ..i&docid=18h343pFLn71EM&w=4613&h=2843&q=Passaty&ved=2ahUKEwiCgv78nYP8AhWFIMUKHXm7AhMQMygGegUIARDNAQ",
                Description = "A very good transport solution for sport people.",
                RenterId = null,
            };
            this.SecondBike = new Bike()
            {
                Id = 2,
                Type = "Cross",
                Rating = 5,
                PricePerHour = 5.00M,
                CategoryId = this.MiddleCategory.Id,
                VehicleParkId = 1,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuinQIdRNjDVnCddYQFkMkFIkt3cyXVfVqPA&usqp=CAU",
                Description = "A realy good transport solution for sport people.",
                RenterId = null,
            };
            this.ThirdBike = new Bike()
            {
                Id = 3,
                Type = "Pinarello",
                Rating = 6,
                PricePerHour = 7.00M,
                CategoryId = this.MiddleCategory.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fcyclist.b-cdn.net%2Fsites%2Fcyclist%2Ffiles%2Fstyles%2Farticle_main_wide_image%2Fpublic%2F2021%2F11%2Fpinarello-dogma-f-1.jpg%3Fitok%3DhYRlGtTu&imgrefurl=https%3A%2F%2Fwww.cyclist.co.uk%2Fin-depth%2F10256%2Fwhat-is-a-road-bike&tbnid=_oCCGbIDpZdqDM&vet=12ahUKEwihuZSjnoP8AhUBtaQKHckKCJ4QMygDegUIARDMAQ..i&docid=zcxxLnqOLHXrGM&w=1240&h=698&q=road%20bike&ved=2ahUKEwihuZSjnoP8AhUBtaQKHckKCJ4QMygDegUIARDMAQ",
                Description = "A very good luxury transport solution for beasy people.",
                RenterId = null,
            };
        }
        private void SeedCars()
        {
            this.FirstCar = new Car()
            {
                Id = 1,
                EngineType = "Petrol",
                Type = "Mercedes CLS 180",
                Rating = 6,
                PricePerHour = 25.00M,
                CategoryId = this.MiddleCategory.Id,
                VehicleParkId = 1,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU",
                Description = "A realy good and luxury transport solution.",
                RenterId = null,
            };
            this.SecondCar = new Car()
            {
                Id = 2,
                EngineType = "Diesel",
                Type = "VW Touran",
                Rating = 5,
                PricePerHour = 23.00M,
                CategoryId = this.LargeCategory.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fkolalok.com%2Fnewimage%2Fsmall%2F2015-touran-ii-volkswagen.jpg&imgrefurl=https%3A%2F%2Fkolalok.com%2Fgabariti%2Fvolkswagen%2Ftouran.html&tbnid=vv3QuTgJq6H87M&vet=12ahUKEwicyeOinIP8AhXFwQIHHR6MAcIQMygNegUIARDbAQ..i&docid=Cv2JajDnUh_gbM&w=322&h=215&q=Wv%20toaran&ved=2ahUKEwicyeOinIP8AhXFwQIHHR6MAcIQMygNegUIARDbAQ",
                Description = "A realy good and transport solution for a big family.",
                RenterId = null,
            };
            this.ThirdCar = new Car()
            {
                Id = 3,
                EngineType = "Electric",
                Type = "Hynday EON",
                Rating = 4,
                PricePerHour = 20.00M,
                CategoryId = this.SmallCategory.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.ultimatespecs.com%2Fcargallery%2F67%2F4854%2Fw400_Hyundai-Eon-2.jpg&imgrefurl=https%3A%2F%2Fwww.ultimatespecs.com%2Fbg%2Fcar-specs%2FHyundai%2F14708%2FHyundai-Eon-08-MPi.html&tbnid=2p0LKtPnAW8CPM&vet=12ahUKEwjzidSanYP8AhWSNewKHTg5CxIQMygCegUIARC9AQ..i&docid=ZGGa2cS6QA17DM&w=400&h=225&itg=1&q=hunday%20eon&ved=2ahUKEwjzidSanYP8AhWSNewKHTg5CxIQMygCegUIARC9AQ",
                Description = "A very good and transport solution for a city center.",
                RenterId = null,
            };
        }
        private void SeedTrucks()
        {
            this.FirstTruck = new Truck()
            {
                Id = 1,
                EngineType = "Diesel",
                Type = "Scania",
                Rating = 5,
                PricePerHour = 40.00M,
                CategoryId = this.LargeCategory.Id,
                VehicleParkId = 1,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQb4pdFmd8vMzEsFxaFaonBFAQhs3EA2P9r_Q&usqp=CAU",
                Description = "A realy good transport solution for a big cargos.",
                RenterId = null,
            };
            this.SecondTruck = new Truck()
            {
                Id = 2,
                EngineType = "Diesel",
                Type = "Mercedes",
                Rating = 6,
                PricePerHour = 50.00M,
                CategoryId = this.LargeCategory.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.kamioni.bg%2Fpictures%2F29618_2_scania%2Bbev2-650.jpg&imgrefurl=https%3A%2F%2Fwww.kamioni.bg%2Fmenu%2F10%2Fpost%2F29618%2FScania-predstavq-nova-gama-e-kamioni-za-regionalen-transport&tbnid=jkhfmffUYxtEHM&vet=12ahUKEwjcu_iPmIP8AhW2lv0HHavxCNsQMygGegUIARDOAQ..i&docid=iugoRchY4ROK5M&w=650&h=438&q=Scania&ved=2ahUKEwjcu_iPmIP8AhW2lv0HHavxCNsQMygGegUIARDOAQ",
                Description = "Excelent transport solution for a big cargos.",
                RenterId = null,
            };
            this.ThirdTruck = new Truck()
            {
                Id = 3,
                EngineType = "Diesel",
                Type = "Volvo",
                Rating = 4,
                PricePerHour = 35.00M,
                CategoryId = this.LargeCategory.Id,
                VehicleParkId = 1,
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.volvotrucks.us%2F-%2Fmedia%2Fvtna%2Fimages%2Fshared%2Ftab-content%2Fvnl%2Ftabbed-feature%2Fvolvo-vnl-25th-aerodynamics.jpg%3Fh%3D410%26w%3D725%26rev%3D4a1b9e19a65e418ba2bcffc4b952005a%26hash%3D78C61F2B39C62E7464AAA1FC051487C0&imgrefurl=https%3A%2F%2Fwww.volvotrucks.us%2Ftrucks%2Fvnl%2F&tbnid=4lteSbMPeJB2jM&vet=12ahUKEwjSvPvKmYP8AhU5nP0HHaRzDFsQMygPegUIARDkAQ..i&docid=cXhpx2BnsyvK8M&w=725&h=410&q=volvo%20truck%202021&ved=2ahUKEwjSvPvKmYP8AhU5nP0HHaRzDFsQMygPegUIARDkAQ",
                Description = "A very good transport solution for a big cargos.",
                RenterId = null,
            };
        }
    }
}