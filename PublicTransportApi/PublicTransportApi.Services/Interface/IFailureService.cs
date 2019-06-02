using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Failures;
using PublicTransportApi.Services.Contracts.Failures.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Interface
{
    public interface IFailureService
    {
        GetFailuresResponse GetFailures();
        GetFailureResponse GetFailure(int FailureId);
        CreateFailureResponse CreateFailure(FailureModel failureModel);
        BaseContractResponse UpdateFailure(FailureModel failureModel);
        BaseContractResponse DeleteFailure(int failureId);
    }
}
