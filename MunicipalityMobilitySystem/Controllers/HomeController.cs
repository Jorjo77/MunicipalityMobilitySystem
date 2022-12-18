﻿using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts;
using MunicipalityMobilitySystem.Core.Models;
using MunicipalityMobilitySystem.Models;
using System.Diagnostics;

namespace MunicipalityMobilitySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(
            IHomeService homeService)
        {
            this.homeService = homeService;
        }
        public async Task<IActionResult> Index()
        {
            //if (User.IsInRole(AdminRolleName))
            //{
            //    return RedirectToAction("Index", "Admin", new { area = "Admin" });
            //}

            var models = await homeService.LastTopRankedVehicles();

            return View(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}