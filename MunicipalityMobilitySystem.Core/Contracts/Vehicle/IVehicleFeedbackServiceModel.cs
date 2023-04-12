using MunicipalityMobilitySystem.Core.Models.Vehicle;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MunicipalityMobilitySystem.Core.Contracts.Vehicle
{
    public interface IVehicleFeedbackServiceModel
    {
        public int Id { get; }

        public string Model { get; } 

        public string ImageUrl { get; } 

        public double Rating { get; }

        public string UserId { get; } 

        public string? Feedback { get; }

        public int Vote { get; }
    }
}
