﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MunicipalityMobilitySystem.Data.DataConstants.PartsOrder;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class PartsOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Vehicle))]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
        public string? RenterId { get; set; }
        public IEnumerable<Part> Parts { get; set; } = new List<Part>();

        [Required]
        [Precision(12, 2)]
        public decimal TotalPrice { get; set; }
    }
}
