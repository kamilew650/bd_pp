using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Vehicles
{
    public class CreateVehicleResponse : BaseContractResponse
    {
        public int Id { get; set; }
    }
}
