using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Core.Contracts.Admin;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class StatisticController : BaseController
    {
        private readonly IStatisticService statisticService;

        public StatisticController(IStatisticService _statisticService)
        {
            statisticService= _statisticService;
        }

        [Authorize(Roles = "Boss")]
        public IActionResult Index()
        {
            var model = statisticService.GetStatistic();  

            return View(model);
        }
    }
}
