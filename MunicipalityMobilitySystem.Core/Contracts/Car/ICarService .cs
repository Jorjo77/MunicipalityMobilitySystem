using MunicipalityMobilitySystem.Core.Models;

namespace MunicipalityMobilitySystem.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<VehicleHomeModel>> LastOneCar();
    }
}
