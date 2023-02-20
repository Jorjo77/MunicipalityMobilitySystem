﻿using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Models;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Extensions;
using System.Diagnostics;

using static MunicipalityMobilitySystem.Areas.Admin.Constants.AdminConstants;

namespace MunicipalityMobilitySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleParkService vehicleParkService;
        private readonly IOfficeService officeService;

        public HomeController(
            IVehicleParkService _vehicleParkService,
            IOfficeService _officeService)
        {
            vehicleParkService = _vehicleParkService;
            officeService = _officeService;
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

        public async Task<IActionResult> MineBills()
        {

            IEnumerable<TheBillViewModel> myBills = Enumerable.Empty<TheBillViewModel>();

            string userId = User.Id();

            myBills = await officeService.AllBillsByUserId(userId);

            return View(myBills);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}