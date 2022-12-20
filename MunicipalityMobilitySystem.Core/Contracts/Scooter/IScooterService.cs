using MunicipalityMobilitySystem.Core.Models;

namespace MunicipalityMobilitySystem.Core.Contracts.Scooter
{
    public interface IScooterService
    {
        Task<IEnumerable<AllScootersQueryModel>> AllScooters();
    }
}
