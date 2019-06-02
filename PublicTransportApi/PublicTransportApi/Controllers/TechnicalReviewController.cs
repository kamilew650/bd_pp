using Microsoft.AspNetCore.Mvc;
using PublicTransportApi.Models.ViewModels.TechnicalReview;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class TechnicalReviewController : BaseController
    {
        private ITechnicalReviewService _technicalReviewService;

        public TechnicalReviewController(ITechnicalReviewService technicalReviewService)
        {
            _technicalReviewService = technicalReviewService;
        }

        public IActionResult GetTechnicalReviews()
        {
            return GetResult(() => _technicalReviewService.GetTechnicalReviews(), r => r.TechnicalReviews);
        }

        [HttpGet, Route("{technicalReviewId}")]
        public IActionResult GetTechnicalReview(int technicalReviewId)
        {
            return GetResult(() => _technicalReviewService.GetTechnicalReview(technicalReviewId), r => r.TechnicalReview);
        }

        [HttpPut]
        public IActionResult CreateTechnicalReview([FromBody]TechnicalReviewVM technicalReviewViewModel)
        {
            return GetResult(() => _technicalReviewService.CreateTechnicalReview(technicalReviewViewModel.MapToTechnicalReviewModel()), r => r);
        }

        [HttpPut]
        public IActionResult UpdateTechnicalReview([FromBody]TechnicalReviewVM technicalReviewViewModel)
        {
            return GetResult(() => _technicalReviewService.UpdateTechnicalReview(technicalReviewViewModel.MapToTechnicalReviewModel()), r => r);
        }

        [HttpGet, Route("{technicalReviewId}")]
        public IActionResult DeleteTechnicalReview(int technicalReviewId)
        {
            return GetResult(() => _technicalReviewService.DeleteTechnicalReview(technicalReviewId), r => r);
        }


    }
}
