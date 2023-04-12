using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models;
using MunicipalityMobilitySystem.Core.Models.Category;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;


namespace MunicipalityMobilitySystem.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repo;

        private readonly IGuard guard;

        private readonly ILogger logger;

        public VehicleService(
            IRepository repo,
            IGuard guard,
            ILogger<VehicleService> logger)
        {
            this.repo = repo;
            this.logger = logger;
            this.guard = guard;
        }

        public async Task<IEnumerable<VehicleServiceModel>> AllVehiclesByUserId(string id)
        {
            return await repo.AllReadonly<Vehicle>()
                .Where(v => v.RenterId == id 
                && v.MomenOfLeave == null
                && v.IsActive)
                .Select(v => new VehicleServiceModel
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber,
                    ImageUrl = v.ImageUrl,
                    VehicleParkId = v.VehicleParkId,
                    CategoryId = v.CategoryId,
                    Description = v.Description,
                    EngineType = v.EngineType,
                    Model = v.Model,
                    PricePerHour = v.PricePerHour,
                    Rating = v.Rating,
                    RenterId = v.RenterId
                })
                .ToListAsync();
        }

        public async Task<VehicleQueryModel> AllVehicles(string category = null,
                               string searchTerm = null,
                               VehiclesSorting sorting = VehiclesSorting.Newest,
                               int currentPage = 1,
                               int vehiclesPerPage = 1)
        {
            var result = new VehicleQueryModel();

            var vehicles = repo.AllReadonly<Vehicle>()
                .Where(v => v.IsActive);


            if (!string.IsNullOrEmpty(category))
            {
                vehicles = vehicles
                    .Where(v => v.Category.Name == category);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = $"%{searchTerm.ToLower()}";

                vehicles = vehicles
                    .Where(v => EF.Functions.Like(v.Model.ToLower(), searchTerm) ||
                   EF.Functions.Like(v.VehiclePark.Adress.ToLower(), searchTerm) ||
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
                    RegistrationNumber = v.RegistrationNumber,
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
            return await repo.AllReadonly<Vehicle>(v => v.Id == id && v.IsActive)
                .AnyAsync();
        }

        public async Task<bool> IsRented(int vehicleId)
        {
            return (await repo.GetByIdAsync<Vehicle>(vehicleId)).RenterId != null;
        }

        public async Task<bool> IsRentedByUserWithId(int vehicleId, string currentUserId)
        {
            return await repo.AllReadonly<Vehicle>()
                 .Where(v => v.Id == vehicleId && v.IsActive)
                 .AnyAsync(v => v.RenterId == currentUserId);
        }

        public async Task Leave(int vehicleId)
        {
            var vehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);

            if (vehicle != null && vehicle.RenterId == null)
            {
                throw new ArgumentException("Vehicle is not rented");
            }

            guard.AgainstNull(vehicle, "Vehicle can not be found");

            vehicle.MomenOfLeave = DateTime.Now;

            guard.AgainstNull(vehicle.MomenOfLeave, "Vehicle can not be found");
            guard.AgainstNull(vehicle.MomenOfRent, "Vehicle can not be found");

            vehicle.RentedPeriod = vehicle.MomenOfLeave.Value.Hour - vehicle.MomenOfRent.Value.Hour;

            vehicle.RentsCount++;

            await repo.SaveChangesAsync();
        }

        public async Task Rent(int vehicleId, string currentUserId)
        {
            var vehicleForRent = await repo.GetByIdAsync<Vehicle>(vehicleId);

            if (vehicleForRent != null && vehicleForRent.RenterId != null)
            {
                throw new ArgumentException("Vehicle is already rented");
            }

            guard.AgainstNull(vehicleForRent, "Vehicle can not be found");

            vehicleForRent.RenterId = currentUserId;
            vehicleForRent.MomenOfRent = DateTime.Now;

            await repo.SaveChangesAsync();
        }

        public async Task<VehicleServiceModel> VehicleDetails(int id)
        {
            return await repo.AllReadonly<Vehicle>()
                        .Where(v => v.Id == id && v.IsActive)
                        .Select(v => new VehicleServiceModel
                        {
                            Id = v.Id,
                            RegistrationNumber = v.RegistrationNumber,
                            ImageUrl = v.ImageUrl,
                            VehicleParkId = v.VehicleParkId,
                            CategoryId = v.CategoryId,
                            Description = v.Description,
                            EngineType = v.EngineType,
                            Model = v.Model,
                            PricePerHour = v.PricePerHour,
                            Rating = v.Rating,
                            RenterId = v.RenterId,
                            IsActive = v.IsActive,
                        })
                        .FirstAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>(c => c.Id == categoryId)
                .AnyAsync();

        }

        public async Task Create(CreateVehicleModel createVehicleModel)
        {
            var vehicle = new Vehicle
            {
                RegistrationNumber = createVehicleModel.RegistrationNumber,
                Model = createVehicleModel.ModelName,
                CategoryId = createVehicleModel.CategoryId,
                Description = createVehicleModel.Description,
                EngineType = createVehicleModel.EngineType,
                ImageUrl = createVehicleModel.ImageUrl,
                PricePerHour = createVehicleModel.PricePerHour,
                VehicleParkId = createVehicleModel.VehicleParkId,
                IsActive = createVehicleModel.IsActive,
                MomenOfRent = createVehicleModel.MomenOfRent,
                MomenOfLeave = createVehicleModel.MomenOfLeave
            };

            try
            {
                await repo.AddAsync(vehicle);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
        }

        public async Task<bool> VehiceExists(string registrationNumber)
        {
            return await repo.AllReadonly<Vehicle>()
                .Where(v => v.RegistrationNumber == registrationNumber && v.IsActive)
                .AnyAsync();
        }

        public async Task Delete(int vehicleId)
        {
            var vehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);
            vehicle.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task<int> GetVehicleCategoryId(int id)
        {
            return (await repo.GetByIdAsync<Vehicle>(id)).CategoryId;
        }

        public async Task Edit(int vehicleId, CreateVehicleModel createVehicleModel)
        {
            var vehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);
            vehicle.RegistrationNumber = createVehicleModel.RegistrationNumber;
            vehicle.Model = createVehicleModel.ModelName;
            vehicle.CategoryId = createVehicleModel.CategoryId;
            vehicle.Description = createVehicleModel.Description;
            vehicle.EngineType = createVehicleModel.EngineType;
            vehicle.ImageUrl = createVehicleModel.ImageUrl;
            vehicle.PricePerHour = createVehicleModel.PricePerHour;
            vehicle.VehicleParkId = createVehicleModel.VehicleParkId;
            vehicle.IsActive = createVehicleModel.IsActive;
            vehicle.MomenOfRent = createVehicleModel.MomenOfRent;
            vehicle.MomenOfLeave = createVehicleModel.MomenOfLeave;

            await repo.SaveChangesAsync();
        }

        public async Task AddFeedback(int vehicleId, VehicleFeedbackServiceModel vehicleModel)
        {
            var vehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);


            var feedback = new CustomerFeedback
            {
                VehicleId = vehicleModel.Id,
                UserId = vehicle.RenterId,
                Vote = vehicleModel.Vote,
                Feedback = vehicleModel.Feedback,
            };
            vehicle.CustomersFeedback.Add(feedback);
            vehicle.Rating = vehicleModel.Vote;

            await repo.AddAsync<CustomerFeedback>(feedback);

            await repo.SaveChangesAsync();
        }
    }
}
