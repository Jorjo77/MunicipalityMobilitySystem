using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        [Authorize(Roles = "Boss, Administrator")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
