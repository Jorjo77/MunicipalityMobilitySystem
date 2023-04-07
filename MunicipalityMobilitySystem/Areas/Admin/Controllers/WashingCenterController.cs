using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobility.Core.Services.Admin;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Services.Admin;
using MunicipalityMobilitySystem.Models;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class WashingCenterController : BaseController
    {
        private readonly IWashingCenterService washingCenterService;
        private readonly INotyfService notyf;
        public WashingCenterController(
                         IWashingCenterService _washingCenterService,
                         INotyfService _notyf)
        {
            washingCenterService = _washingCenterService;
            notyf = _notyf;
        }

        public async Task<IActionResult> Index()
        {

            var model = await washingCenterService.GetWashingCenters();

            foreach (var washingCenter in model)
            {

                if ((await washingCenterService.Exists(washingCenter.Id)) == false)
                {
                    notyf.Error("The washing center do not exists!");
                    ModelState.AddModelError("", "The washing center do not exists!");
                    return RedirectToAction(nameof(Index));
                }

                washingCenter.VehiclesForCleaning = await washingCenterService.GetVehiclesForWashing(washingCenter.Id);
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await washingCenterService.Exists(id) == false)
            {
                notyf.Error("Washing center do not exists!");
            }

            await washingCenterService.Delete(id);

            notyf.Success("Washing center is now deleted");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            var model = new WashingCenterDetailsServiceModel();

            ViewBag.WashingCentersName = await washingCenterService.GetWashingCenters();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WashingCenterDetailsServiceModel model)
        {

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            if (await washingCenterService.Exists(model.Id) == true)
            {
                notyf.Error("The washing center already exists!");
                ModelState.AddModelError("", "The washing center already exists!");
            }


            await washingCenterService.Create(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Wash(int id)
        {
            await washingCenterService.WashVehicle(id);

            notyf.Information("The vehicle was cleaned and now is avaiable for renting");

            return RedirectToAction(nameof(Index));
        }
    }
}
