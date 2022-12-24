using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static MunicipalityMobilitySystem.Data.DataConstants.Service;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(VehiclePark))]
        public int VehicleWParkId { get; set; }
        [Required]
        public VehiclePark VehiclePark { get; set; } = null!;

        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
