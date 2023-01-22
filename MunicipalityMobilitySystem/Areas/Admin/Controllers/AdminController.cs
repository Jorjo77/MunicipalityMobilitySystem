using Microsoft.AspNetCore.Mvc;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
