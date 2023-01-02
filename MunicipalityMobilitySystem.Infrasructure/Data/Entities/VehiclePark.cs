using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public IEnumerable<Service> Services { get; set; } = new List<Service>();
        public IEnumerable<VehicleWash> VehicleWashes { get; set; } = new List<VehicleWash>();
        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
