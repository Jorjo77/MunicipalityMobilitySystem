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

        //private IdentityUser GuestUser { get; set; }
        //private Category SmallCategory { get; set; }
        //private Category MiddleCategory { get; set; }
        //private Category LargeCategory { get; set; }
        //private Scooter FirstScooter { get; set; }
        //private Bike FirstBike { get; set; }
        //private Car FirstCar { get; set; }
        //private Truck FirstTruck { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //SeedUser();
            //builder.Entity<IdentityUser>()
            //    .HasData(this.GuestUser);

            //SeedCategories();
            //builder.Entity<Category>()
            //    .HasData(this.SmallCategory,
            //    this.MiddleCategory,
            //    this.LargeCategory);

            //SeedScooter();
            //builder.Entity<Scooter>()
            //    .HasData(this.FirstScooter);

            //SeedBike();
            //builder.Entity<Bike>()
            //    .HasData(this.FirstBike);

            //SeedCar();
            //builder.Entity<Car>()
            //    .HasData(this.FirstCar);

            //SeedTruck();
            //builder.Entity<Truck>()
            //    .HasData(this.FirstTruck);

            base.OnModelCreating(builder);
        }

        //private void SeedUser()
        //{
        //    var hasher = new PasswordHasher<IdentityUser>();

        //    this.GuestUser = new IdentityUser()
        //    {
        //        Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
        //        UserName = "guest@mail.com",
        //        NormalizedUserName = "guest@mail.com",
        //        Email = "guest@mail.com",
        //        NormalizedEmail = "guest@mail.com"
        //    };

        //    this.GuestUser.PasswordHash =
        //    hasher.HashPassword(this.GuestUser, "guest123");
        //}
        //private void SeedCategories()
        //{
        //    this.SmallCategory = new Category()
        //    {
        //        Id = 1,
        //        Name = "Small"
        //    };

        //    this.MiddleCategory = new Category()
        //    {
        //        Id = 2,
        //        Name = "Middle"
        //    };

        //    this.LargeCategory = new Category()
        //    {
        //        Id = 3,
        //        Name = "Large"
        //    };
        //}


        //private void SeedScooter()
        //{
        //    this.FirstScooter = new Scooter()
        //    {
        //        Id = 1,
        //        EngineType = "Electric",
        //        Type = "Piaggo",
        //        Rating = 6,
        //        PricePerHour = 10.00M,
        //        CategoryId = this.SmallCategory.Id,
        //        VehicleParkId = 1,
        //        ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fbg.e-scooter.co%2Fwp-content%2Fuploads%2F2021%2F06%2Fcuckgo.com_-e1623030797433.jpeg&imgrefurl=https%3A%2F%2Fbg.e-scooter.co%2Fpiaggio-one%2F&tbnid=xM2wRoaEPhPNHM&vet=12ahUKEwiD_cOT5Pj7AhVxyrsIHaqtCpUQMygBegUIARC6AQ..i&docid=zsJorUwAg6RoyM&w=753&h=771&q=Piaggio&ved=2ahUKEwiD_cOT5Pj7AhVxyrsIHaqtCpUQMygBegUIARC6AQ",
        //        Description = "A realy good transport solution for a city center.",
        //        RenterId = this.GuestUser.Id,
        //    };
        //}

        //private void SeedBike()
        //{
        //    this.FirstBike = new Bike()
        //    {
        //        Id = 1,
        //        Type = "Passati",
        //        Rating = 4,
        //        PricePerHour = 8.00M,
        //        CategoryId = this.MiddleCategory.Id,
        //        VehicleParkId = 2,
        //        ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fpassati.com%2Fimages%2Fstories%2Fvirtuemart%2Fproduct%2FEGBERT27.5-29%2520DISK%2520BLUE%2520Front.jpg&imgrefurl=https%3A%2F%2Fpassati.com%2Findex.php%3Foption%3Dcom_virtuemart%26view%3Dproductdetails%26virtuemart_product_id%3D203%26virtuemart_category_id%3D2%26lang%3Dbg&tbnid=F1pd6OQdaNHHfM&vet=12ahUKEwia-avZ5vj7AhUunv0HHSr8DY8QMygHegUIARDLAQ..i&docid=zUMwW1b5u_0RHM&w=4750&h=3123&q=passati%20%D0%BA%D0%BE%D0%BB%D0%B5%D0%BB%D0%BE&ved=2ahUKEwia-avZ5vj7AhUunv0HHSr8DY8QMygHegUIARDLAQ",
        //        Description = "A very good transport solution for sport people.",
        //        RenterId = null,
        //    };
        //}
        //private void SeedCar()
        //{
        //    this.FirstCar = new Car()
        //    {
        //        Id =1,
        //        EngineType = "Petrol",
        //        Type = "Mercedes C 180",
        //        Rating = 6,
        //        PricePerHour = 20.00M,
        //        CategoryId = this.MiddleCategory.Id,
        //        VehicleParkId = 3,
        //        ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2F5%2F52%2FMercedes-Benz_C_200_Avantgarde_%2528W_205%2529_%25E2%2580%2593_Frontansicht%252C_26._April_2014%252C_D%25C3%25BCsseldorf.jpg&imgrefurl=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FMercedes-Benz_C-Class_(W205)&tbnid=wz3T3Jbg3NRb1M&vet=12ahUKEwjw97il6fj7AhUunv0HHSr8DY8QMygCegUIARDGAQ..i&docid=W-hhnTTjUDZfoM&w=3418&h=1711&q=mercedes%20c%20class%20w205&ved=2ahUKEwjw97il6fj7AhUunv0HHSr8DY8QMygCegUIARDGAQ",
        //        Description = "A realy good and luxury transport solution.",
        //        RenterId = null,
        //    };
        //}
        //private void SeedTruck()
        //{
        //    this.FirstTruck = new Truck()
        //    {
        //        Id = 1,
        //        EngineType = "Diesel",
        //        Type = "Volvo",
        //        Rating = 5,
        //        PricePerHour = 40.00M,
        //        CategoryId = this.LargeCategory.Id,
        //        VehicleParkId = 4,
        //        ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.volvotrucks.us%2F-%2Fmedia%2Fvtna%2Fimages%2Fshared%2Ftab-content%2Fvnl%2Ftabbed-feature%2Fvolvo-vnl-25th-aerodynamics.jpg%3Fh%3D410%26w%3D725%26rev%3D4a1b9e19a65e418ba2bcffc4b952005a%26hash%3D78C61F2B39C62E7464AAA1FC051487C0&imgrefurl=https%3A%2F%2Fwww.volvotrucks.us%2Ftrucks%2Fvnl%2F&tbnid=4lteSbMPeJB2jM&vet=12ahUKEwj3jKWa6vj7AhUykv0HHaDKC88QMygPegUIARDgAQ..i&docid=cXhpx2BnsyvK8M&w=725&h=410&q=volvo%20truck%202021&ved=2ahUKEwj3jKWa6vj7AhUykv0HHaDKC88QMygPegUIARDgAQ",
        //        Description = "A realy good transport solution for a big cargo.",
        //        RenterId = null,
        //    };
        //}
    }
}