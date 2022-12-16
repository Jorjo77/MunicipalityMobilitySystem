using MunicipalityMobilitySystem.Core.Contracts.Car;

namespace MunicipalityMobilitySystem.Core.Models.Car
{
    public class CarHomeModel : ICarModel
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Rating { get; set; }
    }
}
