namespace MunicipalityMobilitySystem.Core.Contracts.Vehicle
{
    internal interface IVehicleModel
    {
        public int Id { get; }

        public string Model { get; }

        public string ImageUrl { get; }

        public int Rating { get; }
    }
}
