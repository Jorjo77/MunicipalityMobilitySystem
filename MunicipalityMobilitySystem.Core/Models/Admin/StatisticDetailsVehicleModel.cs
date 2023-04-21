using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class StatisticDetailsVehicleModel
    {
        public string RegistrationNumber { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string EngineType { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal PricePerHour { get; set; }
        public double Rating { get; set; }

        public double RentedPeriod { get; set; }

        public int RepairsCount { get; set; }

        public int RentsCount { get; set; }

        public string VehicleParkName { get; set; } = null!;

        public string VehicleParkAdress { get; set; } = null!;

        public double TotalExpenses { get; set; }
        public double TotalIncome { get; set; }  
        public double TotalProfit { get; set; }

        public ICollection<TheBillViewModel> Bills { get; set; } = new List<TheBillViewModel>();
        public ICollection<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();
        public ICollection<VehicleDetailsFeedbackServiceModel> CustomerFeedback { get; set; } = new List<VehicleDetailsFeedbackServiceModel>();
    }
}
