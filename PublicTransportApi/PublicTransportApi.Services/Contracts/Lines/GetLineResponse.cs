using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Lines.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Lines
{
    public class GetLineResponse : BaseContractResponse
    {
        public LineModel Line { get; set; }
    }
}
