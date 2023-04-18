using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Services.Admin;

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

        public async Task<IActionResult> Index()
        {
            var model = await repairCenterService.GetRepairCenters();

            foreach (var repairCenter in model)
            {

                if ((await repairCenterService.Exists(repairCenter.Id)) == false)
                {
                    notyf.Error("The repair center do not exists!");
                    ModelState.AddModelError("", "The repair center do not exists!");
                    return RedirectToAction(nameof(Index));
                }

                repairCenter.VehiclesForRepair = await repairCenterService.GetVehiclesForRepair(repairCenter.Id);
            }

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

        [HttpPost]
        public async Task<IActionResult> Repair(int id)
        {
            await repairCenterService.RepairVehicle(id);

            notyf.Information("The vehicle was repaired and sent for washing");

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CreateOrder(int id)
        {
            var vehicle = await repairCenterService.GetVehicleForRepairById(id);

            var model = new PartsOrderServiceModel
            {
                VehicleId = id,
                RegistrationNumber = vehicle.RegistrationNumber,
                Title = $"{vehicle.Model} - {DateTime.UtcNow}",
                Expenses = new List<ExpenseServiceModel>(),
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(PartsOrderServiceModel queryModel)
        {
            
            if (ModelState.IsValid == false)
            {
                return View(queryModel);
            }

            if (await repairCenterService.ExistsOrder(queryModel) == true)
            {
                notyf.Error("The order already exists!");
                ModelState.AddModelError("", "The order already exists!");
                return View(queryModel);
            }

            await repairCenterService.CreateOrder(queryModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (await repairCenterService.ExistsOrderById(id) == false)
            {
                notyf.Error("Order do not exists!");
            }

            await repairCenterService.DeleteOrder(id);

            notyf.Success("Order is now deleted");

            return RedirectToAction(nameof(AllOrders));
        }

        public async Task<IActionResult> AllOrders()
        {
            var model = await repairCenterService.GetOrders();

            return View(model);
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            var order = await repairCenterService.GetOrderById(id);

            var expenses = await repairCenterService.GetExpensesByOrderId(id);

            var model = new OrderDetailsViewModel
            {
                Id = order.Id,
                Title = order.Title,
                TotalPrice = order.TotalPrice,
                RegistrationNumber = order.RegistrationNumber,
                Expenses = expenses,
            };

            return View(model);
        }
    }
}
