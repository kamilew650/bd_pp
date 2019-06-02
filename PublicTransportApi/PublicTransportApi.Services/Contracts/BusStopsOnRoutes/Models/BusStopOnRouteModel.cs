using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Arrivals.Models;
using PublicTransportApi.Services.Contracts.BusStops.Models;
using PublicTransportApi.Services.Contracts.Routes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services.Contracts.BusStopsOnRoutes.Models
{
    public class BusStopOnRouteModel
    {
        public int Id { get; set; }
        public int? RouteId { get; set; }
        public int? BusStopId { get; set; }
        public int? PreviousBusStopOnRouteId { get; set; }

        public RouteModel Route { get; set; }
        public BusStopModel BusStop { get; set; }
        public BusStopOnRouteModel PreviousBusStopOnRoute { get; set; }
        public BusStopOnRouteModel NextBusStopOnRoute { get; set; }

        public ICollection<ArrivalModel> Arrivals { get; set; }


        public BusStopOnRouteModel(BusStopOnRoute busStopOnRoute)
        {
            if (busStopOnRoute == null)
            {
                Id = busStopOnRoute.Id;
                RouteId = busStopOnRoute.RouteId;
                BusStopId = busStopOnRoute.BusStopId;
                PreviousBusStopOnRouteId = busStopOnRoute.PreviousBusStopOnRouteId;
                Route = new RouteModel(busStopOnRoute.Route);
                BusStop = new BusStopModel(busStopOnRoute.BusStop);
                PreviousBusStopOnRoute = new BusStopOnRouteModel(busStopOnRoute.PreviousBusStopOnRoute);
                NextBusStopOnRoute = new BusStopOnRouteModel(busStopOnRoute.NextBusStopOnRoute);
                if (busStopOnRoute.Arrivals != null && busStopOnRoute.Arrivals.Any())
                {
                    Arrivals = busStopOnRoute.Arrivals.Select(a =>
                    {
                        return new ArrivalModel(a);
                    }).ToList();

                }

            }

        }
    }
}
