using MunicipalityMobilitySystem.Core.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MunicipalityMobilitySystem.Core.Contracts.Admin
{
    public interface IUserService
    {
        Task<IEnumerable<UserServiceModel>> GetUsers();
        Task<IdentityUser> GetUserById(string id);
        string GetUserNameById(string id);
        Task<bool> Delete(string userId);
        Task<bool> CreateRole(string userId);
        Task<bool> DeleteRole(string id);
    }
}
