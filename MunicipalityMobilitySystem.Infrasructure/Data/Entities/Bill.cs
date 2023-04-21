﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MunicipalityMobilitySystem.Data.DataConstants.Bill;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLength)]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        [Precision(12, 2)]
        public decimal PricePerHour { get; set; }

        [Required]
        [ForeignKey(nameof(Vehicle))]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
        public string? RenterId { get; set; }
        public double RentedPeriod { get; set; }
        public DateTime? MomenOfRent { get; set; }
        public DateTime? MomenOfLeave { get; set; }

        [Required]
        [Precision(12, 2)]
        public decimal TotalPrice { get; set; }
    }
}
