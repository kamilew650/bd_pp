using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.BusStops
{
    public class CreateBusStopResponse : BaseContractResponse
    {
        public int Id { get; set; }
    }
}
