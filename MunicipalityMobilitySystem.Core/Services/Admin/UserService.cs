using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Models.Admin;

namespace MunicipalityMobility.Core.Services.Admin
{
    public class UserService : IUserService
    {
        //private readonly IRepository repo;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(/*IRepository _repo*/
            UserManager<IdentityUser> _userManager,
            RoleManager<IdentityRole> _roleManager
            )
        {
            //repo = _repo;
            userManager= _userManager;
            roleManager= _roleManager;
        }
        public async Task<IEnumerable<UserServiceModel>> GetUsers()
        {
            return await userManager.Users
                .Select(u=> new UserServiceModel
                {
                   Id = u.Id,
                   UserName=u.UserName,
                })
                .ToListAsync();
        }

        public async Task<bool> CreateRole(string roleName)
        {
            IdentityResult roleResult;

            roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));

            return roleResult.Succeeded;
        }

        public async Task<bool> Delete(string id)
        {
            var user = await GetUserById(id);

            IdentityResult result = await userManager.DeleteAsync(user);

            return result.Succeeded;
        }


        public async Task<bool> DeleteRole(string id)
        {
            var role = await roleManager.Roles.Where(r=>r.Id == id)
                .FirstAsync();

            var result = await roleManager.DeleteAsync(role);

            return result.Succeeded;
        }

        public async Task<IdentityUser> GetUserById(string id)
        {
            return await userManager.FindByIdAsync(id);
        }
        public string GetUserNameById(string id)
        {
            var user = userManager.FindByIdAsync(id);
            return user.Result.UserName;
        }
    }
}
