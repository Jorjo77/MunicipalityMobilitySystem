using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;

namespace MunicipalityMobilitySystem.Core.Services.Admin
{
    public class OfficeService : IOfficeService
    {
        private readonly ILogger logger;
        private readonly IRepository repo;

        public OfficeService(ILogger<OfficeService> _logger,
            IRepository _repo)
        {
            logger= _logger;
            repo= _repo;
        }
        public async Task<IEnumerable<VehicleDetailsViewModel>> GetLivedVehicles()
        {
            return await repo.All<Vehicle>()
                .Where(v=>v.RentedPeriod != null)
                .Select(v=> new VehicleDetailsViewModel
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber,
                    Model = v.Model,
                    VehicleParkId = v.VehicleParkId,
                    ForCleaning = v.ForCleaning,
                    ForRepearing = v.ForRepearing,
                    RentedPeriod= v.RentedPeriod,
                    RenterId= v.RenterId,
                })
                .ToListAsync();
        }
    }
}
