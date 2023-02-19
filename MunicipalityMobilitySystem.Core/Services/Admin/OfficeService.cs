using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunicipalityMobilitySystem.Core.Contracts.Admin;
using MunicipalityMobilitySystem.Core.Exceptions;
using MunicipalityMobilitySystem.Core.Models.Admin;
using MunicipalityMobilitySystem.Core.Models.Vehicle;
using MunicipalityMobilitySystem.Infrasructure.Data.Entities;
using MunicipalityMobilitySystem.Infrastructure.Data.Common;

namespace MunicipalityMobilitySystem.Core.Services.Admin
{
    public class OfficeService : IOfficeService
    {
        private readonly ILogger logger;
        private readonly IRepository repo;
        private readonly IGuard guard;

        public OfficeService(ILogger<OfficeService> _logger,
            IGuard _guard,
            IRepository _repo)
        {
            logger= _logger;
            guard= _guard;
            repo= _repo;
        }

        public async Task EditLeftVehicleById(VehicleDetailsViewModel model)
        {
            var vehicle = await repo.GetByIdAsync<Vehicle>(model.Id);

            vehicle.FailureDescription= model.FailureDescription;

            await repo.SaveChangesAsync();
        }

        public async Task<VehicleDetailsViewModel> GetLeftVehicleById(int vehicleId)
        {
            var vehicle =  await repo.All<Vehicle>()
                .Where(v=>v.MomenOfLeave != null && v.IsActive)
                .Select( v => new VehicleDetailsViewModel 
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber,
                    Model = v.Model,
                    VehicleParkId = v.VehicleParkId,
                    ForCleaning = v.ForCleaning,
                    ForRepearing = v.ForRepearing,
                    RentedPeriod = v.RentedPeriod,
                    RenterId = v.RenterId,
                    PricePerHour = v.PricePerHour,
                    MomenOfLeave = v.MomenOfLeave,
                    MomenOfRent = v.MomenOfRent,
                    FailureDescription= v.FailureDescription,
                }).FirstOrDefaultAsync();


            guard.AgainstNull(vehicle, "Vehicle can not be found");

            return vehicle;

        }

        public async Task<IEnumerable<VehicleDetailsViewModel>> GetLeftVehicles()
        {
            return await repo.All<Vehicle>()
                .Where(v=>v.MomenOfLeave != null 
                && v. ForCleaning == false
                && v.ForRepearing == false
                && v.IsActive)
                .Select(v=> new VehicleDetailsViewModel
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber,
                    Model = v.Model,
                    VehicleParkId = v.VehicleParkId,
                    ForCleaning = v.ForCleaning,
                    ForRepearing = v.ForRepearing,
                    RentedPeriod= v.RentedPeriod,
                    RenterId= v.RenterId,
                    PricePerHour= v.PricePerHour,
                    MomenOfLeave = v.MomenOfLeave,
                    MomenOfRent = v.MomenOfRent,
                    FailureDescription= v.FailureDescription
                })
                .ToListAsync();
        }

        public async Task<decimal> GetTheBill(int vehicleId)
        {
            var rentedVehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);

            TimeSpan? rentedPeriod = rentedVehicle.MomenOfLeave - rentedVehicle.MomenOfRent;

            decimal theBill = (decimal)rentedPeriod.Value.TotalHours * rentedVehicle.PricePerHour;

            return theBill;
        }

        public async Task SetVehicleForCleaning(int vehicleId)
        {

            var vehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);

            TimeSpan? rentedPeriod = vehicle.MomenOfLeave - vehicle.MomenOfRent;

            vehicle.ForCleaning = true;

            vehicle.RentedPeriod= rentedPeriod;

            await repo.SaveChangesAsync();
        }

        public async Task SetVehicleForRepairing(int vehicleId)
        {
            var vehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);

            TimeSpan? rentedPeriod = vehicle.MomenOfLeave - vehicle.MomenOfRent;

            vehicle.ForRepearing = true;

            vehicle.RentedPeriod = rentedPeriod;

            vehicle.RepairsCount++;

            await repo.SaveChangesAsync();
        }
    }
}
