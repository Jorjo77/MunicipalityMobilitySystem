using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Category;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Models;

namespace MunicipalityMobilitySystem.Controllers
{
    public class VehicleParkController : Controller
    {
        private readonly IVehicleParkService vehicleParkService;
        private readonly ICategoryService categoryService;

        public VehicleParkController(IVehicleParkService vehicleParkService, ICategoryService categoryService)
        {
            this.vehicleParkService = vehicleParkService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Details(int id)
        {
            if ((await vehicleParkService.Exists(id)) == false)
                {
                    return RedirectToAction("Index", "Home");
                }

            var model = await vehicleParkService.VehicleParkDetailsById(id);

            return View(model);
        }

        public async Task<IActionResult> All(int id, [FromQuery]AllVehicleQueryModel queryModel)
        {
            var result = await vehicleParkService.AllVehiclesByVehicleParkId( id,
                queryModel.Category,
                queryModel.SearchTerm,
                queryModel.Sorting,
                queryModel.CurrentPage,
                AllVehicleQueryModel.VehiclesPerPage
                );

            queryModel.TotalVehiclesCount = result.TotalVehiclesCount;
            queryModel.Categories = await categoryService.AllCategoriesNames();
            queryModel.Vehicles = result.Vehicles;


            return View(queryModel);

        }
    }
}
