using MunicipalityMobilitySystem.Core.Models.Truck;

namespace MunicipalityMobilitySystem.Core.Contracts.Truck
{
    public interface ITruckService
    {
        Task<IEnumerable<TruckHomeModel>> LastOneTruck();
    }
}
