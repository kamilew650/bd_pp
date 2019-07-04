using Microsoft.AspNetCore.Mvc;
using PublicTransportApi.Models.ViewModels.Arrival;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Controllers
{
    public class ArrivalController : BaseController
    {
        private IArrivalService _arrivalService;

        public ArrivalController(IArrivalService arrivalService)
        {
            _arrivalService = arrivalService;
        }

        public IActionResult GetArrivals()
        {
            return GetResult(() => _arrivalService.GetArrivals(), r => r.Arrivals);
        }

        [HttpGet, Route("{arrivalId}")]
        public IActionResult GetArrival(int arrivalId)
        {
            return GetResult(() => _arrivalService.GetArrival(arrivalId), r => r.Arrival);
        }

        [HttpPost, Route("create")]
        public IActionResult CreateArrival([FromBody]ArrivalVM arrivalViewModel)
        {
            return GetResult(() => _arrivalService.CreateArrival(arrivalViewModel.MapToArrivalModel()), r => r);
        }

        [HttpPut, Route("update")]
        public IActionResult UpdateArrival([FromBody]ArrivalVM arrivalViewModel)
        {
            return GetResult(() => _arrivalService.UpdateArrival(arrivalViewModel.MapToArrivalModel()), r => r);
        }

        [HttpDelete, Route("{arrivalId}/delete")]
        public IActionResult DeleteArrival(int arrivalId)
        {
            return GetResult(() => _arrivalService.DeleteArrival(arrivalId), r => r);
        }


    }
}
