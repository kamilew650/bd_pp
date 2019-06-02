using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PublicTransportApi.Core.Entities
{
    public class Route
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        [ForeignKey("Line")]
        public int? LineId { get; set; }
        public string Name { get; set; }

        public Course Course { get; set; }
        public Line Line { get; set; }

        public ICollection<BusStopOnRoute> BusStopsOnRoute { get; set; }
    }
}
