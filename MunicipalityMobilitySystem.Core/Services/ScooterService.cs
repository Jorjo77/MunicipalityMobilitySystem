using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Scooter;
using MunicipalityMobilitySystem.Core.Models;
using MunicipalityMobilitySystem.Data;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
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

        public async Task<IEnumerable<VehicleHomeModel>> AllScooters()
        {
            var result = await repo.AllReadonly<Scooter>()
                .OrderByDescending(s=>s.Id)
                .Select(s=> new VehicleHomeModel
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
