using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static MunicipalityMobilitySystem.Data.DataConstants.Bike;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{

    public class Bike 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeMaxLength)]
        public string Type { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public int Rating { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        [Required]
        public int VehicleParkId { get; set; }
        public VehiclePark VehiclePark { get; set; } = null!;

        [Required]
        [Precision(12, 2)]
        public decimal PricePerHour { get; set; }
        public string? RenterId { get; set; }
        public bool IsForRepearing { get; set; } = false;
        public bool IsForCleaning { get; set; } = false;
        public bool IsNeedHelmet { get; set; } = false;
        public bool IsNeedDayExchangeVehicleCard { get; set; } = false;
    }
}
