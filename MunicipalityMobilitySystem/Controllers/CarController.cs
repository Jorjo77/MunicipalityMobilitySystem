using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Models.Scooters;

namespace MunicipalityMobilitySystem.Controllers
{
    [Authorize]
    public class CarController : Controller
    {

        public IActionResult All()
        {
            return View(new AllScootersQueryModel());
        }

        public IActionResult Mine()
        {
            return View(new AllScootersQueryModel());
        }

        public IActionResult Details(int Id)
        {
            return View(new AllScootersQueryModel());
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
