using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MunicipalityMobilitySystem.Data.DataConstants.Vehicle;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class Vehicle 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        [MaxLength(EngineTypeMaxLength)]
        public string? EngineType { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [Precision(12, 2)]
        public decimal PricePerHour { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(VehiclePark))]
        public int VehicleParkId { get; set; }
        public VehiclePark VehiclePark { get; set; } = null!;

        public string? RenterId { get; set; }
        public bool ForRepearing { get; set; } = false;
        public bool ForCleaning { get; set; } = false;

        public DateTime? RepairingTerm { get; set; }
        public string? FailureDescription { get; set; } 

        [Required]
        public int RepairsCount { get; set; }
        [Required]
        public int RentsCount { get; set; }
        public IEnumerable<PartsOrder> OrderedParts { get; set; } = new List<PartsOrder>();
    }
}
