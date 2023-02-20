using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static MunicipalityMobilitySystem.Data.DataConstants.Bill;

namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class TheBillViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(RegistrationNumberMaxLength)]
        [MinLength(RegistrationNumberMinLength)]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLength)]
        [MinLength(ModelMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [Precision(12, 2)]
        public decimal PricePerHour { get; set; }

        [Required]
        public int VehicleId { get; set; }
        public string? RenterId { get; set; }
        public TimeSpan? RentedPeriod { get; set; }
        public DateTime? MomenOfRent { get; set; }
        public DateTime? MomenOfLeave { get; set; }

        [Required]
        [Precision(12, 2)]
        public decimal TotalPrice { get; set; }
    }
}
