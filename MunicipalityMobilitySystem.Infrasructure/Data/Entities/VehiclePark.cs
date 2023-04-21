using System.ComponentModel.DataAnnotations;
using static MunicipalityMobilitySystem.Data.DataConstants.VehiclePark;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class VehiclePark
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(PhoneMaxLength)]
        public string Phone { get; set; } = null!;

        [Required]
        [MaxLength(AdressMaxLength)]
        public string Adress { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public IEnumerable<RepairCenter> Services { get; set; } = new List<RepairCenter>();
        public IEnumerable<WashingCenter> VehicleWashes { get; set; } = new List<WashingCenter>();
        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
