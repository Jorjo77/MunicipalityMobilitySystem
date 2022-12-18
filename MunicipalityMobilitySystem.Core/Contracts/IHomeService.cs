using MunicipalityMobilitySystem.Core.Models;

namespace MunicipalityMobilitySystem.Core.Contracts
{
    public interface IHomeService
    {
        Task<VehicleHomeModel> LastTopRankedBike();
        Task<VehicleHomeModel> LastTopRankedScooter();
        Task<VehicleHomeModel> LastTopRankedCar();
        Task<VehicleHomeModel> LastTopRankedTruck();
    }
}
