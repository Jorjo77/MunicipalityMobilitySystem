namespace MunicipalityMobilitySystem.Core.Contracts.Scooter
{
    internal interface IScooterModel
    {
        public int Id { get; }

        public string Type { get; }

        public string ImageUrl { get; }

        public int Rating { get; }
    }
}
