using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Vehicles
{
    public class GetVehiclesResponse : BaseContractResponse
    {
        public ICollection<VehicleModel> Vehicles { get; set; }
    }
}
