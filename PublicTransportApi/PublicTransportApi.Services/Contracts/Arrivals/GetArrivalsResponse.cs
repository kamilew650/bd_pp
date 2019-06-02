using PublicTransportApi.Services.Contracts.Arrivals.Models;
using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Arrivals
{
    public class GetArrivalsResponse : BaseContractResponse
    {
        public ICollection<ArrivalModel> Arrivals { get; set; }
    }
}
