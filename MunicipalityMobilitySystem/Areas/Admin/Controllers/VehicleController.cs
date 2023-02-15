using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Category;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Extensions;
using MunicipalityMobilitySystem.Models;
using System.Data;
using static MunicipalityMobilitySystem.Areas.Admin.Constants.AdminConstants;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRolleName)]
    public class VehicleController : BaseController
    {
        private readonly IVehicleService vehicleService;
        private readonly ICategoryService categoryService;

        public VehicleController(IVehicleService vehicleService, ICategoryService categoryService)
        {
            this.vehicleService = vehicleService;
            this.categoryService = categoryService;
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

            if ((await vehicleService.VehiceExists(model.RegistrationNumber)) == true)
            {
                ModelState.AddModelError("", "The vehicle already exists!");

                return View(model);
            }

            await vehicleService.Create(model);

            return RedirectToAction("All", "Vehicle", new { area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await vehicleService.Exists(id)) == false)
            {
                return RedirectToAction("All", "Vehicle", new { area = "" });
            }


            var vehicle = await vehicleService.VehicleDetails(id);
            var categoryId = await vehicleService.GetVehicleCategoryId(id);

            var model = new CreateVehicleModel()
            {
                Id = id,
                RegistrationNumber = vehicle.RegistrationNumber,
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
                return RedirectToAction("All", "Vehicle", new { area = "" });
            }
            await vehicleService.Delete(id);

            return RedirectToAction("All", "Vehicle", new { area = "" });
        }
    }
}
