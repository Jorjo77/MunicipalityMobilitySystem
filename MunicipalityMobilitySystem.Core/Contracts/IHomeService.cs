using MunicipalityMobilitySystem.Core.Models;

namespace MunicipalityMobilitySystem.Core.Contracts
{
    public interface IHomeService
    {
        Task<AllScootersQueryModel> LastTopRankedBike();
        Task<AllScootersQueryModel> LastTopRankedScooter();
        Task<AllScootersQueryModel> LastTopRankedCar();
        Task<AllScootersQueryModel> LastTopRankedTruck();
    }
}
