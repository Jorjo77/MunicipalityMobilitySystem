using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Category;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Services;
using MunicipalityMobilitySystem.Models;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly IVehicleService vehicleService;
        private readonly ICategoryService categoryService;

        public VehicleController(IVehicleService vehicleService, ICategoryService categoryService)
        {
            this.vehicleService = vehicleService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> All([FromQuery] AllVehicleQueryModel queryModel)
        {
            var result = await vehicleService.AllVehicles(
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

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
