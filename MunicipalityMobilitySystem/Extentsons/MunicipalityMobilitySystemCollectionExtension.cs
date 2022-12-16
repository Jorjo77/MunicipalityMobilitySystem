

using MunicipalityMobilitySystem.Core.Contracts.Bike;
using MunicipalityMobilitySystem.Core.Contracts.Car;
using MunicipalityMobilitySystem.Core.Contracts.Scooter;
using MunicipalityMobilitySystem.Core.Contracts.Truck;
using MunicipalityMobilitySystem.Core.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MunicipalityMobilitySystemCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IBikeService, BikeService>();
            services.AddScoped<IScooterService, ScooterService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ITruckService, TruckService>();


            return services;
        }
    }
}
