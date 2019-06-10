using PublicTransportApi.Services.Contracts.BusStopsOnRoutes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Models.ViewModels.BusStopOnRoute
{
    public class BusStopOnRouteVM
    {
        public int Id { get; set; }
        public int? RouteId { get; set; }
        public int? BusStopId { get; set; }
        public int? PreviousBusStopOnRouteId { get; set; }

        public BusStopOnRouteModel MapToBusStopOnRouteModel()
        {
            var result = new BusStopOnRouteModel
            {
                Id = this.Id,
                RouteId = this.RouteId,
                BusStopId = this.BusStopId,
                PreviousBusStopOnRouteId = this.PreviousBusStopOnRouteId
            };
            return result;

        }
    }
}
