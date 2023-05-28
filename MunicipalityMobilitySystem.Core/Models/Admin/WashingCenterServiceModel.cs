using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class WashingCenterServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Adress { get; set; } = null!;

        public IEnumerable<VehicleDetailsViewModel> VehiclesForCleaning { get; set; } = new List<VehicleDetailsViewModel>();
    }
}
