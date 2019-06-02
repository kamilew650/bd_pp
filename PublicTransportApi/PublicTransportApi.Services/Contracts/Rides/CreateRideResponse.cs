using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Rides
{
    public class CreateRideResponse : BaseContractResponse
    {
        public int Id { get; set; }
    }
}
