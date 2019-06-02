﻿using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Failures.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Failures
{
    public class GetFailureResponse : BaseContractResponse
    {
        public FailureModel Failure { get; set; }
    }
}
