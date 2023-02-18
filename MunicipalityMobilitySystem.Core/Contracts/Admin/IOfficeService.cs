using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Core.Models.VehiclePark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityMobilitySystem.Core.Contracts.Admin
{
    public interface IOfficeService
    {
        Task<IEnumerable<VehicleDetailsViewModel>> GetLeftVehicles();
        Task<decimal> GetTheBill(int vehicleId);

        Task<VehicleDetailsViewModel> GetLeftVehicleById(int vehicleId);

        Task EditLeftVehicleById(VehicleDetailsViewModel model);

        Task SetVehicleForCleaning(int vehicleId);

        Task SetVehicleForRepairing(int vehicleId);
    }
}
