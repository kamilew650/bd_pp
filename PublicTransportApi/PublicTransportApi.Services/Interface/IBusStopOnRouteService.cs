using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.BusStopsOnRoutes;
using PublicTransportApi.Services.Contracts.BusStopsOnRoutes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Interface
{
    public interface IBusStopOnRouteService
    {
        GetBusStopsOnRouteResponse GetBusStopOnRoutes();
        GetBusStopOnRouteResponse GetBusStopOnRoute(int BusStopOnRouteId);
        CreateBusStopOnRouteResponse CreateBusStopOnRoute(BusStopOnRouteModel busStopOnRouteModel);
        BaseContractResponse UpdateBusStopOnRoute(BusStopOnRouteModel busStopOnRouteModel);
        BaseContractResponse DeleteBusStopOnRoute(int busStopOnRouteId);

    }
}
