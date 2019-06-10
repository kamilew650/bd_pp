using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PublicTransportApi.Core;
using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Arrivals;
using PublicTransportApi.Services.Contracts.Arrivals.Models;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services
{
    public class ArrivalService : BaseService, IArrivalService
    {
        public ArrivalService(DefaultDbContext dbContext, ILogger<ArrivalService> logger, IHttpContextAccessor httpContextAccessor) : base(dbContext, logger, httpContextAccessor)
        {
        }

        public GetArrivalsResponse GetArrivals()
        {
            return ExecuteAction<GetArrivalsResponse>(r => { r.Arrivals = _dbContext.Arrivals.Select(f => new ArrivalModel(f)).ToList(); });
        }

        public GetArrivalResponse GetArrival(int ArrivalId)
        {
            return ExecuteAction<GetArrivalResponse>((r) =>
            {
                r.Arrival = new ArrivalModel(_dbContext.Arrivals.FirstOrDefault(u => u.Id == ArrivalId));
            });
        }

        public CreateArrivalResponse CreateArrival(ArrivalModel arrivalModel)
        {
            return ExecuteAction<CreateArrivalResponse>(r =>
            {
                var arrival = new Arrival()
                {
                    Id = arrivalModel.Id,
                    CourseId = arrivalModel.CourseId,
                    BusStopOnRouteId = arrivalModel.BusStopOnRouteId,
                    Time = arrivalModel.Time
                };
                _dbContext.Arrivals.Add(arrival);
                _dbContext.SaveChanges();
                r.Id = arrival.Id;
            });
        }


        public BaseContractResponse UpdateArrival(ArrivalModel arrivalModel)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var arrival = _dbContext.Arrivals.FirstOrDefault(u => u.Id == arrivalModel.Id);
                arrival.Id = arrivalModel.Id;
                arrival.CourseId = arrivalModel.CourseId;
                arrival.BusStopOnRouteId = arrivalModel.BusStopOnRouteId;
                arrival.Time = arrivalModel.Time;
                _dbContext.Arrivals.Update(arrival);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse DeleteArrival(int arrivalId)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var arrival = _dbContext.Arrivals.FirstOrDefault(v => v.Id == arrivalId);

                _dbContext.Arrivals.Remove(arrival);
                _dbContext.SaveChanges();
            });

        }


    }
}
