using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Core.Models.VehiclePark;

namespace MunicipalityMobilitySystem.Core.Contracts.Admin
{
    public interface IStatisticService
    {
        int GetFreeVehiclesCount();
        int GetRentedVehiclesCount();
        int GetVehicleParksCount();
        IEnumerable<StatisticVehicleModel> GetTopVehicles();
        IEnumerable<VehicleParkModel> GetVehicleParks();
        IEnumerable<IEnumerable<StatisticVehicleParkModel>>  GetTopVehicleParks();
        StatisticVehicleModel GetTopBike();
        StatisticVehicleModel GetTopCar();
        StatisticVehicleModel GetTopScooter();
        StatisticViewModel GetStatistic();
        IEnumerable<StatisticVehicleModel> GetThreeMostReparedVehicles();
        StatisticDetailsVehicleModel GetVehicleStatisticDetailsById(int id);
        ICollection<TheBillViewModel> AllBillsByVehicleId(int id);
        ICollection<OrderViewModel> AllOrdersByVehicleId(int id);

        ICollection<VehicleDetailsFeedbackServiceModel> AllCustomerFeedbacksByVehicleId(int id);
    }
}
