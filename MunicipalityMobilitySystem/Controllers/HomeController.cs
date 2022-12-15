﻿using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Models;
using MunicipalityMobilitySystem.Models.Home;
using System.Diagnostics;

namespace MunicipalityMobilitySystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new IndexViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}