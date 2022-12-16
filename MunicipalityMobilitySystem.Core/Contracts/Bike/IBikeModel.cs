namespace MunicipalityMobilitySystem.Core.Contracts.Bike
{
    internal interface IBikeModel
    {
        public int Id { get; }

        public string Type { get; }

        public string ImageUrl { get; }

        public int Rating { get; }
    }
}
