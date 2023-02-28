using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;

namespace MunicipalityMobilitySystem.Core.Models.Vehicle
{
    public class VehicleDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Reg. Number")]
        public string RegistrationNumber { get; set; } = null!;

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

        public bool ForRepearing { get; set; } = false;
        public bool ForCleaning { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public double RentedPeriod { get; set; }
        public DateTime? MomenOfRent { get; set; }
        public DateTime? MomenOfLeave { get; set; }
        public string? FailureDescription { get; set; }

        [Required]
        public int RepairsCount { get; set; }
        [Required]
        public int RentsCount { get; set; }
        public IEnumerable<PartsOrder> OrderedParts { get; set; } = new List<PartsOrder>();
        public IEnumerable<Bill> Bills { get; set; } = new List<Bill>();
    }
}
