using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using static MunicipalityMobilitySystem.Areas.Admin.Constants.AdminConstants;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRolleName)]
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        //"MakeRole" with Service MakeRole without view

        //"AddUserToRole"  with Service AddUserToRole with view - use 

    }
}
