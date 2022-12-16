using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Scooter;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Scooter;
using MunicipalityMobilitySystem.Data;

namespace MunicipalityMobilitySystem.Core.Services
{
    public class ScooterService : IScooterService
    {
        private readonly MunicipalityMobilitySystemDbContext context;

        private readonly ILogger logger;

        public ScooterService(
            MunicipalityMobilitySystemDbContext context,
            ILogger<ScooterService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<IEnumerable<ScooterHomeModel>> LastOneScooter()
        {
            var result = await context.Scooters.OrderByDescending(s=>s.Id)
                .Select(s=> new ScooterHomeModel
                {
                    Id = s.Id,
                    Type= s.Type,
                    ImageUrl= s.ImageUrl,
                    Rating= s.Rating
                }).Take(1)
                .ToListAsync(); 
                
            return result;
        }
    }
}
