using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using System.ComponentModel.DataAnnotations;

using static MunicipalityMobilitySystem.Data.DataConstants.CustomerFeedback;

namespace MunicipalityMobilitySystem.Core.Models.Vehicle
{
    public class VehicleFeedbackServiceModel : IVehicleFeedbackServiceModel
    {
        public int Id { get; set; }


        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public int VehicleId { get; set; }

        [MaxLength(FeedbackMaxLength)]
        [MinLength(FeedbackMinLength)]
        public string? Feedback { get; set; }

        [Required]
        [Range(VoteMinValue, VoteMaxValue)]
        public int Vote { get; set; }
    }
}
