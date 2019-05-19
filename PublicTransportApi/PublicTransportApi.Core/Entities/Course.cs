using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PublicTransportApi.Core.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public int CourseType { get; set; }

        public ICollection<Route> Routes { get; set; }
        public ICollection<Arrival> Arrivals { get; set; }
        public ICollection<Ride> Rides { get; set; }
    }
}
