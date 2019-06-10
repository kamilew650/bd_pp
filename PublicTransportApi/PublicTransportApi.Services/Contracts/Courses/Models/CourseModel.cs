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

        public CourseModel()
        {

        }

        public CourseModel(Course course)
        {
            if (course== null)
            {
                return;
            }
            Id = course.Id;
            CourseType = course.CourseType;
            if (course.Routes != null && course.Routes.Any())
            {
                Routes = course.Routes.Select(r => { return new RouteModel(r); }).ToList();
            }
            if (course.Arrivals != null && course.Arrivals.Any())
            {
                Arrivals = course.Arrivals.Select(a => { return new ArrivalModel(a); }).ToList();
            }
            if (course.Rides != null && course.Rides.Any())
            {
                Rides = course.Rides.Select(r => { return new RideModel(r); }).ToList();
            }
        }
    }
}
