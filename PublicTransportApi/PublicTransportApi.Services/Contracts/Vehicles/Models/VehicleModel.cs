using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Failures.Models;
using PublicTransportApi.Services.Contracts.Rides.Models;
using PublicTransportApi.Services.Contracts.TechnicalReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Vehicles.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime YearOfProduction { get; set; }
        public double Mileage { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Available { get; set; }
        public int Seats { get; set; }

        public ICollection<FailureModel> Failures { get; set; }
        public ICollection<TechnicalReviewModel> TechnicalReviews { get; set; }
        public ICollection<RideModel> Rides { get; set; }

        public VehicleModel()
        {
        }
        public VehicleModel(Vehicle vehicle)
        {
            Id = vehicle.Id;
            Brand = vehicle.Brand;
            Model = vehicle.Model;
            YearOfProduction = vehicle.YearOfProduction;
            Mileage = vehicle.Mileage;
            PurchaseDate = vehicle.PurchaseDate;
            Available = vehicle.Available;
            Seats = vehicle.Seats;
            Failures = vehicle.Failures.Select(f => { return new FailureModel(f); }).ToList();
            TechnicalReviews = vehicle.TechnicalReviews.Select(tr => { return new TechnicalReviewModel(tr); }).ToList();
            Rides = vehicle.Rides.Select(r => { return new RideModel(r); }).ToList();
        }
    }
}
