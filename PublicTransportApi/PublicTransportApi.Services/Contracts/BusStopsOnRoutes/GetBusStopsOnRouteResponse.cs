using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.BusStopsOnRoutes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.BusStopsOnRoutes
{
    public class GetBusStopsOnRouteResponse : BaseContractResponse
    {
        public ICollection<BusStopOnRouteModel> BusStopsOnRoute { get; set; }
    }
}
