using MunicipalityMobilitySystem.Core.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityMobilitySystem.Core.Contracts.Admin
{
    public interface IOfficeService
    {
        Task<IEnumerable<VehicleDetailsViewModel>> GetLivedVehicles();
    }
}
