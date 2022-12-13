using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;

namespace MunicipalityMobilitySystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Scooter> Scooters { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Truck> Trucks { get; set; } = null!;
        public DbSet<Bike> Bikes { get; set; } = null!;
        public DbSet<Category> Categorys { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}