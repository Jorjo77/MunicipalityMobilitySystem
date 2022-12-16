using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Models.Bikes;

namespace MunicipalityMobilitySystem.Controllers
{
    [Authorize]
    public class BikesController : Controller
    {
        [AllowAnonymous]
        public IActionResult All()
        {
            return View(new AllBikesQueryModel());
        }

        public IActionResult Mine()
        {
            return View(new AllBikesQueryModel());
        }

        public IActionResult Details(int Id)
        {
            return View(new BikesDetailsViewModel());
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
