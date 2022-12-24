using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Models.Vehicles;

namespace MunicipalityMobilitySystem.Controllers
{
    [Authorize]
    public class VehiclesController : Controller
    {
        [AllowAnonymous]
        public IActionResult All()
        {
            return View(new AllVehiclesQueryModel());
        }

        public IActionResult Mine()
        {
            return View(new AllVehiclesQueryModel());
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
