﻿namespace MunicipalityMobilitySystem.Core.Contracts.Vehicle
{
    public interface IVehicleFeedbackServiceModel
    {
        public int Id { get; }

        public int VehicleId { get; }

        public string UserId { get; } 

        public string? Feedback { get; }

        public int Vote { get; }
    }
}
