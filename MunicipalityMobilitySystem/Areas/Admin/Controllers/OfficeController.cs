using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;

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

        [HttpPost]
        public async Task<IActionResult> MakeTheBill(int id)
        {
            var vehicle = await officeService.GetLeftVehicleById(id);

            if (await officeService.BillExists(vehicle) == true)
            {
                notyf.Warning("The bill already exists and was send to the client!");

                return RedirectToAction(nameof(Index));
            }

            await officeService.MakeAndPostTheBill(vehicle);

            notyf.Information("You successfuly create and send the bill");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AllBills()
        {
            var model = await officeService.GetTheBills();

            return View(model);
        }

        public async Task<IActionResult> BillDetails(int id)
        {
            var model = await officeService.GetBillById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBill(int id)
        {
            await officeService.DeleteBillById(id);

            notyf.Success("Bill is deleted");

            return RedirectToAction(nameof(AllBills));
        }
    }
}
