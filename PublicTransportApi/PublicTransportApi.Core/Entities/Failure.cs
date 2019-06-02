using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PublicTransportApi.Core.Entities
{
    public class Failure
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Vehicle")]
        public int? VehicleId { get; set; }
        [ForeignKey("User")]
        public int? NotifyingUserId { get; set; }
        public string Description { get; set; }
        public bool Repaired { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool AcceptedForRepair { get; set; }
        public DateTime PlannedEndOfRepairDate { get; set; }
        public DateTime EndOfRepairDate { get; set; }

        public Vehicle Vehicle { get; set; }
        public User NotifyingUser { get; set; }
    }
}
