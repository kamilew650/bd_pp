using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Courses.Models;
using PublicTransportApi.Services.Contracts.Users.Models;
using PublicTransportApi.Services.Contracts.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Rides.Models
{
    public class RideModel
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? VehicleId { get; set; }
        public int? DriverId { get; set; }
        public DateTime Date { get; set; }
        public int TicketsCount { get; set; }
        public double UsedFuel { get; set; }
        public TimeSpan Delay { get; set; }

        public CourseModel Course { get; set; }
        public VehicleModel Vehicle { get; set; }
        public UserModel Driver { get; set; }

        public RideModel(Ride ride)
        {
            Id = ride.Id;
            CourseId = ride.CourseId;
            VehicleId = ride.VehicleId;
            DriverId = ride.DriverId;
            Date = ride.Date;
            TicketsCount = ride.TicketsCount;
            UsedFuel = ride.UsedFuel;
            Delay = ride.Delay;
            Course = new CourseModel(ride.Course);
            Vehicle = new VehicleModel(ride.Vehicle);
            Driver = new UserModel(ride.Driver);
        }

    }
}
