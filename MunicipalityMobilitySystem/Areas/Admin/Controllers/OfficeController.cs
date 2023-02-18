using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MunicipalityMobility.Core.Services.Admin;
using MunicipalityMobilitySystem.Areas.Admin.Models;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Core.Models.VehiclePark;
using MunicipalityMobilitySystem.Core.Services;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class OfficeController : BaseController
    {
        private readonly IOfficeService officeService;
        private readonly IWashingCenterService washingCenterService;
        private readonly INotyfService notyf;
        public OfficeController(IOfficeService _officeService,
                   IWashingCenterService _washingCenterService,
                    INotyfService _notif)
        {
            officeService= _officeService;
            washingCenterService= _washingCenterService;
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

        [HttpPost]
        public async Task<IActionResult> SetForRepairing(int id)
        {
            await officeService.SetVehicleForRepairing(id);

            notyf.Information("You successfuly send vehicle for repairing");

            return RedirectToAction(nameof(Index));
        }
    }
}
