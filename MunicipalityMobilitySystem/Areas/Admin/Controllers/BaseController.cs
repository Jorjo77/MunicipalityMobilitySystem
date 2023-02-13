﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static MunicipalityMobilitySystem.Areas.Admin.Constants.AdminConstants;
using static MunicipalityMobilitySystem.Areas.Admin.Constants.RoleConstants;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = "Boss, Administrator, Manager, Mechanic, Cleaner")]



    public class BaseController : Controller
    {
    }
}
