using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using static MunicipalityMobilitySystem.Areas.Admin.Constants.AdminConstants;
using static MunicipalityMobilitySystem.Areas.Admin.Constants.RoleConstants;

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
