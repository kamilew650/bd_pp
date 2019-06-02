using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Lines.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Lines
{
    public class GetLinesResponse : BaseContractResponse
    {
        public ICollection<LineModel> Lines { get; set; }
    }
}
