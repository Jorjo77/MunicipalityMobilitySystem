using MunicipalityMobilitySystem.Core.Contracts;
using MunicipalityMobilitySystem.Core.Contracts.Bike;
using MunicipalityMobilitySystem.Core.Contracts.Scooter;
using MunicipalityMobilitySystem.Core.Contracts.Truck;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Services;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MunicipalityMobilitySystemCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IGuard, Guard>();
            services.AddScoped<IBikeService, BikeService>();
            services.AddScoped<IScooterService, ScooterService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ITruckService, TruckService>();
            services.AddScoped<IHomeService, HomeService>();


            return services;
        }
    }
}
