using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Models.VehiclePark;

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

        public IActionResult Edit()
        {
            return View();
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
