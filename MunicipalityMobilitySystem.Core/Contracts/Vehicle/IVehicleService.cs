using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Contracts.Vehicle
{
    public interface IVehicleService
    {
        Task<VehicleTypeModel> GetOneBike();
        Task<VehicleTypeModel> GetOneCar();
        Task<VehicleTypeModel> GetOneScooter();
        Task<IEnumerable<VehicleTypeModel>> LastThreeTopRankedVehicles();
        Task<IEnumerable<VehicleServiceModel>> AllBikesByVehicleParkId(int VehicleParkId);
        Task<IEnumerable<VehicleServiceModel>> AllScootersByVehicleParkId(int VehicleParkId);
        Task<IEnumerable<VehicleServiceModel>> AllCarsByVehicleParkId(int VehicleParkId);
    }
}
