using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using System.ComponentModel;

namespace MunicipalityMobilitySystem.Core.Models.Vehicle
{
    public class VehicleServiceModel : IVehicleServiceModel
    {
        public int Id { get; set; }

        public string Model { get; set; } = null!;

        [DisplayName("Engine Type")]

        public string EngineType { get; set; } = null!;

        [DisplayName("Image URL")]

        public string ImageUrl { get; set; } = null!;

        public int Rating { get; set; }

        [DisplayName("Price per hour")]
        public decimal PricePerHour { get; set; }

        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }

        public int VehicleParkId { get; set; }

        public string? RenterId { get; set; }
    }
}
