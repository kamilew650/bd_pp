using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Rides.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Rides
{
    public class GetRidesResponse : BaseContractResponse
    {
        public ICollection<RideModel> Rides { get; set; }
    }
}
