using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Scooter;
using MunicipalityMobilitySystem.Core.Models;
using MunicipalityMobilitySystem.Data;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;

namespace MunicipalityMobilitySystem.Core.Services
{
    public class ScooterService : IScooterService
    {
        private readonly IRepository repo;

        private readonly ILogger logger;

        public ScooterService(
            IRepository repo,
            ILogger<ScooterService> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }

        public async Task<IEnumerable<AllScootersQueryModel>> LastOneScooter()
        {
            var result = await repo.Scooters.OrderByDescending(s=>s.Id)
                .Select(s=> new AllScootersQueryModel
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
