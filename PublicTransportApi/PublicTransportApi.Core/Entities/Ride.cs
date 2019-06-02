using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PublicTransportApi.Core.Entities
{
    public class Ride
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        [ForeignKey("Vehicle")]
        public int? VehicleId { get; set; }
        [ForeignKey("User")]
        public int? DriverId { get; set; }
        public DateTime Date { get; set; }
        public int TicketsCount { get; set; }
        public double UsedFuel { get; set; }
        public TimeSpan Delay { get; set; }

        public Course Course { get; set; }
        public Vehicle Vehicle { get; set; }
        public User Driver { get; set; }
    }
}
