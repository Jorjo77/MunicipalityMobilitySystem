using MunicipalityMobilitySystem.Core.Contracts.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MunicipalityMobilitySystem.Core.Models.Admin;
using AspNetCoreHero.ToastNotification.Abstractions;
using MunicipalityMobilitySystem.Core.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MunicipalityMobility.Core.Services.Admin;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class RepairCenterController : BaseController
    {
        private readonly IRepairCenterService repairCenterService;
        private readonly INotyfService notyf;
        public RepairCenterController(
                         IRepairCenterService _repairCenterService,
                         INotyfService _notyf)
        {
            repairCenterService = _repairCenterService;
            notyf = _notyf;
        }

        //For Controller: Index(AllUsers), CreateRole, Roles, Forget, 
        public async Task<IActionResult> Index()
        {
            var model = await repairCenterService.GetRepairCenters();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await repairCenterService.Exists(id) == false)
            {
                notyf.Error("Repair center do not exists!");
            }

            await repairCenterService.Delete(id);

            notyf.Success("Repair center is now deleted");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            var model = new RepairCenterDetailsServiceModel();

            ViewBag.RepairCentersName = await repairCenterService.GetRepairCenters();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RepairCenterDetailsServiceModel model)
        {

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            if (await repairCenterService.Exists(model.Id) == true)
            {
                notyf.Error("The repair center already exists!");
                ModelState.AddModelError("", "The repair center already exists!");
            }


            await repairCenterService.Create(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            if ((await repairCenterService.Exists(id)) == false)
            {
                notyf.Error("The repair center do not exists!");
                ModelState.AddModelError("", "The repair center do not exists!");
                return RedirectToAction(nameof(Index));
            }
            var repairCenter = await repairCenterService.GetRepairCenterById(id);
            var model = new RepairCenterServiceModel()
            {
                Id = repairCenter.Id,
                Name = repairCenter.Name,
                ImageUrl = repairCenter.ImageUrl,
                Adress = repairCenter.Adress,
            };

            ViewBag.VehiclesForRepair = await repairCenterService.GetVehiclesForRepair(repairCenter.Id); 

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Repair(int id)
        {
            await repairCenterService.RepairVehicle(id);

            notyf.Information("The vehicle was repaired and sent for washing");

            return RedirectToAction(nameof(Index));
        }
    }
}
