using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Models;
using MunicipalityMobilitySystem.Core.Models.Category;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
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
        Task<IEnumerable<VehicleParkDetailsModel>> AllVehicleParks();

        Task<VehicleParkDetailsModel> VehicleParkDetailsById(int id);

        Task<VehicleQueryModel> AllVehiclesByVehicleParkId(
            int VehicleParkId,
            string category = null,
            string searchTerm = null,
            VehiclesSorting sorting = VehiclesSorting.Newest,
            int currentPage = 1,
            int vehiclesPerPage = 1);

        Task<bool> Exists(int id);
        Task Create(VehicleParkDetailsModel model);
        Task<bool> VehiceParkExistsByNameEmailAndDescription(string name, string email, string description);

        Task Delete(int vehicleParkId);
        Task<VehicleParkDetailsModel> VehicleParkDetails(int id);

        Task EditVehiclePark(int id, VehicleParkDetailsModel model);
    }
}
