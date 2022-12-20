using MunicipalityMobilitySystem.Core.Contracts;

namespace MunicipalityMobilitySystem.Core.Models
{
    public class VehicleHomeModel : IVehicleModel
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Rating { get; set; } 
    }
}
