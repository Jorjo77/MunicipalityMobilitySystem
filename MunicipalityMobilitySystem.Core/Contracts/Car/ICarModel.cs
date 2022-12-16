namespace MunicipalityMobilitySystem.Core.Contracts.Car
{
    internal interface ICarModel
    {
        public int Id { get; }

        public string Type { get; }

        public string ImageUrl { get; }

        public int Rating { get; }
    }
}
