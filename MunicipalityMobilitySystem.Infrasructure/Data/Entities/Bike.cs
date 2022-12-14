using System.ComponentModel.DataAnnotations;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class Bike : Vehicle
    {
        [Key]
        public int Id { get; set; }
        public bool IsNeedHelmet { get; set; } = false;
        public bool IsNeedDayExchangeVehicleCard { get; set; } = false;
    }
}
