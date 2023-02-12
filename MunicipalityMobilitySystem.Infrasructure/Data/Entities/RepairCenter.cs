using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MunicipalityMobilitySystem.Data.DataConstants.RepairCenter;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class RepairCenter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(VehiclePark))]
        public int VehicleParkId { get; set; }
        public VehiclePark VehiclePark { get; set; } = null!;
        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}

