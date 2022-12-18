using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Truck;
using MunicipalityMobilitySystem.Core.Models;
using MunicipalityMobilitySystem.Data;

namespace MunicipalityMobilitySystem.Core.Services
{
    public class TruckService : ITruckService
    {
        private readonly MunicipalityMobilitySystemDbContext context;

        private readonly ILogger logger;

        public TruckService(
            MunicipalityMobilitySystemDbContext context,
            ILogger<TruckService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<IEnumerable<VehicleHomeModel>> LastOneTruck()
        {
            var result = await context.Trucks.OrderByDescending(t => t.Id)
                .Select(t=> new VehicleHomeModel
                {
                    Id = t.Id,
                    Type= t.Type,
                    ImageUrl= t.ImageUrl,
                    Rating= t.Rating
                }).Take(1)
                .ToListAsync(); 
                
            return result;
        }
    }
}
