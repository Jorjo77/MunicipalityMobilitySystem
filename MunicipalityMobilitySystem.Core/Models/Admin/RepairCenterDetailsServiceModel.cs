using MunicipalityMobilitySystem.Core.Models.Vehicle;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static MunicipalityMobilitySystem.Data.DataConstants.RepairCenter;

namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class RepairCenterDetailsServiceModel
    {
        //ToDo: To make validation and build create view

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MinLength(AdressMinLength)]
        [MaxLength(AdressMaxLength)]
        public string Adress { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(VehiclePark))]
        [Range(VehicleParkMinValue, VehicleParkMaxValue)]
        public int VehicleParkId { get; set; }
        public IEnumerable<VehicleDetailsViewModel> Vehicles { get; set; } = new List<VehicleDetailsViewModel>();
    }
}
