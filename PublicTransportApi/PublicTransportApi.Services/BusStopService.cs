using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PublicTransportApi.Core;
using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.BusStops;
using PublicTransportApi.Services.Contracts.BusStops.Models;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services
{
    public class BusStopService : BaseService, IBusStopService
    {
        public BusStopService(DefaultDbContext dbContext, ILogger<BusStopService> logger, IHttpContextAccessor httpContextAccessor) : base(dbContext, logger, httpContextAccessor)
        {
        }

        public GetBusStopsResponse GetBusStops()
        {
            return ExecuteAction<GetBusStopsResponse>(r => { r.BusStops = _dbContext.BusStops.Select(v => new BusStopModel(v)).ToList(); });
        }

        public GetBusStopResponse GetBusStop(int BusStopId)
        {
            return ExecuteAction<GetBusStopResponse>((r) =>
            {
                r.BusStop = new BusStopModel(_dbContext.BusStops.FirstOrDefault(u => u.Id == BusStopId));
            });
        }

        public CreateBusStopResponse CreateBusStop(BusStopModel busStopModel)
        {
            return ExecuteAction<CreateBusStopResponse>(r =>
            {
                var busStop = new BusStop()
                {
                    Id = busStopModel.Id,
                    Name = busStopModel.Name,
                    Address = busStopModel.Address
                };
                _dbContext.BusStops.Add(busStop);
                _dbContext.SaveChanges();
                r.Id = busStop.Id;
            });
        }


        public BaseContractResponse UpdateBusStop(BusStopModel busStopModel)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var busStop = _dbContext.BusStops.FirstOrDefault(u => u.Id == busStopModel.Id);
                busStop.Id = busStopModel.Id;
                busStop.Name = busStopModel.Name;
                busStop.Address = busStopModel.Address;

                _dbContext.BusStops.Update(busStop);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse DeleteBusStop(int busStopId)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var busStop = _dbContext.BusStops.FirstOrDefault(v => v.Id == busStopId);

                _dbContext.BusStops.Remove(busStop);
                _dbContext.SaveChanges();
            });

        }


    }
}
