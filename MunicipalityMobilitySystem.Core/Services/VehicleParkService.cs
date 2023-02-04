using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.VehiclePark;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models;
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

        public async Task<IEnumerable<VehicleParkDetailsModel>> AllVehicleParks()
        {
            return await repo.AllReadonly<VehiclePark>()
                .OrderBy(vp => vp.Name)
                .Select(vp => new VehicleParkDetailsModel
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

            var vehicles = repo.AllReadonly<Vehicle>()
                .Where(v => v.VehicleParkId == id)
                .Where(v => v.ForCleaning == false);

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

        public async Task Create(VehicleParkDetailsModel model)
        {
            var vehiclePark = new VehiclePark
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Adress = model.Adress,
                Phone = model.Phone,
                Email = model.Email
            };

            try
            {
                await repo.AddAsync(vehiclePark);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
        }
        public async Task Delete(int vehicleParkId)
        {
            var vehiclePark = await repo.GetByIdAsync<VehiclePark>(vehicleParkId);
            repo.Delete(vehiclePark);

            await repo.SaveChangesAsync();
        }

        public async Task EditVehiclePark(int id, VehicleParkDetailsModel model)
        {
            var vehiclePark = await repo.GetByIdAsync<VehiclePark>(id);


            vehiclePark.Id= model.Id;
            vehiclePark.Name = model.Name;
            vehiclePark.Email = model.Email;
            vehiclePark.Phone = model.Phone;
            vehiclePark.Adress = model.Adress;
            vehiclePark.ImageUrl = model.ImageUrl;
            vehiclePark.Description = model.Description;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<VehiclePark>()
                .AnyAsync(vp => vp.Id == id);
        }

        public async Task<bool> VehiceParkExistsByNameEmailAndDescription(string name, string email, string description)
        {
            return await repo.AllReadonly<VehiclePark>()
                .Where(vp=>vp.Name == name &&
                vp.Email == email &&
                vp.Description == description)
                .AnyAsync();
        }
        public async Task<VehicleParkDetailsModel> VehicleParkDetails(int id)
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
                            Description = vp.Description,
                        })
                        .FirstAsync();
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
                })
                .FirstAsync();
        }
    }
}
