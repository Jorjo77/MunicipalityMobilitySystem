using MunicipalityMobilitySystem.Core.Contracts.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MunicipalityMobilitySystem.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MunicipalityMobilitySystem.Core.Models.Admin;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace MunicipalityMobilitySystem.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserService userService;
        private readonly INotyfService notyf;


        public UserController(UserManager<IdentityUser> _userManager,                
                         RoleManager<IdentityRole> _roleManager, 
                         IUserService _userService,
                         INotyfService _notyf)
        {
           userManager = _userManager;
           roleManager = _roleManager;
           userService = _userService;
           notyf = _notyf;
        }

        //For Controller: Index(AllUsers), CreateRole, Roles, Forget, 
        public async Task<IActionResult> Index()
        {
            var model = await userService.GetUsers();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            bool result = await userService.Delete(id);

            if (result)
            {
                notyf.Success("User is now deleted");
            }
            else
            {
                notyf.Error("User is undeletable");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            bool result = await userService.DeleteRole(id);

            if (result)
            {
                notyf.Success("Role is deleted");
            }
            else
            {
                notyf.Error("Role is undeletable");
            }

            return RedirectToAction(nameof(CreateRole));
        }
        public IActionResult CreateRole()
        {
            var model = new RoleViewModel();

            ViewBag.RoleNames = roleManager.Roles
                .ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {

            if (await userService.CreateRole(roleName) == false)
            {
                notyf.Error("The role already exists!");
                ModelState.AddModelError("", "The role already exists!");
            }

            notyf.Information("You successfuly create the role");

            return RedirectToAction(nameof(CreateRole));
        }

        public async Task<IActionResult> Roles(string id)
        {
            var user = await userService.GetUserById(id);
            var model = new UserRolesViewModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
            };

            ViewBag.RoleItems = roleManager.Roles
                .ToList()
                .Select(r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Name,
                    Selected = userManager.IsInRoleAsync(user, r.Name).Result,
                }).ToList();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Roles(UserRolesViewModel model)
        {
            var user = await userService.GetUserById(model.UserId);
            var userRoles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, userRoles);
            if (model.RoleNames?.Length > 0)
            {
                try
                {
                    await userManager.AddToRolesAsync(user, model.RoleNames);
                    notyf.Information("Syccsessfully added user to role!");
                }
                catch (Exception ex)
                {
                    notyf.Error("Something went wrong");
                    ModelState.AddModelError("", "Something went wrong");
                    throw new ApplicationException("Database failed to save info", ex);
                }
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
