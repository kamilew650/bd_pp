using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.TechnicalReviews.Models
{
    public class TechnicalReviewModel
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public bool Passed { get; set; }

        public VehicleModel Vehicle { get; set; }

        public TechnicalReviewModel(TechnicalReview technicalReview)
        {
            Id = technicalReview.Id;
            VehicleId = technicalReview.VehicleId;
            Date = technicalReview.Date;
            DueDate = technicalReview.DueDate;
            Passed = technicalReview.Passed;
            Vehicle = new VehicleModel(technicalReview.Vehicle);
        }

    }
}
