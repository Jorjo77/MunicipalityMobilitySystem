using MunicipalityMobilitySystem.Core.Contracts.Scooter;

namespace MunicipalityMobilitySystem.Core.Models.Scooter
{
    public class ScooterHomeModel : IScooterModel
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Rating { get; set; }
    }
}
