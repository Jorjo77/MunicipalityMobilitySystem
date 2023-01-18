using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Contracts.Vehicle
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleServiceModel>> AllVehiclesByUserId(string userId);

        Task<VehicleServiceModel> VehicleDetails(int id);

        Task<bool> IsRented(int vehicleId);

        Task<bool> IsRentedByUserWithId(int vehicleId, string currentUserId);

        Task<bool> Exists(int id);

        Task Rent(int vehicleId, string currentUserId);
        Task Leave(int vehicleId);
    }
}
