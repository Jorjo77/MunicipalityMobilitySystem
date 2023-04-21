using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static MunicipalityMobilitySystem.Data.DataConstants.PartsOrder;

namespace MunicipalityMobilitySystem.Core.Models.Admin;

public class EditOrderServiceModel
{
    public int Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    [MinLength(TitleMinLength)]
    public string? Title { get; set; }
    [Required]
    public int VehicleId { get; set; }

    [Required]
    [Display(Name = "Reg. Number")]
    public string? RegistrationNumber { get; set; }

    public ICollection<ExpenseServiceModel> Expenses { get; set; } = new List<ExpenseServiceModel>();

    [Required]
    [Precision(12, 2)]
    public decimal TotalPrice { get; set; }
}
