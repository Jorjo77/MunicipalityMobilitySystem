using MunicipalityMobilitySystem.Core.Models.Category;

namespace MunicipalityMobilitySystem.Core.Contracts.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<string>> AllCategoriesNames();
        Task<IEnumerable<VehicleParkServiceModel>> AllCategories();
    }
}
