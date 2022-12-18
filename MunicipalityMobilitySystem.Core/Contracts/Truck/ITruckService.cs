using MunicipalityMobilitySystem.Core.Models;

namespace MunicipalityMobilitySystem.Core.Contracts.Truck
{
    public interface ITruckService
    {
        Task<IEnumerable<VehicleHomeModel>> LastOneTruck();
    }
}
