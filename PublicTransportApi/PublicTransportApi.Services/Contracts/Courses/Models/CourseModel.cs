using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Arrivals.Models;
using PublicTransportApi.Services.Contracts.Rides.Models;
using PublicTransportApi.Services.Contracts.Routes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Courses.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public int CourseType { get; set; }

        public ICollection<RouteModel> Routes { get; set; }
        public ICollection<ArrivalModel> Arrivals { get; set; }
        public ICollection<RideModel> Rides { get; set; }

        public CourseModel(Course course)
        {
            Id = course.Id;
            CourseType = course.CourseType;
            Routes = course.Routes.Select(r => { return new RouteModel(r); }).ToList();
            Arrivals = course.Arrivals.Select(a => { return new ArrivalModel(a); }).ToList();
            Rides = course.Rides.Select(r => { return new RideModel(r); }).ToList();
        }
    }
}
