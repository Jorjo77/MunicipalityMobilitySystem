namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class VehicleWashingCentersViewModel
    {
        public int VehicleId { get; set; }

        public string RegistrationNumber { get; set; } = null!;

        public string[] WashingCenters { get; set; } = null!;
    }
}
