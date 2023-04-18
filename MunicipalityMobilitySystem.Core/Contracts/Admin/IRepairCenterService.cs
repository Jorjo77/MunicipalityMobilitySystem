
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;

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
        Task CreateOrder(PartsOrderServiceModel model);
        Task<bool> ExistsOrder(PartsOrderServiceModel queryModel);
        Task<VehicleDetailsViewModel> GetVehicleForRepairById(int vehicleId);
        Task<bool> ExistsOrderById(int id);
        Task<OrderViewModel> GetOrderById(int id);
        Task<ICollection<OrderViewModel>>GetOrders();
        Task DeleteOrder(int id);
        Task<ICollection<ExpenseServiceModel>> GetExpensesByOrderId(int id);
    }
}
