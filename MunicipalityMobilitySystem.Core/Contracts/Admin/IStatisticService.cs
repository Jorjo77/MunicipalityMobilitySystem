using MunicipalityMobilitySystem.Core.Models.Admin;

namespace MunicipalityMobilitySystem.Core.Contracts.Admin
{
    public interface IStatisticService
    {
        int GetFreeVehiclesCount();
        int GetRentedVehiclesCount();
        int GetVehicleParksCount();
        IEnumerable<StatisticVehicleModel> GetTopVehicles();
        StatisticVehicleModel GetTopBike();
        StatisticVehicleModel GetTopCar();
        StatisticVehicleModel GetTopScooter();
        StatisticViewModel GetStatistic();
    }
}
