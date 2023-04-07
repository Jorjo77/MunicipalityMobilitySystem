namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class StatisticVehicleModel
    {
        public string RegistrationNumber { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string EngineType { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int PricePerHour { get; set; }

        public double RentedPeriod { get; set; }

        public int RepairsCount { get; set; }

        public int RentsCount { get; set; }

        public string VehicleParkName { get; set; } = null!;

        public string VehicleParkAdress { get; set; } = null!;

        public double TotalExpenses { get; set; }
        public double TotalIncome { get; set; }  
        public double TotalProfit { get; set; }
    }
}
