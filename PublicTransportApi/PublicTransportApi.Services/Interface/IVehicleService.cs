using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Vehicles;
using PublicTransportApi.Services.Contracts.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Interface
{
    public interface IVehicleService
    {                                                                      
        GetVehiclesResponse GetVehicles();
        GetVehicleResponse GetVehicle(int VehicleId);
        CreateVehicleResponse CreateVehicle(VehicleModel vehicleModel);
        BaseContractResponse UpdateVehicle(VehicleModel vehicleModel);
        BaseContractResponse DeleteVehicle(int vehicleId);
    }
}
