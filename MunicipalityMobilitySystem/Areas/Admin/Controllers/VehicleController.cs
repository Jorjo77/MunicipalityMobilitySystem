using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Constants;
using MunicipalityMobilitySystem.Core.Contracts.Category;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Extensions;
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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CreateVehicleModel
            {
                Categories = await categoryService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateVehicleModel model)
        {
            if ((await vehicleService.CategoryExists(model.CategoryId))==false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.AllCategories();
                return View(model);
            }

            if ((await vehicleService.VehiceExistsByModelEngineTypeAndDescription(model.ModelName, model.EngineType, model.Description)) == true)
            {
                //ModelState.AddModelError("", "The vehicle already exists!");
                TempData[MessageConstant.ErrorMessage] = "The vehicle already exists!";
                return View(model);
            }

            await vehicleService.Create(model);

            TempData[MessageConstant.SuccessMessage] = "The vehicle was created!";

            return RedirectToAction("Index", "Admin", new { area = "Admin"});
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await vehicleService.Exists(id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "The vehicle do not exists!";
                return RedirectToAction("All", "Vehicle", new { area = "Admin" });
            }

            TempData[MessageConstant.WarningMessage] = "Are you sure you want to delete the vehicle?";
            await vehicleService.Delete(id);

            return RedirectToAction("All", "Vehicle", new { area = "Admin" });
        }
    }
}
