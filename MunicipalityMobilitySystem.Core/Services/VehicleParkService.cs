using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Category;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Core.Models.VehiclePark;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;

namespace MunicipalityMobilitySystem.Core.Services
{
    public class VehicleParkService : IVehicleParkService
    {
        private readonly IRepository repo;

        private readonly IGuard guard;

        private readonly ILogger logger;

        public VehicleParkService(IRepository repo,
                                  IGuard guard,
                                  ILogger<VehicleParkService> logger)
        {
            this.repo = repo;
            this.guard = guard;
            this.logger = logger;
        }

        public async Task<IEnumerable<VehicleParkModel>> AllVehicleParks()
        {
            return await repo.AllReadonly<VehiclePark>()
                .OrderBy(vp => vp.Name)
                .Select(vp => new VehicleParkModel
                {
                    Id = vp.Id,
                    Name = vp.Name,
                    Adress = vp.Adress,
                    Email = vp.Email,
                    Phone = vp.Phone,
                    ImageUrl = vp.ImageUrl
                }).ToListAsync();
        }


        public async Task<VehicleQueryModel> AllVehiclesByVehicleParkId(
            int id,
            string? category = null, 
            string? searchTerm = null, 
            VehiclesSorting sorting = VehiclesSorting.Newest,
            int currentPage = 1, 
            int vehiclesPerPage = 1)
        {
            var result = new VehicleQueryModel();

            var vehicles =  repo.AllReadonly<Vehicle>()
                .Where(v => v.VehicleParkId == id)
                .Where(v=>v.ForCleaning == false);

            if (!string.IsNullOrEmpty(category))
            {
                vehicles = vehicles
                    .Where(v => v.Category.Name == category);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = $"%{searchTerm.ToLower()}";

                vehicles = vehicles
                    .Where(v =>EF.Functions.Like(v.Model.ToLower(), searchTerm) ||
                   EF.Functions.Like(v.VehiclePark.Adress.ToLower(), searchTerm)||
                   EF.Functions.Like(v.Description.ToLower(), searchTerm));
                    
            }

            switch (sorting)
            {
                case VehiclesSorting.Price:
                    vehicles = vehicles.OrderBy(v => v.PricePerHour);
                    break;
                case VehiclesSorting.Rating:
                    vehicles = vehicles.OrderByDescending(v => v.Rating);
                    break;
                default:
                    vehicles = vehicles.OrderByDescending(v => v.Id);
                    break;
            }

            result.Vehicles = await vehicles
                .Skip((currentPage - 1) * vehiclesPerPage)
                .Take(vehiclesPerPage)
                .Include(v=>v.VehiclePark)
                .Select(v => new VehicleServiceModel
                {
                    Id = v.Id,
                    ImageUrl = v.ImageUrl,
                    VehicleParkId = v.VehicleParkId,
                    CategoryId = v.CategoryId,
                    Description = v.Description,
                    EngineType = v.EngineType,
                    Model = v.Model,
                    PricePerHour = v.PricePerHour,
                    Rating = v.Rating,
                    RenterId = v.RenterId,
                })
                .ToListAsync();

            result.TotalVehiclesCount = await vehicles.CountAsync();

            return result;
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<VehiclePark>()
                .AnyAsync(vp => vp.Id == id);
        }

        public async Task<VehicleParkDetailsModel> VehicleParkDetailsById(int id)
        {
            return await repo.AllReadonly<VehiclePark>()
                .Where(vp => vp.Id == id)
                .Select(vp => new VehicleParkDetailsModel
                {
                    Id = vp.Id,
                    Name = vp.Name,
                    Email = vp.Email,
                    Phone = vp.Phone,
                    Adress = vp.Adress,
                    ImageUrl = vp.ImageUrl,
                    Description = vp.Description
                }).FirstAsync();
        }
    }
}
