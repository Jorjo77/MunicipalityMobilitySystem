using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using static MunicipalityMobilitySystem.Data.DataConstants.CustomerFeedback;

namespace MunicipalityMobilitySystem.Core.Models.Vehicle
{
    public class VehicleFeedbackServiceModel : IVehicleFeedbackServiceModel
    {
        public int Id { get; set; }

        public string Model { get; set; } = null!;

        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = null!;

        public double Rating { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [MaxLength(FeedbackMaxLength)]
        [MinLength(FeedbackMinLength)]
        public string? Feedback { get; set; }

        [Required]
        [Range(VoteMinValue, VoteMaxValue)]
        public int Vote { get; set; }
    }
}
