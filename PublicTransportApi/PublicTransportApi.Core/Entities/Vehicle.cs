using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PublicTransportApi.Core.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime YearOfProduction { get; set; }
        public double Mileage { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Available { get; set; }
        public int Seats { get; set; }

        public ICollection<Failure> Failures { get; set; }
        public ICollection<TechnicalReview> TechnicalReviews { get; set; }
        public ICollection<Ride> Rides { get; set; }
    }
}
