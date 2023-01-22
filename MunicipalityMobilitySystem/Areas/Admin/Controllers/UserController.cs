using Microsoft.AspNetCore.Mvc;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
