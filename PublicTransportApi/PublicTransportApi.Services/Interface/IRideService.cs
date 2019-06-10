using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Rides;
using PublicTransportApi.Services.Contracts.Rides.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Interface
{
    public interface IRideService
    {
        GetRidesResponse GetRides();
        GetRideResponse GetRide(int RideId);
        CreateRideResponse CreateRide(RideModel rideModel);
        BaseContractResponse UpdateRide(RideModel rideModel);
        BaseContractResponse DeleteRide(int rideId);

    }
}
