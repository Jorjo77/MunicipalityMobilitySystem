using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Models;
using System.Diagnostics;

using static MunicipalityMobilitySystem.Areas.Admin.Constants.AdminConstants;

namespace MunicipalityMobilitySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleParkService vehicleParkService;

        public HomeController(
            IVehicleParkService vehicleParkService)
        {
            this.vehicleParkService = vehicleParkService;
        }
        public async Task<IActionResult> Index()
        {
            //if (User.IsInRole(AdminRolleName))
            //{
            //    return RedirectToAction("Index", "Admin", new { area = "Admin" });
            //}

            var model = await vehicleParkService.AllVehicleParks();
    
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}