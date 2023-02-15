using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobility.Core.Services.Admin;
using MunicipalityMobilitySystem.Core.Contracts.Admin;


namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class OfficeController : BaseController
    {
        private readonly IOfficeService officeService;
        private readonly INotyfService notyf;
        public OfficeController(IOfficeService _officeService,
                    INotyfService _notif)
        {
            officeService= _officeService;
            notyf= _notif;
        }
        public async Task<IActionResult> Index()
        {
            var model = await officeService.GetLivedVehicles();

            return View(model);
        }
    }
}
