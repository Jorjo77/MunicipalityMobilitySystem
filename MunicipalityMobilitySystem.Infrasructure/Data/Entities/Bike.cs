namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class Bike : Vehicle
    {
        public bool IsNeedHelmet { get; set; } = false;
        public bool IsNeedDayExchangeVehicleCard { get; set; } = false;
    }
}
