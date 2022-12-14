using System.ComponentModel.DataAnnotations;

using static MunicipalityMobilitySystem.Data.DataConstants.Category;
namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int Size { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
