using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Models.Vehicle;

namespace MunicipalityMobilitySystem.Controllers
{
    [Authorize]
    public class VehiclesController : Controller
    {
        private readonly IVehicleService vehicleService;

        public VehiclesController(
            IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Types()
        {
            //if (User.IsInRole(AdminRolleName))
            //{
            //    return RedirectToAction("Index", "Admin", new { area = "Admin" });
            //}

            var bikeModel = await vehicleService.GetOneBike();
            var scooterModel = await vehicleService.GetOneScooter();
            var carModel = await vehicleService.GetOneCar();

            ViewBag.Bike = bikeModel;
            ViewBag.Scooter = scooterModel;
            ViewBag.Car = carModel;

            return View();
        }

        public IActionResult All()
        {
            return View(new VehicleServiceModel());
        }

        public IActionResult Mine()
        {
            return View(new VehicleServiceModel());
        }

        public IActionResult Details(int Id)
        {
            return View(new VehicleDetailsViewModel());
        }

        [HttpPost]
        public IActionResult Rent(int id) 
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public IActionResult Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
