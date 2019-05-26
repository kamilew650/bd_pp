using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Base
{
    public class BaseContractResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public BaseContractResponse()
        {
            Success = true;
        }
    }
}
