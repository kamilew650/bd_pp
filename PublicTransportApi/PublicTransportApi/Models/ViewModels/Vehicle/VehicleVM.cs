using PublicTransportApi.Services.Contracts.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Models.ViewModels.Vehicle
{
    public class VehicleVM
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime YearOfProduction { get; set; }
        public double Mileage { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Available { get; set; }
        public int Seats { get; set; }


        public VehicleModel MapToVehicleModel()
        {
            var result = new VehicleModel
            {
                Id = this.Id,
                Brand = this.Brand,
                Model = this.Model,
                YearOfProduction = this.YearOfProduction,
                Mileage = this.Mileage,
                PurchaseDate = this.PurchaseDate,
                Available = this.Available,
                Seats = this.Seats

            };
            return result;

        }
    }
}
