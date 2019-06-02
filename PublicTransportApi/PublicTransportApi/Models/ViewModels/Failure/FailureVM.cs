using PublicTransportApi.Services.Contracts.Failures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Models.ViewModels.Failure
{
    public class FailureVM
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public int? NotifyingUserId { get; set; }
        public string Description { get; set; }
        public bool Repaired { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool AcceptedForRepair { get; set; }
        public DateTime PlannedEndOfRepairDate { get; set; }
        public DateTime EndOfRepairDate { get; set; }
        public FailureModel MapToFailureModel()
        {
            var result = new FailureModel
            {
                Id = this.Id,
                VehicleId = this.VehicleId,
                NotifyingUserId = this.NotifyingUserId,
                Description = this.Description,
                Repaired = this.Repaired,
                NotificationDate = this.NotificationDate,
                AcceptedForRepair = this.AcceptedForRepair,
                PlannedEndOfRepairDate = this.PlannedEndOfRepairDate,
                EndOfRepairDate = this.EndOfRepairDate

            };
            return result;
    }
    }
}
