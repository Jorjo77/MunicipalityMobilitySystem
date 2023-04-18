namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public ICollection<ExpenseServiceModel> Expenses { get; set; } = new List<ExpenseServiceModel>();
    }
}
