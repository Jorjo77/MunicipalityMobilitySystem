using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
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
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleParkService, VehicleParkService>();


            return services;
        }
    }
}
