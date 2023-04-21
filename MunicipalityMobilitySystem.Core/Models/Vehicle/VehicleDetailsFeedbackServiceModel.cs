using MunicipalityMobilitySystem.Core.Contracts.Vehicle;

namespace MunicipalityMobilitySystem.Core.Models.Vehicle
{
    public class VehicleDetailsFeedbackServiceModel : IVehicleDetailsFeedbackServiceModel
    {
        public int Id { get; set; }

        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public double Rating { get; set; }

        public int VehicleId { get; set; }

        public string UserId { get; set; } = null!;

        public string? Feedback { get; set; }

        public int Vote { get; set; }
    }
}
