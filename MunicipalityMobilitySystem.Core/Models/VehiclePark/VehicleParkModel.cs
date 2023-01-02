using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Models.VehiclePark
{
    public class VehicleParkModel: IVehicleParkModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
