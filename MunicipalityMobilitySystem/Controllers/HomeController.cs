using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Models;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Extensions;
using System.Diagnostics;

using static MunicipalityMobilitySystem.Areas.Admin.Constants.RoleConstants;
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
            if (User.IsInRole(Boss))
            {
                return RedirectToAction("Index", "Statistic", new { area = "Admin" });
            }

            if (User.IsInRole(Mechanic))
            {
                return RedirectToAction("Index", "RepairCenter", new { area = "Admin" });
            }

            if (User.IsInRole(Cleaner))
            {
                return RedirectToAction("Index", "WashingCenter", new { area = "Admin" });
            }

            if (User.IsInRole(Manager))
            {
                return RedirectToAction("Index", "Office", new { area = "Admin" });
            }

            if (User.IsInRole(AdminRolleName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

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

        [HttpPost]
        public async Task<IActionResult> DeleteBill(int id)
        {
            await officeService.DeleteMyBillById(id);

            return RedirectToAction("MineBills", "Home", new { area = "" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}