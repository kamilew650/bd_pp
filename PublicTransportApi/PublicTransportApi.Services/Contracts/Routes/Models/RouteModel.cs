using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.BusStopsOnRoutes.Models;
using PublicTransportApi.Services.Contracts.Courses.Models;
using PublicTransportApi.Services.Contracts.Lines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Routes.Models
{
    public class RouteModel
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? LineId { get; set; }
        public string Name { get; set; }

        public CourseModel Course { get; set; }
        public LineModel Line { get; set; }

        public ICollection<BusStopOnRouteModel> BusStopsOnRoute { get; set; }



        public RouteModel(Route route)
        {
            if (route == null)
            {
                return;
            }
            Id = route.Id;
            CourseId = route.CourseId;
            LineId = route.LineId;
            Name = route.Name;
            Course = new CourseModel(route.Course);
            Line = new LineModel(route.Line);
            if (route.BusStopsOnRoute != null && route.BusStopsOnRoute.Any())
            {
                BusStopsOnRoute = route.BusStopsOnRoute.Select(bs => { return new BusStopOnRouteModel(bs); }).ToList();
            }
        }
    }
}
