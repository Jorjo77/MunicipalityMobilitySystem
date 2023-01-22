using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Areas.Admin.Models
{
    public class MyVehiclesViewModel
    {
        public IEnumerable<VehicleServiceModel> AddedVehicles { get; set; }
            = new List<VehicleServiceModel>();

        public IEnumerable<VehicleServiceModel> RentedVehicles { get; set; }
            = new List<VehicleServiceModel>();
    }
}
