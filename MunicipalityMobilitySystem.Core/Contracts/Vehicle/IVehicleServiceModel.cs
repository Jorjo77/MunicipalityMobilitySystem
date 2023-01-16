namespace MunicipalityMobilitySystem.Core.Contracts.Vehicle
{
    internal interface IVehicleServiceModel
    {
        public int Id { get; }

        public string Model { get; }

        public string EngineType { get; }

        public string ImageUrl { get; }

        public int Rating { get; }

        public decimal PricePerHour { get; }

        public string Description { get; }

        public int CategoryId { get; }

        public int VehicleParkId { get; }

        public string? RenterId { get; }
    }
}
