using PublicTransportApi.Services.Contracts.Arrivals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Models.ViewModels.Arrival
{
    public class ArrivalVM
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? BusStopOnRouteId { get; set; }
        public DateTime Time { get; set; }

        public ArrivalModel MapToArrivalModel()
        {
            var result = new ArrivalModel
            {
                Id = this.Id,
                CourseId = this.CourseId,
                BusStopOnRouteId = this.BusStopOnRouteId,
                Time = this.Time
            };
            return result;
        }
    }
}
