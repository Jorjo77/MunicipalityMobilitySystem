using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Core.Models.VehiclePark;
using MunicipalityMobilitySystem.Core.Services;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class VehicleParkController : BaseController
    {
        private readonly IVehicleParkService vehicleParkService;

        public VehicleParkController(IVehicleParkService vehicleParkService)
        {
            this.vehicleParkService = vehicleParkService;
        }

        public async Task<IActionResult> AllVehicleParks()
        {
            var model = await vehicleParkService.AllVehicleParks();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new VehicleParkDetailsModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(VehicleParkDetailsModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if ((await vehicleParkService.VehiceParkExistsByNameEmailAndDescription(model.Name, model.Email, model.Description)) == true)
            {
                ModelState.AddModelError("", "The vehicle park already exists!");

                return View(model);
            }

            await vehicleParkService.Create(model);

            return RedirectToAction("AllVehicleParks", "VehiclePark", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await vehicleParkService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(AllVehicleParks));
            }


            var vehiclePark = await vehicleParkService.VehicleParkDetails(id);


            var model = new VehicleParkDetailsModel()
            {
                Id = id,
                Name = vehiclePark.Name,
                Adress = vehiclePark.Adress,
                Email= vehiclePark.Email,
                Phone = vehiclePark.Phone,
                ImageUrl = vehiclePark.ImageUrl,
                Description = vehiclePark.Description,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VehicleParkDetailsModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await vehicleParkService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Vehicle park does not exist");

                return View(model);
            }

            if (ModelState.IsValid == false)
            { 
                return View(model);
            }

            await vehicleParkService.EditVehiclePark(model.Id, model);
            return RedirectToAction("Details", "VehiclePark", new { id = model.Id, area = "" });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await vehicleParkService.Exists(id)) == false)
            {
                return RedirectToAction("AllVehicleParks", "VehiclePark", new { area = "Admin" });
            }
            await vehicleParkService.Delete(id);

            return RedirectToAction("AllVehicleParks", "VehiclePark", new { area = "Admin" });
        }
    }
}
