using MunicipalityMobilitySystem.Core.Contracts.Truck;

namespace MunicipalityMobilitySystem.Core.Models.Truck
{
    public class TruckHomeModel : ITruckModel
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Rating { get; set; }
    }
}
