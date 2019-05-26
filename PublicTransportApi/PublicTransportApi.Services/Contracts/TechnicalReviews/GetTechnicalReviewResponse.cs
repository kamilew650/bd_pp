using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.TechnicalReviews.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.TechnicalReviews
{
    public class GetTechnicalReviewResponse : BaseContractResponse
    {
        public TechnicalReviewModel TechnicalReview { get; set; }
    }
}
