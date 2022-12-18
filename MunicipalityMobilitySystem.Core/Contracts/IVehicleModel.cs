namespace MunicipalityMobilitySystem.Core.Contracts
{
    internal interface IVehicleModel
    {
        public int Id { get; }

        public string Type { get; }

        public string ImageUrl { get; }

        public int Rating { get; }
    }
}
