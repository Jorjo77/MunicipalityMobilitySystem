using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;

using static MunicipalityMobilitySystem.Data.DataConstants.Vehicle;
using MunicipalityMobilitySystem.Core.Models.Category;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;

namespace MunicipalityMobilitySystem.Core.Models.Vehicle
{
    public class CreateVehicleModel : ICreateVehicleModel
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(ModelMaxLength)]
        [MinLength(ModelMinLength)]
        [Display(Name = "Model")]
        public string ModelName { get; set; } = null!;

        [Required]
        [MaxLength(RegistrationNumberMaxLength)]
        [MinLength(RegistrationNumberMinLength)]
        [Display(Name = "Reg. Number")]
        public string RegistrationNumber { get; set; } = null!;

        [MaxLength(EngineTypeMaxLength)]
        [MinLength(EngineTypeMinLength)]
        [Display(Name = "Engine Type")]
        public string? EngineType { get; set; }

        [Required]
        [Precision(12, 2)]
        [Range(2.00, 200.00)]
        [Display(Name = "Price per hour")]
        public decimal PricePerHour { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryServiceModel> Categories { get; set; } = new List<CategoryServiceModel>();

        [Required]
        [ForeignKey(nameof(VehiclePark))]
        public int VehicleParkId { get; set; }
        public string? RenterId { get; set; } 
        public bool ForRepearing { get; set; } = false;
        public bool ForCleaning { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime? MomenOfRent { get; set; }
        public DateTime? MomenOfLeave { get; set; }
        public double RentedPeriod { get; set; }
        public string? FailureDescription { get; set; } = null;

        public int? RepairsCount { get; set; } = null;

        public int? RentsCount { get; set; } = null;
        public IEnumerable<PartsOrder> OrderedParts { get; set; } = new List<PartsOrder>();
    }
}
