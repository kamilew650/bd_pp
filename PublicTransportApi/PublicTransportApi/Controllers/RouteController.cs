using Microsoft.AspNetCore.Mvc;
using PublicTransportApi.Models.ViewModels.Route;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Controllers
{
    public class RouteController : BaseController
    {
        private IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        public IActionResult GetRoutes()
        {
            return GetResult(() => _routeService.GetRoutes(), r => r.Routes);
        }

        [HttpGet, Route("{routeId}")]
        public IActionResult GetRoute(int routeId)
        {
            return GetResult(() => _routeService.GetRoute(routeId), r => r.Route);
        }

        [HttpPost, Route("create")]
        public IActionResult CreateRoute([FromBody]RouteVM routeViewModel)
        {
            return GetResult(() => _routeService.CreateRoute(routeViewModel.MapToRouteModel()), r => r);
        }

        [HttpPut, Route("update")]
        public IActionResult UpdateRoute([FromBody]RouteVM routeViewModel)
        {
            return GetResult(() => _routeService.UpdateRoute(routeViewModel.MapToRouteModel()), r => r);
        }

        [HttpDelete, Route("{routeId}/delete")]
        public IActionResult DeleteRoute(int routeId)
        {
            return GetResult(() => _routeService.DeleteRoute(routeId), r => r);
        }

    }
}
