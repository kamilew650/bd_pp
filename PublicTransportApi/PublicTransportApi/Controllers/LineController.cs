using Microsoft.AspNetCore.Mvc;
using PublicTransportApi.Models.ViewModels.Line;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Controllers
{
    public class LineController : BaseController
    {
        private ILineService _lineService;

        public LineController(ILineService lineService)
        {
            _lineService = lineService;
        }
        [HttpGet]
        public IActionResult GetLines()
        {
            return GetResult(() => _lineService.GetLines(), r => r.Lines);
        }

        [HttpGet, Route("{lineId}")]
        public IActionResult GetLine(int lineId)
        {
            return GetResult(() => _lineService.GetLine(lineId), r => r.Line);
        }

        [HttpPost, Route("create")]
        public IActionResult CreateLine([FromBody]LineVM lineViewModel)
        {
            return GetResult(() => _lineService.CreateLine(lineViewModel.MapToLineModel()), r => r);
        }

        [HttpPut, Route("update")]
        public IActionResult UpdateLine([FromBody]LineVM lineViewModel)
        {
            return GetResult(() => _lineService.UpdateLine(lineViewModel.MapToLineModel()), r => r);
        }

        [HttpDelete, Route("{lineId}/delete")]
        public IActionResult DeleteLine(int lineId)
        {
            return GetResult(() => _lineService.DeleteLine(lineId), r => r);
        }


    }
}
