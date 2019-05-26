using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Routes
{
    public class CreateRouteResponse : BaseContractResponse
    {
        public int Id { get; set; }
    }
}
