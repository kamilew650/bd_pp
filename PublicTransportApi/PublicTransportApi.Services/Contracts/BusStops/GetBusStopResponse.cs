using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.BusStops.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.BusStops
{
    public class GetBusStopResponse : BaseContractResponse
    {
        public BusStopModel BusStop { get; set; }
    }
}
