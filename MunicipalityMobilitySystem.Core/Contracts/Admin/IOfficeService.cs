using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;

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

        Task MakeAndPostTheBill(VehicleDetailsViewModel model, string name);

        Task<IEnumerable<TheBillViewModel>> GetTheBills();

        Task<IEnumerable<TheBillViewModel>> AllBillsByUserId(string id);

        Task DeleteBillById(int id);

        Task<bool> BillExists(VehicleDetailsViewModel model);

        Task<TheBillViewModel> GetBillById( int id);
    }
}
