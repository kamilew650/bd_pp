using Microsoft.AspNetCore.Mvc;
using PublicTransportApi.Models.ViewModels.Ride;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Controllers
{
    public class RideController : BaseController
    {
        private IRideService _rideService;

        public RideController(IRideService rideService)
        {
            _rideService = rideService;
        }
        [HttpGet]
        public IActionResult GetRides()
        {
            return GetResult(() => _rideService.GetRides(), r => r.Rides);
        }

        [HttpGet, Route("{rideId}")]
        public IActionResult GetRide(int rideId)
        {
            return GetResult(() => _rideService.GetRide(rideId), r => r.Ride);
        }

        [HttpPut, Route("create")]
        public IActionResult CreateRide([FromBody]RideVM rideViewModel)
        {
            return GetResult(() => _rideService.CreateRide(rideViewModel.MapToRideModel()), r => r);
        }

        [HttpPut, Route("update")]
        public IActionResult UpdateRide([FromBody]RideVM rideViewModel)
        {
            return GetResult(() => _rideService.UpdateRide(rideViewModel.MapToRideModel()), r => r);
        }

        [HttpGet, Route("{rideId}/delete")]
        public IActionResult DeleteRide(int rideId)
        {
            return GetResult(() => _rideService.DeleteRide(rideId), r => r);
        }


    }
}
