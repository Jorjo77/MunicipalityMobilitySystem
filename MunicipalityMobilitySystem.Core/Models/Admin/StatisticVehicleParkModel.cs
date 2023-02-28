namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class StatisticVehicleParkModel
    {
        public int PricePerHour { get; set; }

        public double RentedPeriod { get; set; }

        public int RepairsCount { get; set; }

        public int RentsCount { get; set; }

        public int VehiclesCount { get; set; }

        public string VehicleParkName { get; set; } = null!;

        public string VehicleParkAdress { get; set; } = null!;
        public double TotalProfit
            => RentedPeriod * PricePerHour;
    }
}
