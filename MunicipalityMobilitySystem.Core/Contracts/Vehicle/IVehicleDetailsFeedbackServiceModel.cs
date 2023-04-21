namespace MunicipalityMobilitySystem.Core.Contracts.Vehicle
{
    public interface IVehicleDetailsFeedbackServiceModel
    {
        public int Id { get; }

        public string Model { get; }
        public string ImageUrl { get; }
        public double Rating { get; }

        public int VehicleId { get; }

        public string UserId { get; } 

        public string? Feedback { get; }

        public int Vote { get; }
    }
}
