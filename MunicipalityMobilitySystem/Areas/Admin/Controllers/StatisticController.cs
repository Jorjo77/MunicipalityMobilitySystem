using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Admin;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Boss")]
    public class StatisticController : BaseController
    {
        private readonly IStatisticService statisticService;
        private readonly IUserService userService;

        public StatisticController(IStatisticService _statisticService, IUserService _userService)
        {
            statisticService = _statisticService;
            userService = _userService;
        }


        public IActionResult Index()
        {
            var model = statisticService.GetStatistic();  

            return View(model);
        }

        public IActionResult VehicleStatisticDetails(int id) 
        {
            var model = statisticService.GetVehicleStatisticDetailsById(id);

            model.Bills = statisticService.AllBillsByVehicleId(id);

            foreach (var bill in model.Bills)
            {
                string userName = userService.GetUserNameById(bill.RenterId);
                bill.RenterId = userName;
            }

            model.Orders = statisticService.AllOrdersByVehicleId(id);
            model.CustomerFeedback = statisticService.AllCustomerFeedbacksByVehicleId(id);

            foreach (var customerFeedback in model.CustomerFeedback) 
            {
                string userName = userService.GetUserNameById(customerFeedback.UserId);
                customerFeedback.UserId = userName;
            }

            return View(model);

        }
    }
}
