namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
        public decimal TotalPrice { get; set; }
    }
}
