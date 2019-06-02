using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.TechnicalReviews;
using PublicTransportApi.Services.Contracts.TechnicalReviews.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Interface
{
    public interface ITechnicalReviewService
    {
        GetTechnicalReviewsResponse GetTechnicalReviews();
        GetTechnicalReviewResponse GetTechnicalReview(int TechnicalReviewId);
        CreateTechnicalReviewResponse CreateTechnicalReview(TechnicalReviewModel technicalReviewModel);
        BaseContractResponse UpdateTechnicalReview(TechnicalReviewModel technicalReviewModel);
        BaseContractResponse DeleteTechnicalReview(int technicalReviewId);

    }
}
