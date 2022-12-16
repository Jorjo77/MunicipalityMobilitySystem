using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Car;
using MunicipalityMobilitySystem.Core.Exceptions;

using MunicipalityMobilitySystem.Core.Models.Car;
using MunicipalityMobilitySystem.Data;

namespace MunicipalityMobilitySystem.Core.Services
{
    public class CarService : ICarService
    {
        private readonly MunicipalityMobilitySystemDbContext context;

        private readonly ILogger logger;

        public CarService(
            MunicipalityMobilitySystemDbContext context,
            ILogger<CarService> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task<IEnumerable<CarHomeModel>> LastOneCar()
        {
            var result = await context.Cars.OrderByDescending(c => c.Id)
                .Select(c => new CarHomeModel
                {
                    Id = c.Id,
                    Type = c.Type,
                    ImageUrl = c.ImageUrl,
                    Rating = c.Rating
                }).Take(1)
                .ToListAsync();

            return result;
        }
    }
}
