using Microsoft.AspNetCore.Mvc;
using PublicTransportApi.Models.ViewModels.BusStopOnRoute;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Controllers
{
    public class BusStopOnRouteController : BaseController
    {
        private IBusStopOnRouteService _busStopOnRouteService;

        public BusStopOnRouteController(IBusStopOnRouteService busStopOnRouteService)
        {
            _busStopOnRouteService = busStopOnRouteService;
        }
        [HttpGet]
        public IActionResult GetBusStopOnRoutes()
        {
            return GetResult(() => _busStopOnRouteService.GetBusStopOnRoutes(), r => r.BusStopsOnRoute);
        }

        [HttpGet, Route("{busStopOnRouteId}")]
        public IActionResult GetBusStopOnRoute(int busStopOnRouteId)
        {
            return GetResult(() => _busStopOnRouteService.GetBusStopOnRoute(busStopOnRouteId), r => r.BusStopOnRoute);
        }

        [HttpPost, Route("create")]
        public IActionResult CreateBusStopOnRoute([FromBody]BusStopOnRouteVM busStopOnRouteViewModel)
        {
            return GetResult(() => _busStopOnRouteService.CreateBusStopOnRoute(busStopOnRouteViewModel.MapToBusStopOnRouteModel()), r => r);
        }

        [HttpPut, Route("update")]
        public IActionResult UpdateBusStopOnRoute([FromBody]BusStopOnRouteVM busStopOnRouteViewModel)
        {
            return GetResult(() => _busStopOnRouteService.UpdateBusStopOnRoute(busStopOnRouteViewModel.MapToBusStopOnRouteModel()), r => r);
        }

        [HttpDelete, Route("{busStopOnRouteId}/delete")]
        public IActionResult DeleteBusStopOnRoute(int busStopOnRouteId)
        {
            return GetResult(() => _busStopOnRouteService.DeleteBusStopOnRoute(busStopOnRouteId), r => r);
        }


    }
}
