using Microsoft.AspNetCore.Mvc;
using PublicTransportApi.Models.ViewModels.BusStop;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Controllers
{
    public class BusStopController : BaseController
    {
        private IBusStopService _busStopService;

        public BusStopController(IBusStopService busStopService)
        {
            _busStopService = busStopService;
        }

        public IActionResult GetBusStops()
        {
            return GetResult(() => _busStopService.GetBusStops(), r => r.BusStops);
        }

        [HttpGet, Route("{busStopId}")]
        public IActionResult GetBusStop(int busStopId)
        {
            return GetResult(() => _busStopService.GetBusStop(busStopId), r => r.BusStop);
        }

        [HttpPut, Route("create")]
        public IActionResult CreateBusStop([FromBody]BusStopVM busStopViewModel)
        {
            return GetResult(() => _busStopService.CreateBusStop(busStopViewModel.MapToBusStopModel()), r => r);
        }

        [HttpPut, Route("update")]
        public IActionResult UpdateBusStop([FromBody]BusStopVM busStopViewModel)
        {
            return GetResult(() => _busStopService.UpdateBusStop(busStopViewModel.MapToBusStopModel()), r => r);
        }

        [HttpGet, Route("{busStopId}/delete")]
        public IActionResult DeleteBusStop(int busStopId)
        {
            return GetResult(() => _busStopService.DeleteBusStop(busStopId), r => r);
        }

    }
}
