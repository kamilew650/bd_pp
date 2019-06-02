using Microsoft.AspNetCore.Mvc;
using PublicTransportApi.Models.ViewModels.Vehicle;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Controllers
{
    public class VehicleController : BaseController
    {
        private IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public IActionResult GetVehicles()
        {
            return GetResult(() => _vehicleService.GetVehicles(), r => r.Vehicles);
        }

        [HttpGet, Route("{vehicleId}")]
        public IActionResult GetVehicle(int vehicleId)
        {
            return GetResult(() => _vehicleService.GetVehicle(vehicleId), r => r.Vehicle);
        }

        [HttpPut]
        public IActionResult CreateVehicle([FromBody]VehicleVM vehicleViewModel)
        {
            return GetResult(() => _vehicleService.CreateVehicle(vehicleViewModel.MapToVehicleModel()), r => r);
        }

        [HttpPut]
        public IActionResult UpdateVehicle([FromBody]VehicleVM vehicleViewModel)
        {
            return GetResult(() => _vehicleService.UpdateVehicle(vehicleViewModel.MapToVehicleModel()), r => r);
        }

        [HttpGet, Route("{vehicleId}")]
        public IActionResult DeleteVehicle(int vehicleId)
        {
            return GetResult(() => _vehicleService.DeleteVehicle(vehicleId), r => r);
        }
    }
}
