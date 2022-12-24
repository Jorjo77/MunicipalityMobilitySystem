using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Contracts
{
    public interface IVehicleService
    {
        Task<VehicleHomeModel> GetOneBike();
        Task<VehicleHomeModel> GetOneCar();
        Task<VehicleHomeModel> GetOneScooter();
        Task<IEnumerable<VehicleHomeModel>> LastThreeTopRankedVehicles();
    }
}
