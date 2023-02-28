using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        [Precision(12, 2)]
        public decimal UnutPrice { get; set; }
    }
}
