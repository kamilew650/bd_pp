using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Rides.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Rides
{
    public class GetRideResponse : BaseContractResponse
    {
        public RideModel Ride { get; set; }
    }
}
