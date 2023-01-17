using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Contracts.Vehicle
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleServiceModel>> AllVehiclesByUserId(string userId);
        Task<VehicleServiceModel> VehicleDetails(int id);
    }
}
