using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Routes;
using PublicTransportApi.Services.Contracts.Routes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Interface
{
    public interface IRouteService
    {
        GetRoutesResponse GetRoutes();
        GetRouteResponse GetRoute(int RouteId);
        CreateRouteResponse CreateRoute(RouteModel routeModel);
        BaseContractResponse UpdateRoute(RouteModel routeModel);
        BaseContractResponse DeleteRoute(int routeId);

    }
}
