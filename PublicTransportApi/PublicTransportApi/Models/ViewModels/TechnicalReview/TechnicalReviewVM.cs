using PublicTransportApi.Services.Contracts.TechnicalReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Models.ViewModels.TechnicalReview
{
    public class TechnicalReviewVM
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public bool Passed { get; set; }

        public TechnicalReviewModel MapToTechnicalReviewModel()
        {
            var result = new TechnicalReviewModel
            {
                Id = this.Id,
                VehicleId = this.VehicleId,
                Date = this.Date,
                DueDate = this.DueDate,
                Passed = this.Passed,
            };
            return result;
        }

    }
}
