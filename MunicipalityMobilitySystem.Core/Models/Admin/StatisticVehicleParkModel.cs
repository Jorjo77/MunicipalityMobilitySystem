
namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class StatisticVehicleParkModel
    {
        public string Name { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public int VehiclesCount { get; set; }

        public int RentsCount { get; set; }

        public double TotalRentedPeriod { get; set; }

        public decimal TotalIncome { get; set; }
    }
}
