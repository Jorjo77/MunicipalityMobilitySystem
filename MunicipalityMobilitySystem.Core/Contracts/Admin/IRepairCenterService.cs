using MunicipalityMobilitySystem.Core.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Contracts.Admin
{
    public interface IRepairCenterService
    {
        Task<IEnumerable<RepairCenterServiceModel>> GetRepairCenters();

        Task<RepairCenterServiceModel> GetRepairCenterById(int id);

        Task<IEnumerable<VehicleDetailsViewModel>> GetVehiclesForRepair(int repairingCenterId);
        Task Delete(int id);
        Task Create(RepairCenterDetailsServiceModel model);
        Task<bool> Exists(int id);
        public Task RepairVehicle(int id);
    }
}
