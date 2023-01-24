using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Models;

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
