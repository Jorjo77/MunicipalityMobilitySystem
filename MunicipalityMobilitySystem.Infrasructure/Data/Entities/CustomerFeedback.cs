using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MunicipalityMobilitySystem.Data.DataConstants.CustomerFeedback;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class CustomerFeedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Vehicle))]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
        [Required]
        public string UserId { get; set; } = null!;

        [MaxLength(FeedbackMaxLength)]
        public string? Feedback { get; set; } 

        [Required]
        public int Vote { get; set; }
    }
}
