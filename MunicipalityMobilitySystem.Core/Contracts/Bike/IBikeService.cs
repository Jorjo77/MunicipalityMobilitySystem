using MunicipalityMobilitySystem.Core.Models.Bike;

namespace MunicipalityMobilitySystem.Core.Contracts.Bike
{
    public interface IBikeService
    {
        Task<IEnumerable<BikeHomeModel>> LastOneBike();

    }
}
