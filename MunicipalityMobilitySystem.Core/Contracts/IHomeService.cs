using MunicipalityMobilitySystem.Core.Models;

namespace MunicipalityMobilitySystem.Core.Contracts
{
    public interface IHomeService
    {
        Task<IEnumerable<VehicleHomeModel>> LastTopRankedVehicles(VehicleHomeModel topBike,
                                                                  VehicleHomeModel topScooter, 
                                                                  VehicleHomeModel topCar,
                                                                  VehicleHomeModel topTruck);
        Task<VehicleHomeModel> LastTopRankedBike();
        Task<VehicleHomeModel> LastTopRankedScooter();
        Task<VehicleHomeModel> LastTopRankedCar();
        Task<VehicleHomeModel> LastTopRankedTruck();
    }
}
