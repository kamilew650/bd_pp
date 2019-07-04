using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PublicTransportApi.Core;
using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.BusStopsOnRoutes;
using PublicTransportApi.Services.Contracts.BusStopsOnRoutes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PublicTransportApi.Services.Interface;

namespace PublicTransportApi.Services
{
    public class BusStopOnRouteService : BaseService, IBusStopOnRouteService
    {
        public BusStopOnRouteService(DefaultDbContext dbContext, ILogger<BusStopOnRouteService> logger, IHttpContextAccessor httpContextAccessor) : base(dbContext, logger, httpContextAccessor)
        {
        }

        public GetBusStopsOnRouteResponse GetBusStopOnRoutes()
        {
            return ExecuteAction<GetBusStopsOnRouteResponse>(r => { r.BusStopsOnRoute = _dbContext.BusStopsOnRoute.Select(f => new BusStopOnRouteModel(f)).ToList(); });
        }

        public GetBusStopOnRouteResponse GetBusStopOnRoute(int BusStopOnRouteId)
        {
            return ExecuteAction<GetBusStopOnRouteResponse>((r) =>
            {
                r.BusStopOnRoute = new BusStopOnRouteModel(_dbContext.BusStopsOnRoute.FirstOrDefault(u => u.Id == BusStopOnRouteId));
            });
        }

        public CreateBusStopOnRouteResponse CreateBusStopOnRoute(BusStopOnRouteModel busStopOnRouteModel)
        {
            return ExecuteAction<CreateBusStopOnRouteResponse>(r =>
            {
                var busStopOnRoute = new BusStopOnRoute()
                {
                    Id = busStopOnRouteModel.Id,
                    RouteId = busStopOnRouteModel.RouteId,
                    BusStopId = busStopOnRouteModel.BusStopId,
                    PreviousBusStopOnRouteId = busStopOnRouteModel.PreviousBusStopOnRouteId
                };
                _dbContext.BusStopsOnRoute.Add(busStopOnRoute);
                _dbContext.SaveChanges();
                r.Id = busStopOnRoute.Id;
            });
        }


        public BaseContractResponse UpdateBusStopOnRoute(BusStopOnRouteModel busStopOnRouteModel)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var busStopOnRoute = _dbContext.BusStopsOnRoute.FirstOrDefault(u => u.Id == busStopOnRouteModel.Id);
                busStopOnRoute.Id = busStopOnRouteModel.Id;
                busStopOnRoute.RouteId = busStopOnRouteModel.RouteId;
                busStopOnRoute.BusStopId = busStopOnRouteModel.BusStopId;
                busStopOnRoute.PreviousBusStopOnRouteId = busStopOnRouteModel.PreviousBusStopOnRouteId;
                _dbContext.BusStopsOnRoute.Update(busStopOnRoute);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse DeleteBusStopOnRoute(int busStopOnRouteId)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var busStopOnRoute = _dbContext.BusStopsOnRoute.FirstOrDefault(v => v.Id == busStopOnRouteId);

                _dbContext.BusStopsOnRoute.Remove(busStopOnRoute);
                _dbContext.SaveChanges();
            });
        }

    }
}
