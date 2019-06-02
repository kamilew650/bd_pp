using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.BusStops.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.BusStops
{
    public class GetBusStopsResponse : BaseContractResponse
    {
        public ICollection<BusStopModel> BusStops { get; set; }
    }
}
