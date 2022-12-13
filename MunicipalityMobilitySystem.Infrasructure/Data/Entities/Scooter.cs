using System.ComponentModel.DataAnnotations;

using static MunicipalityMobilitySystem.Data.DataConstants.Scooter;
namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class Scooter : Vehicle
    {
        [Required]
        [MaxLength(EngineTypeMaxLength)]
        public string EngineType { get; set; } = null!;
        public bool IsNeedHelmet { get; set; } = false;
        public bool IsNeedDayExchangeVehicleCard { get; set; } = false;
    }
}
