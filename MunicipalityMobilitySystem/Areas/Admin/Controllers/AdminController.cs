using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using static MunicipalityMobilitySystem.Areas.Admin.Constants.AdminConstants;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        [Authorize(Roles = AdminRolleName)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
