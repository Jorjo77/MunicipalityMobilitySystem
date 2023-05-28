using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class RepairCenterServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Adress { get; set; } = null!;

        public IEnumerable<VehicleDetailsViewModel> VehiclesForRepair { get; set; } = new List<VehicleDetailsViewModel>();

    }
}
