using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using System.ComponentModel.DataAnnotations;
using static MunicipalityMobilitySystem.Data.DataConstants.VehiclePark;

namespace MunicipalityMobilitySystem.Core.Models.VehiclePark
{
    public class VehicleParkDetailsModel : IVehicleParkDetailsModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(EmailMinLength)]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(PhoneMinLength)]
        [MaxLength(PhoneMaxLength)]
        public string Phone { get; set; } = null!;

        [Required]
        [MinLength(AdressMinLength)]
        [MaxLength(AdressMaxLength)]
        public string Adress { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
    }
}
