using MunicipalityMobilitySystem.Core.Contracts;

namespace MunicipalityMobilitySystem.Core.Models.Category
{
    public class CategoryServiceModel : ICategoryServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
