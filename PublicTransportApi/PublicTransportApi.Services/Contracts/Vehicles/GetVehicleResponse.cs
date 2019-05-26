using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Vehicles
{
    public class GetVehicleResponse : BaseContractResponse
    {
        public VehicleModel Vehicle { get; set; }
    }
}
