using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Vehicle;
using MunicipalityMobilitySystem.Core.Exceptions;
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
                .Where(v=> v.RenterId == id)
                .Select(v => new VehicleServiceModel
                {
                    Id= v.Id,
                    ImageUrl= v.ImageUrl,
                    VehicleParkId= v.VehicleParkId,
                    CategoryId= v.CategoryId,
                    Description= v.Description,
                    EngineType= v.EngineType,
                    Model=v.Model,
                    PricePerHour= v.PricePerHour,
                    Rating= v.Rating,
                    RenterId= v.RenterId
                })
                .ToListAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Vehicle>(v=>v.Id == id)
                .AnyAsync();    
        }

        public async Task<bool> IsRented(int vehicleId)
        {
            return (await repo.GetByIdAsync<Vehicle>(vehicleId)).RenterId != null;
        }

        public async Task<bool> IsRentedByUserWithId(int vehicleId, string currentUserId)
        {
           return await repo.AllReadonly<Vehicle>()
                .Where(v=>v.Id == vehicleId)
                .AnyAsync(v=>v.RenterId == currentUserId);
        }

        public async Task Leave(int vehicleId)
        {
            var vehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);

            if (vehicle != null && vehicle.RenterId == null)
            {
                throw new ArgumentException("Vehicle is not rented");
            }

            guard.AgainstNull(vehicle, "Vehicle can not be found");

            vehicle.RenterId = null;

            await repo.SaveChangesAsync();
        }

        public async Task Rent(int vehicleId, string currentUserId)
        {
            var vehicleForRent = await repo.GetByIdAsync<Vehicle>(vehicleId);

            if (vehicleForRent!=null && vehicleForRent.RenterId != null)
            {
                throw new ArgumentException("Vehicle is already rented");
            }

            guard.AgainstNull(vehicleForRent, "Vehicle can not be found");
            vehicleForRent.RenterId = currentUserId;

            await repo.SaveChangesAsync();
        }

        public async Task<VehicleServiceModel> VehicleDetails(int id)
        {
            return await repo.AllReadonly<Vehicle>()
                        .Where(v=>v.Id == id)
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
                            RenterId = v.RenterId
                        })
                        .FirstAsync();
        }
    }
}
