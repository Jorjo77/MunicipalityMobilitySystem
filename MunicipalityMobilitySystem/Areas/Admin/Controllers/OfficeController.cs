using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobility.Core.Services.Admin;
using MunicipalityMobilitySystem.Areas.Admin.Models;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Core.Models.VehiclePark;
using MunicipalityMobilitySystem.Core.Services;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class OfficeController : BaseController
    {
        private readonly IOfficeService officeService;
        private readonly INotyfService notyf;
        public OfficeController(IOfficeService _officeService,
                    INotyfService _notif)
        {
            officeService= _officeService;
            notyf= _notif;
        }
        public async Task<IActionResult> Index()
        {
            var model = await officeService.GetLeftVehicles();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> CreateFailureDescription(int id)
        {
            var model = await officeService.GetLeftVehicleById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFailureDescription(VehicleDetailsViewModel model)
        {

            await officeService.EditLeftVehicleById(model);

            notyf.Information("You successfuly create failure description");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SetForCleaning(int id)
        {
            await officeService.SetVehicleForCleaning(id);

            notyf.Information("You successfuly send vehicle for cleaning");

            return RedirectToAction(nameof(Index));
        }
    }
}
