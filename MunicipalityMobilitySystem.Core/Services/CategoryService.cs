using Microsoft.EntityFrameworkCore;
using MunicipalityMobilitySystem.Core.Contracts.Category;
using MunicipalityMobilitySystem.Core.Models.Category;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;

namespace MunicipalityMobilitySystem.Core.Services
{

    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;

        public CategoryService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<CategoryServiceModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(c => c.Id)
                .Select(c => new CategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        Task<IEnumerable<CategoryServiceModel>> ICategoryService.AllCategories()
        {
            throw new NotImplementedException();
        }
    }
}
