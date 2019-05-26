using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Users.Models;
using PublicTransportApi.Services.Contracts.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Failures.Models
{
    public class FailureModel
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int NotifyingUserId { get; set; }
        public string Description { get; set; }
        public bool Repaired { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool AcceptedForRepair { get; set; }
        public DateTime PlannedEndOfRepairDate { get; set; }
        public DateTime EndOfRepairDate { get; set; }

        public VehicleModel Vehicle { get; set; }
        public UserModel NotifyingUser { get; set; }

        public FailureModel(Failure failure)
        {
            Id = failure.Id;
            VehicleId = failure.VehicleId;
            NotifyingUserId = failure.NotifyingUserId;
            Description = failure.Description;
            Repaired = failure.Repaired;
            NotificationDate = failure.NotificationDate;
            AcceptedForRepair = failure.AcceptedForRepair;
            PlannedEndOfRepairDate = failure.PlannedEndOfRepairDate;
            EndOfRepairDate = failure.EndOfRepairDate;
            Vehicle = new VehicleModel(failure.Vehicle);
            NotifyingUser = new UserModel(failure.NotifyingUser);
        }

    }
}
