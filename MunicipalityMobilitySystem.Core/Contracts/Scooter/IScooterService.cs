using MunicipalityMobilitySystem.Core.Models.Scooter;

namespace MunicipalityMobilitySystem.Core.Contracts.Scooter
{
    public interface IScooterService
    {
        Task<IEnumerable<ScooterHomeModel>> LastOneScooter();
    }
}
