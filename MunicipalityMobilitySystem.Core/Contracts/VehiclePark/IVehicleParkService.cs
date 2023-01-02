using MunicipalityMobilitySystem.Core.Models.VehiclePark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityMobilitySystem.Core.Contracts.VehiclePark
{
    public interface IVehicleParkService
    {
        Task<VehicleParkDetailsModel> DetailsById(int Id);
        Task<IEnumerable<VehicleParkModel>> AllVehicleParks();

        Task<VehicleParkDetailsModel> VehicleParkDetailsById(int id);

        Task<bool> Exists(int id);
    }
}
