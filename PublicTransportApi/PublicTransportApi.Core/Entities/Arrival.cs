using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PublicTransportApi.Core.Entities
{
    public class Arrival
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ForeignKey("BusStopOnRoute")]
        public int BusStopOnRouteId { get; set; }
        public DateTime Time { get; set; }

        public Course Course { get; set; }
        public BusStopOnRoute BusStopOnRoute { get; set; }
    }
}
