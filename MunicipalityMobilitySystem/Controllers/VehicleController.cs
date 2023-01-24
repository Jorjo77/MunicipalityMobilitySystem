using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Constants;
using MunicipalityMobilitySystem.Core.Contracts.Category;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Core.Services;
using MunicipalityMobilitySystem.Extensions;
using MunicipalityMobilitySystem.Models;
using static MunicipalityMobilitySystem.Areas.Admin.Constants.AdminConstants;

namespace MunicipalityMobilitySystem.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly ICategoryService categoryService;

        public VehicleController(
            IVehicleService vehicleService,
            ICategoryService categoryService)
        {
            this.vehicleService = vehicleService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Mine()
        {

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

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if ((await vehicleService.Exists(id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "The vehicle do not exists!";

                return RedirectToAction("All", "VehiclePark");
            }

            if (await vehicleService.IsRented(id))
            {
                TempData[MessageConstant.ErrorMessage] = "The vehicle is already rented!";

                return RedirectToAction("All", "VehiclePark");
            }

            await vehicleService.Rent(id, User.Id());

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (await vehicleService.Exists(id) == false) 
            {
                TempData[MessageConstant.ErrorMessage] = "The vehicle do not exists!";

                RedirectToAction("All", "VehiclePark");
            }

            if (await vehicleService.IsRented(id) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "The vehicle is not rented!";

                RedirectToAction("All", "VehiclePark");
            }

            if (await vehicleService.IsRentedByUserWithId(id, User.Id()) == false)
            {
                RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await vehicleService.Leave(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
