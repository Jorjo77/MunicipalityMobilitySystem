using MunicipalityMobilitySystem.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityMobilitySystem.Core.Models
{
    public class VehicleCategoryServiceModel : IVehicleCategoryServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
