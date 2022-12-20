using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityMobilitySystem.Core.Contracts
{
    public interface IVehicleCategoryServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
