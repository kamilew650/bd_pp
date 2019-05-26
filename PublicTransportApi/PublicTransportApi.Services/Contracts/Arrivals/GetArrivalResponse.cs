using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Arrivals.Models;
using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Arrivals
{
    public class GetArrivalResponse : BaseContractResponse
    {
        public ArrivalModel Arrival { get; set; }
    }
}
