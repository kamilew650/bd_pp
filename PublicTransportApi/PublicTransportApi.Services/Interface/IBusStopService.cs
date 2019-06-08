using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.BusStops;
using PublicTransportApi.Services.Contracts.BusStops.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Interface
{
    public interface IBusStopService
    {
        GetBusStopsResponse GetBusStops();
        GetBusStopResponse GetBusStop(int BusStopId);
        CreateBusStopResponse CreateBusStop(BusStopModel busStopModel);
        BaseContractResponse UpdateBusStop(BusStopModel busStopModel);
        BaseContractResponse DeleteBusStop(int busStopId);

    }
}
