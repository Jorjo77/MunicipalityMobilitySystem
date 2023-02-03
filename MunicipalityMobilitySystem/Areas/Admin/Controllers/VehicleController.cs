using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            if ((await vehicleService.CategoryExists(model.CategoryId)) == false)
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
                ModelState.AddModelError("", "The vehicle already exists!");

                return View(model);
            }

            await vehicleService.Create(model);

            return RedirectToAction("All", "Vehicle", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await vehicleService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }


            var vehicle = await vehicleService.VehicleDetails(id);
            var categoryId = await vehicleService.GetVehicleCategoryId(id);

            var model = new CreateVehicleModel()
            {
                Id = id,
                ModelName = vehicle.Model,
                Rating= vehicle.Rating,
                CategoryId = categoryId,
                Description = vehicle.Description,
                EngineType = vehicle.EngineType,
                ImageUrl = vehicle.ImageUrl,
                PricePerHour = vehicle.PricePerHour,
                VehicleParkId = vehicle.VehicleParkId,
                Categories = await categoryService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateVehicleModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await vehicleService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Vehicle does not exist");
                model.Categories = await categoryService.AllCategories();

                return View(model);
            }


            if ((await vehicleService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
                model.Categories = await categoryService.AllCategories();

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await categoryService.AllCategories();

                return View(model);
            }

            await vehicleService.Edit(model.Id, model);

            return RedirectToAction("Details", "Vehicle", new { id = model.Id, area = "" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await vehicleService.Exists(id)) == false)
            {
                return RedirectToAction("All", "Vehicle", new { area = "Admin" });
            }
            await vehicleService.Delete(id);

            return RedirectToAction("All", "Vehicle", new { area = "Admin" });
        }
    }
}
