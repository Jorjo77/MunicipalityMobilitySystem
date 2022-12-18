using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Bike;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Bike;
using MunicipalityMobilitySystem.Data;

namespace MunicipalityMobilitySystem.Core.Services
{
    public class BikeService : IBikeService
    {
        private readonly MunicipalityMobilitySystemDbContext context;

        private readonly ILogger logger;

        public BikeService(
            MunicipalityMobilitySystemDbContext context,
            ILogger<BikeService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<IEnumerable<VehicleHomeModel>> LastOneBike()
        {
            var result = await context.Bikes.OrderByDescending(b=>b.Id)
                .Select(b=> new VehicleHomeModel
                {
                    Id = b.Id,
                    Type= b.Type,
                    ImageUrl= b.ImageUrl,
                    Rating= b.Rating
                }).Take(1)
                .ToListAsync(); 
                
            return result;
        }

    }
}
