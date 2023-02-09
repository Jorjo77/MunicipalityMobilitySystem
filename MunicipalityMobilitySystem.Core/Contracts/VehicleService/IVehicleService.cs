//using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
//using MunicipalityMobilitySystem.Core.Models;
//using MunicipalityMobilitySystem.Core.Models.Category;
//using MunicipalityMobilitySystem.Core.Models.Vehicle;
//using MunicipalityMobilitySystem.Core.Models.VehiclePark;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MunicipalityMobilitySystem.Core.Contracts.VehicleService
//{
//    public interface IVehicleService
//    {
//        Task<IEnumerable<VehicleServiceDetailsModel>> AllVehicleServices();

//        Task<VehicleServiceDetailsModel> VehicleServiceDetailsById(int id);

//        //Task<VehicleQueryModel> AllVehiclesByVehicleParkId(
//        //    int VehicleParkId,
//        //    string category = null,
//        //    string searchTerm = null,
//        //    VehiclesSorting sorting = VehiclesSorting.Newest,
//        //    int currentPage = 1,
//        //    int vehiclesPerPage = 1);

//        Task<bool> Exists(int id);
//        Task Create(VehicleServiceDetailsModel model);
//        Task<bool> VehiceServiceExistsByNameAndVehicleParkName(string name, string vehicleParkName);

//        Task Delete(int vehicleServiceId);
//        Task<VehicleServiceDetailsModel> VehicleServiceDetails(int id);
                                   
//        Task EditVehicleService(int id, VehicleServiceDetailsModel model);
//    }
//}
