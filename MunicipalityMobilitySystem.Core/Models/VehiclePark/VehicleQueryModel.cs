using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Models.VehiclePark
{
    public class VehicleQueryModel : IVehicleQueryModel
    {
        public int TotalVehiclesCount { get ; set ; }
        public IEnumerable<VehicleServiceModel> Vehicles { get; set; } = new List<VehicleServiceModel>();
    }
}
