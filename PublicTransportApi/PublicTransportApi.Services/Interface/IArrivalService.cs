using PublicTransportApi.Services.Contracts.Arrivals;
using PublicTransportApi.Services.Contracts.Arrivals.Models;
using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Interface
{
    public interface IArrivalService
    {
        GetArrivalsResponse GetArrivals();
        GetArrivalResponse GetArrival(int ArrivalId);
        CreateArrivalResponse CreateArrival(ArrivalModel arrivalModel);
        BaseContractResponse UpdateArrival(ArrivalModel arrivalModel);
        BaseContractResponse DeleteArrival(int arrivalId);

    }
}
