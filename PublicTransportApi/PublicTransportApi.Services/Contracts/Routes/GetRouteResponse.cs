using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Routes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Routes
{
    public class GetRouteResponse : BaseContractResponse
    {
        public RouteModel Route { get; set; }
    }
}
