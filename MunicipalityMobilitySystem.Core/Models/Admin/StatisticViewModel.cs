namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class StatisticViewModel
    {
        public int TotalVehicleParks { get; set; }
        public int TotalRentedVehicles { get; set; }
        public int TotalFreeVehicles{ get; set; }

        public StatisticVehicleModel TopCar { get; set; } = null!;
        public StatisticVehicleModel TopScooter { get; set; } = null!;
        public StatisticVehicleModel TopBike { get; set; } = null!;

        public IEnumerable<StatisticVehicleModel> TopVehicles { get; set; } = new List<StatisticVehicleModel>();
    }
}
