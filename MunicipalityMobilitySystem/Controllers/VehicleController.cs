using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Category;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Extensions;
using MunicipalityMobilitySystem.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace MunicipalityMobilitySystem.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly ICategoryService categoryService;
        private readonly INotyfService notyf;

        public VehicleController(
            IVehicleService vehicleService,
            ICategoryService categoryService,
            INotyfService notyf)
        {
            this.vehicleService = vehicleService;
            this.categoryService = categoryService;
            this.notyf = notyf;
        }

        public async Task<IActionResult> All([FromQuery] AllVehicleQueryModel queryModel)
        {
            var result = await vehicleService.AllVehicles(
                queryModel.Category,
                queryModel.SearchTerm,
                queryModel.Sorting,
                queryModel.CurrentPage,
                AllVehicleQueryModel.VehiclesPerPage
            );

            queryModel.TotalVehiclesCount = result.TotalVehiclesCount;
            queryModel.Categories = await categoryService.AllCategoriesNames();
            queryModel.Vehicles = result.Vehicles;


            return View(queryModel);
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
                return RedirectToAction("All", "VehiclePark");
            }

            if (await vehicleService.IsRented(id))
            {
                return RedirectToAction("All", "VehiclePark");
            }

            await vehicleService.Rent(id, User.Id());

            notyf.Success("Great choise! The key is waiting you in office manager of the selected vehicle park. Have a nice drive!");

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (await vehicleService.Exists(id) == false) 
            {

                RedirectToAction("All", "VehiclePark");
            }

            if (await vehicleService.IsRented(id) == false)
            {
                RedirectToAction("All", "VehiclePark");
            }

            if (await vehicleService.IsRentedByUserWithId(id, User.Id()) == false)
            {
                RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await vehicleService.Leave(id);

            notyf.Success("Thank you for use our services! Your bill will be send as soon as posible. Have a nice day, and see you soon!");

            return RedirectToAction("LeaveFeedback", "Vehicle",  new { id, area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> LeaveFeedback(int id)
        {
            if ((await vehicleService.Exists(id)) == false)
            {
                return RedirectToAction("All", "Vehicle", new { area = "" });
            }


            var vehicle = await vehicleService.VehicleDetails(id);

            var model = new VehicleDetailsFeedbackServiceModel()
            {
                Id = id,
                Model = vehicle.Model,
                Rating = vehicle.Rating,
                ImageUrl = vehicle.ImageUrl,
                UserId = vehicle.RenterId

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LeaveFeedback(int id, VehicleDetailsFeedbackServiceModel vehicleModel)
        {

            await vehicleService.AddFeedback(id, vehicleModel);

            notyf.Success("Thank you for your feedback, it helps us to be better!");

            return RedirectToAction(nameof(Mine));
        }
    }
}
