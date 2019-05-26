using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Lines
{
    public class CreateLineResponse : BaseContractResponse
    {
        public int Id { get; set; }
    }
}
