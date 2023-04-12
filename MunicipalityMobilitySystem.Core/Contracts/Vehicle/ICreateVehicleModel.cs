using Microsoft.EntityFrameworkCore;
using MunicipalityMobilitySystem.Core.Models.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;

namespace MunicipalityMobilitySystem.Core.Contracts.Vehicle
{
    public interface ICreateVehicleModel
    {

        public int Id { get; }

        public string ModelName { get; } 

        public string? EngineType { get; }

        public decimal PricePerHour { get; }

        public string ImageUrl { get; } 

        public string Description { get; } 

        public int CategoryId { get; }

        public IEnumerable<CategoryServiceModel> Categories { get; }

        public int VehicleParkId { get; }

        public string? RenterId { get; } 
        public bool ForRepearing { get; } 
        public bool ForCleaning { get; }
        public DateTime? MomenOfRent { get; }
        public DateTime? MomenOfLeave { get; }
        public string? FailureDescription { get; }

        public int? RepairsCount { get; }

        public int? RentsCount { get; }
        public IEnumerable<PartsOrder> OrderedParts { get; } 
    }
}
