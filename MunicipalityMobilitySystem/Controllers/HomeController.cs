//using Microsoft.AspNetCore.Mvc;
//using MunicipalityMobilitySystem.Core.Contracts;
//using MunicipalityMobilitySystem.Core.Models;
//using MunicipalityMobilitySystem.Models;
//using System.Diagnostics;

//namespace MunicipalityMobilitySystem.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly IVehicleService homeService;

//        public HomeController(
//            IVehicleService homeService)
//        {
//            this.homeService = homeService;
//        }
//        public async Task<IActionResult> Index()
//        {
//            //if (User.IsInRole(AdminRolleName))
//            //{
//            //    return RedirectToAction("Index", "Admin", new { area = "Admin" });
//            //}

//            var bikeModel = await homeService.LastTopRankedBike();
//            var scooterModel = await homeService.LastTopRankedScooter();
//            var carModel = await homeService.LastTopRankedCar();
//            var truckModel = await homeService.LastTopRankedTruck();

//            //IndexViewModel is not used, here may have to use it!????????????
//            ViewBag.Bike = bikeModel;
//            ViewBag.Scooter = scooterModel;
//            ViewBag.Car = carModel;
//            ViewBag.Truck = truckModel;

//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}