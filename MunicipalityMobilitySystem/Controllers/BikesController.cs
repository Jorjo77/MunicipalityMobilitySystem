﻿using Microsoft.AspNetCore.Authorization;
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
            return View(new AllTrucksQueryModel());
        }

        public IActionResult Mine()
        {
            return View(new AllTrucksQueryModel());
        }

        public IActionResult Details(int Id)
        {
            return View(new TrucksDetailsViewModel());
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