using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityMobilitySystem.Core.Contracts.Truck
{
    internal interface ITruckModel
    {
        public int Id { get; }

        public string Type { get; }

        public string ImageUrl { get; }

        public int Rating { get; }
    }
}
