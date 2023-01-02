using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;

namespace MunicipalityMobilitySystem.Controllers
{
    public class VehicleParkController : Controller
    {
        private readonly IVehicleParkService vehicleParkService;

        public VehicleParkController(IVehicleParkService vehicleParkService)
        {
            this.vehicleParkService = vehicleParkService;
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
    }
}
