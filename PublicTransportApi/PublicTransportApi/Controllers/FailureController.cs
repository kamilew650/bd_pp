using Microsoft.AspNetCore.Mvc;
using PublicTransportApi.Models.ViewModels.Failure;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Controllers
{
    public class FailureController : BaseController
    {
        private IFailureService _failureService;

        public FailureController(IFailureService failureService)
        {
            _failureService = failureService;
        }

        public IActionResult GetFailures()
        {
            return GetResult(() => _failureService.GetFailures(), r => r.Failures);
        }

        [HttpGet, Route("{failureId}")]
        public IActionResult GetFailure(int failureId)
        {
            return GetResult(() => _failureService.GetFailure(failureId), r => r.Failure);
        }

        [HttpPut]
        public IActionResult CreateFailure([FromBody]FailureVM failureViewModel)
        {
            return GetResult(() => _failureService.CreateFailure(failureViewModel.MapToFailureModel()), r => r);
        }

        [HttpPut]
        public IActionResult UpdateFailure([FromBody]FailureVM failureViewModel)
        {
            return GetResult(() => _failureService.UpdateFailure(failureViewModel.MapToFailureModel()), r => r);
        }

        [HttpGet, Route("{failureId}")]
        public IActionResult DeleteFailure(int failureId)
        {
            return GetResult(() => _failureService.DeleteFailure(failureId), r => r);
        }

    }
}
