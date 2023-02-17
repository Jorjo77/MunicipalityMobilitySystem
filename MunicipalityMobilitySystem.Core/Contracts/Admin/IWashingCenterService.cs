using MunicipalityMobilitySystem.Core.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Contracts.Admin
{
    public interface IWashingCenterService
    {
        Task<IEnumerable<WashingCenterServiceModel>> GetWashingCenters();

        Task<WashingCenterServiceModel> GetWashingCenterById(int id);

        Task<IEnumerable<VehicleDetailsViewModel>> GetVehiclesForWashing();
        Task Delete(int id);
        Task Create(WashingCenterDetailsServiceModel model);
        Task<bool> Exists(int id);

        Task WashVehicle(int id);
    }
}
