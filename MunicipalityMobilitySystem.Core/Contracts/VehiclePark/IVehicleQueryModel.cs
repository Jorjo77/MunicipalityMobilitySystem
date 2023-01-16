using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Contracts.VehiclePark
{
    public interface IVehicleQueryModel
    {
        public int TotalVehiclesCount { get; set; }

        public IEnumerable<VehicleServiceModel> Vehicles { get; set; }
    }
}
