using PublicTransportApi.Services.Contracts.Rides.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Models.ViewModels.Ride
{
    public class RideVM
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? VehicleId { get; set; }
        public int? DriverId { get; set; }
        public DateTime Date { get; set; }
        public int TicketsCount { get; set; }
        public double UsedFuel { get; set; }
        public TimeSpan Delay { get; set; }

        public RideModel MapToRideModel()
        {
            var result = new RideModel
            {
                Id = this.Id,
                CourseId = this.CourseId,
                VehicleId = this.VehicleId,
                DriverId = this.DriverId,
                Date = this.Date,
                TicketsCount = this.TicketsCount,
                UsedFuel = this.UsedFuel,
                Delay = this.Delay

            };
            return result;
        }
    }
}
