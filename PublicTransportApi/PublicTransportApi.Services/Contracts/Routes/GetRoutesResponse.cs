using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Routes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Routes
{
    public class GetRoutesResponse : BaseContractResponse
    {
        public ICollection<RouteModel> Routes { get; set; }
    }
}
