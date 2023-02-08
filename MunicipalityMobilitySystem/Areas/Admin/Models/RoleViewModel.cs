using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using static MunicipalityMobilitySystem.Data.DataConstants.RoleName;
namespace MunicipalityMobilitySystem.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string RoleName { get; set; } = null!;
    }
}
