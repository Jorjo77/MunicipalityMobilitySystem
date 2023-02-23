using MunicipalityMobilitySystem.Core.Models.Admin;
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
    }
}
