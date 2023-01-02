using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Models.VehiclePark
{
    public class VehicleParkDetailsModel: IVehicleParkDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
