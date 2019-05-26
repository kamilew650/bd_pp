using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Failures
{
    public class CreateFailureResponse : BaseContractResponse
    {
        public int Id { get; set; }
    }
}
