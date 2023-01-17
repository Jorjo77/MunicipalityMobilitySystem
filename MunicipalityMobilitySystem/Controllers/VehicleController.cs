using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Extensions;

namespace MunicipalityMobilitySystem.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(
            IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }


        public IActionResult All()
        {
            return View(new VehicleServiceModel());
        }
        public async Task<IActionResult> Mine()
        {
            //if (User.IsInRole(AdminRolleName))
            //{
            //    return RedirectToAction("Mine", "House", new { area = AreaName });
            //}

            IEnumerable<VehicleServiceModel> myVehicles = Enumerable.Empty<VehicleServiceModel>();
            string userId = User.Id();

            myVehicles = await vehicleService.AllVehiclesByUserId(userId);
            
            return View(myVehicles);
        }

        public async Task<IActionResult> Details(int id)
        {

            var model = await vehicleService.VehicleDetails(id);

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Rent(int id)
        //{
        //    //It is for me!
        //    if ((await vehicleService.Exists(id)) == false)
        //    {
        //        return RedirectToAction(nameof(All));
        //    }

        //    //It is for me with different check!
        //    if (await vehicleService.IsRented(id))
        //    {
        //        return RedirectToAction(nameof(All));
        //    }

        //    await vehicleService.Rent(id, User.Id());

        //    return RedirectToAction(nameof(Mine));
        //}

        [HttpPost]
        public IActionResult Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
