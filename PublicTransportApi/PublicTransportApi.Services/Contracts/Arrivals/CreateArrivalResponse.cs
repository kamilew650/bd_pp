using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Arrivals
{
    public class CreateArrivalResponse : BaseContractResponse
    {
        public int Id { get; set; }
    }
}
