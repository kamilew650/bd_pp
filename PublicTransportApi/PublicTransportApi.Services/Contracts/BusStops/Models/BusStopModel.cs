using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.BusStopsOnRoutes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services.Contracts.BusStops.Models
{
    public class BusStopModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<BusStopOnRouteModel> BusStopOnRoutes { get; set; }

        public BusStopModel()
        {

        }

        public BusStopModel(BusStop busStop)
        {
            Id = busStop.Id;
            Name = busStop.Name;
            Address = busStop.Address;
            BusStopOnRoutes = busStop.BusStopOnRoutes.Select(bs =>
            {
                return new BusStopOnRouteModel(bs);
            }).ToList();
        }

    }
}
