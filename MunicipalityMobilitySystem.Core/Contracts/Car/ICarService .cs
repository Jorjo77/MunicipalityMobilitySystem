using MunicipalityMobilitySystem.Core.Models.Car;

namespace MunicipalityMobilitySystem.Core.Contracts.Car
{
    public interface ICarService
    {
        Task<IEnumerable<CarHomeModel>> LastOneCar();
    }
}
