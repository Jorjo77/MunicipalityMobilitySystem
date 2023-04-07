using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static MunicipalityMobilitySystem.Data.DataConstants.Expense;

namespace MunicipalityMobilitySystem.Core.Models.Admin;

public class ExpenseServiceModel
{
    [Required]
    [MaxLength(NameMaxLength)]
    [MinLength(NameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(QuantityMinValue, QuantityMaxValue)]
    public int Quantity { get; set; }

    [Required]
    [Precision(12, 2)]
    public decimal UnutPrice { get; set; }
}
