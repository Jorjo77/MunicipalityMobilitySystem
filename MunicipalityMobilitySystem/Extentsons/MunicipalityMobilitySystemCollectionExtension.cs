using MunicipalityMobilitySystem.Core.Contracts.Category;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Services;
using MunicipalityMobility.Core.Services.Admin;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;
using MunicipalityMobilitySystem.Core.Services.Admin;

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
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRepairCenterService, RepairCenterService>();
            services.AddScoped<IWashingCenterService, WashingCenterService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IUserService, UserService>();


            return services;
        }
    }
}
