using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static MunicipalityMobilitySystem.Data.DataConstants.VehiclePark;

namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class VehiclePark
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(ParkNameMaxLength)]
        public string ParkName { get; set; } = null!;
        public IEnumerable<Bike> Bikes { get; set; } = new List<Bike>();
        public IEnumerable<Scooter> Scooters { get; set; } = new List<Scooter>();
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
        public IEnumerable<Truck> Trucks { get; set; } = new List<Truck>();
    }
}
