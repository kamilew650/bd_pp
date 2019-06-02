using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.BusStopsOnRoutes.Models;
using PublicTransportApi.Services.Contracts.Courses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Arrivals.Models
{
    public class ArrivalModel
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? BusStopOnRouteId { get; set; }
        public DateTime Time { get; set; }

        public CourseModel Course { get; set; }
        public BusStopOnRouteModel BusStopOnRoute { get; set; }

        public ArrivalModel(Arrival arrival)
        {
            Id = arrival.Id;
            CourseId = arrival.CourseId;
            BusStopOnRouteId = arrival.BusStopOnRouteId;
            Time = arrival.Time;
            Course = new CourseModel(arrival.Course);
            BusStopOnRoute = new BusStopOnRouteModel(arrival.BusStopOnRoute);
        }

    }
}
