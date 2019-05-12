using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PublicTransportApi.Core.Entities
{
    public class BusStopOnRoute
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Route")]
        public int RouteId { get; set; }
        [ForeignKey("BusStop")]
        public int BusStopId { get; set; }
        [ForeignKey("BusStopOnRoute")]
        public int PreviousBusStopOnRouteId { get; set; }

        public Route Route { get; set; }
        public BusStop BusStop { get; set; }
        public BusStopOnRoute PreviousBusStopOnRoute { get; set; }

        public ICollection<Arrival> Arrivals { get; set; }
    }
}
