using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PublicTransportApi.Core;
using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.TechnicalReviews;
using PublicTransportApi.Services.Contracts.TechnicalReviews.Models;
using PublicTransportApi.Services.Interface;

namespace PublicTransportApi.Services
{
    class TechnicalReviewService : BaseService, ITechnicalReviewService
    {
        public TechnicalReviewService(DefaultDbContext dbContext, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(dbContext, logger, httpContextAccessor)
        {
        }

        public GetTechnicalReviewsResponse GetTechnicalReviews()
        {
            return ExecuteAction<GetTechnicalReviewsResponse>(r => { r.TechnicalReviews = _dbContext.TechnicalReviews.Select(f => new TechnicalReviewModel(f)).ToList(); });
        }

        public GetTechnicalReviewResponse GetTechnicalReview(int TechnicalReviewId)
        {
            return ExecuteAction<GetTechnicalReviewResponse>((r) =>
            {
                r.TechnicalReview = new TechnicalReviewModel(_dbContext.TechnicalReviews.FirstOrDefault(u => u.Id == TechnicalReviewId));
            });
        }

        public CreateTechnicalReviewResponse CreateTechnicalReview(TechnicalReviewModel technicalReviewModel)
        {
            return ExecuteAction<CreateTechnicalReviewResponse>(r =>
            {
                var TechnicalReview = new TechnicalReview()
                {
                    VehicleId = technicalReviewModel.VehicleId,
                    Date = technicalReviewModel.Date,
                    DueDate = technicalReviewModel.DueDate,
                    Passed = technicalReviewModel.Passed
                };
                _dbContext.TechnicalReviews.Add(TechnicalReview);
                _dbContext.SaveChanges();
                r.Id = TechnicalReview.Id;
            });
        }


        public BaseContractResponse UpdateTechnicalReview(TechnicalReviewModel technicalReviewModel)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var technicalReview = _dbContext.TechnicalReviews.FirstOrDefault(u => u.Id == technicalReviewModel.Id);
                technicalReview.Id = technicalReview.Id;
                technicalReview.VehicleId = technicalReview.VehicleId;
                technicalReview.Date = technicalReview.Date;
                technicalReview.DueDate = technicalReview.DueDate;
                technicalReview.Passed = technicalReview.Passed;
                _dbContext.TechnicalReviews.Update(technicalReview);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse DeleteTechnicalReview(int technicalReviewId)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var technicalReview = _dbContext.TechnicalReviews.FirstOrDefault(v => v.Id == technicalReviewId);

                _dbContext.TechnicalReviews.Remove(technicalReview);
                _dbContext.SaveChanges();
            });

        }

    }
}
