using MunicipalityMobilitySystem.Core.Models.Category;

namespace MunicipalityMobilitySystem.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryServiceModel>> AllCategories();
    }
}
