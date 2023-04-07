using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MunicipalityMobilitySystem.Data.DataConstants.Expense;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [Required]
        [ForeignKey(nameof(PartsOrder))]
        public int PartsOrderId { get; set; }

        [Required]
        public PartsOrder PartsOrder { get; set; } = null!;

        [Required]
        [Precision(12, 2)]
        public decimal UnutPrice { get; set; }
    }
}
