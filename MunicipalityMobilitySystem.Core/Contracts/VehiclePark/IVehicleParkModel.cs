namespace MunicipalityMobilitySystem.Core.Contracts.VehiclePark
{
    public interface IVehicleParkModel
    {
        public int Id { get; }

        public string Name { get; } 

        public string Email { get; } 

        public string Phone { get; } 

        public string Adress { get; }
        public string ImageUrl { get; }
    }
}
