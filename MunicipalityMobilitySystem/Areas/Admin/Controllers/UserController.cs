using Microsoft.AspNetCore.Mvc;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
