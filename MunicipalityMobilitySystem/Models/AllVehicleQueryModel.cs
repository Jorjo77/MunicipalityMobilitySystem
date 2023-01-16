using MunicipalityMobilitySystem.Core.Models.Category;
using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Models
{
    public class AllVehicleQueryModel
    {
        public int VehicleParkId { get; set; }

        public const int VehiclesPerPage = 3;

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public VehiclesSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public double TotalVehiclesCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<VehicleServiceModel> Vehicles { get; set; } = Enumerable.Empty<VehicleServiceModel>();
    }
}
