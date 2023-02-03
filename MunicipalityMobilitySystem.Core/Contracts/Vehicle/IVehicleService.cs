using MunicipalityMobilitySystem.Core.Models;
using MunicipalityMobilitySystem.Core.Models.Category;
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

        Task<VehicleQueryModel> AllVehicles(
                                    string category = null,
                                    string searchTerm = null,
                                    VehiclesSorting sorting = VehiclesSorting.Newest,
                                    int currentPage = 1,
                                    int vehiclesPerPage = 1);

        Task<bool> CategoryExists(int categoryId);

        Task Create(CreateVehicleModel createVehicleModel);

        Task<bool> VehiceExistsByModelEngineTypeAndDescription(string model, string engineType, string description);

        Task Delete(int vehicleId);

        Task<int> GetVehicleCategoryId(int vehicleId);

        Task Edit(int vehicleId, CreateVehicleModel createVehicleModel);

    }
}
