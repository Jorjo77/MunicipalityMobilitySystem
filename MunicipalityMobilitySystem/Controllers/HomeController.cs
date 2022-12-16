using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Bike;
using MunicipalityMobilitySystem.Core.Contracts.Car;
using MunicipalityMobilitySystem.Core.Contracts.Scooter;
using MunicipalityMobilitySystem.Core.Contracts.Truck;
using MunicipalityMobilitySystem.Models;
using MunicipalityMobilitySystem.Models.Home;
using System.Diagnostics;

namespace MunicipalityMobilitySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBikeService bikeService;
        private readonly IScooterService scooterService;
        private readonly ICarService carService;
        private readonly ITruckService truckService;

        public HomeController(IBikeService bikeService,
            IScooterService scooterService,
            ICarService carService,
            ITruckService truckService)
        {
            this.bikeService = bikeService;
            this.scooterService = scooterService;
            this.carService = carService;
            this.truckService = truckService;
        }
        public async Task<IActionResult> Index()
        {
            //if (User.IsInRole(AdminRolleName))
            //{
            //    return RedirectToAction("Index", "Admin", new { area = "Admin" });
            //}


            var bikeModel = await bikeService.LastOneBike();
            var scooterModel = await scooterService.LastOneScooter();
            var carModel = await carService.LastOneCar();
            var truckModel = await truckService.LastOneTruck();

            ViewBag.Bike = bikeModel;
            ViewBag.Scooter = scooterModel;
            ViewBag.Car = carModel;
            ViewBag.Truck = truckModel;

            return View(ViewBag);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}