using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PublicTransportApi.Core;
using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Rides;
using PublicTransportApi.Services.Contracts.Rides.Models;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services
{
    public class RideService : BaseService, IRideService
    {
        public RideService(DefaultDbContext dbContext, ILogger<RideService> logger, IHttpContextAccessor httpContextAccessor) : base(dbContext, logger, httpContextAccessor)
        {
        }

        public GetRidesResponse GetRides()
        {
            return ExecuteAction<GetRidesResponse>(r => { r.Rides = _dbContext.Rides.Select(f => new RideModel(f)).ToList(); });
        }

        public GetRideResponse GetRide(int RideId)
        {
            return ExecuteAction<GetRideResponse>((r) =>
            {
                r.Ride = new RideModel(_dbContext.Rides.FirstOrDefault(u => u.Id == RideId));
            });
        }

        public CreateRideResponse CreateRide(RideModel rideModel)
        {
            return ExecuteAction<CreateRideResponse>(r =>
            {
                var ride = new Ride()
                {
                    Id = rideModel.Id,
                    CourseId = rideModel.CourseId,
                    VehicleId = rideModel.VehicleId,
                    DriverId = rideModel.DriverId,
                    Date = rideModel.Date,
                    TicketsCount = rideModel.TicketsCount,
                    UsedFuel = rideModel.UsedFuel,
                    Delay = rideModel.Delay
                };
                _dbContext.Rides.Add(ride);
                _dbContext.SaveChanges();
                r.Id = ride.Id;
            });
        }


        public BaseContractResponse UpdateRide(RideModel rideModel)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var ride = _dbContext.Rides.FirstOrDefault(u => u.Id == rideModel.Id);
                ride.Id = rideModel.Id;
                ride.CourseId = rideModel.CourseId;
                ride.VehicleId = rideModel.VehicleId;
                ride.DriverId = rideModel.DriverId;
                ride.Date = rideModel.Date;
                ride.TicketsCount = rideModel.TicketsCount;
                ride.UsedFuel = rideModel.UsedFuel;
                ride.Delay = rideModel.Delay;
                _dbContext.Rides.Update(ride);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse DeleteRide(int rideId)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var ride = _dbContext.Rides.FirstOrDefault(v => v.Id == rideId);

                _dbContext.Rides.Remove(ride);
                _dbContext.SaveChanges();
            });

        }


    }
}
