using MunicipalityMobilitySystem.Core.Contracts.Vehicle;

namespace MunicipalityMobilitySystem.Core.Models.Vehicle
{
    public class VehicleTypeModel : IVehicleModel
    {
        public int Id { get; set; }

        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Rating { get; set; }
    }
}
