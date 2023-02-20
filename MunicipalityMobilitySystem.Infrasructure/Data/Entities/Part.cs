using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MunicipalityMobilitySystem.Data.DataConstants.Part;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Precision(12, 2)]
        public decimal Price { get; set; }
    }
}
