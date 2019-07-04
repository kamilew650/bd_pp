using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PublicTransportApi.Core;
using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Routes;
using PublicTransportApi.Services.Contracts.Routes.Models;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services
{
    public class RouteService : BaseService, IRouteService
    {
        public RouteService(DefaultDbContext dbContext, ILogger<RouteService> logger, IHttpContextAccessor httpContextAccessor) : base(dbContext, logger, httpContextAccessor)
        {
        }

        public GetRoutesResponse GetRoutes()
        {
            return ExecuteAction<GetRoutesResponse>(r => { r.Routes = _dbContext.Routes.Select(f => new RouteModel(f)).ToList(); });
        }

        public GetRouteResponse GetRoute(int RouteId)
        {
            return ExecuteAction<GetRouteResponse>((r) =>
            {
                r.Route = new RouteModel(_dbContext.Routes.FirstOrDefault(u => u.Id == RouteId));
            });
        }

        public CreateRouteResponse CreateRoute(RouteModel routeModel)
        {
            return ExecuteAction<CreateRouteResponse>(r =>
            {
                var route = new Route()
                {
                    Id = routeModel.Id,
                    CourseId = routeModel.CourseId,
                    LineId = routeModel.LineId,
                    Name = routeModel.Name
                };
                _dbContext.Routes.Add(route);
                _dbContext.SaveChanges();
                r.Id = route.Id;
            });
        }


        public BaseContractResponse UpdateRoute(RouteModel routeModel)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var route = _dbContext.Routes.FirstOrDefault(u => u.Id == routeModel.Id);
                route.Id = routeModel.Id;
                route.CourseId = routeModel.CourseId;
                route.LineId = routeModel.LineId;
                route.Name = routeModel.Name;
                _dbContext.Routes.Update(route);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse DeleteRoute(int routeId)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var route = _dbContext.Routes.FirstOrDefault(v => v.Id == routeId);

                _dbContext.Routes.Remove(route);
                _dbContext.SaveChanges();
            });

        }


    }
}
