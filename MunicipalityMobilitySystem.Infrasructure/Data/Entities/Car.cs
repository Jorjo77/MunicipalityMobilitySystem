using System.ComponentModel.DataAnnotations;

using static MunicipalityMobilitySystem.Data.DataConstants.Car;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class Car : Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EngineTypeMaxLength)]
        public string EngineType { get; set; } = null!;
        public bool IsNeedDayBlueCard { get; set; } = false;
    }
}
