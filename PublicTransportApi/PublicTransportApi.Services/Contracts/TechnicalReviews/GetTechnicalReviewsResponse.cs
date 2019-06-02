using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.TechnicalReviews.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.TechnicalReviews
{
    public class GetTechnicalReviewsResponse : BaseContractResponse
    {
        public ICollection<TechnicalReviewModel> TechnicalReviews { get; set; }
    }
}
