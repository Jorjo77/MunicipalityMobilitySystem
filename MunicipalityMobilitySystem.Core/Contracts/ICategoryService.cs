using MunicipalityMobilitySystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityMobilitySystem.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<VehicleCategoryServiceModel>> AllCategories();
    }
}
