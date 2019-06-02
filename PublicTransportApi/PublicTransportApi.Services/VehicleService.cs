using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PublicTransportApi.Core;
using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Vehicles;
using PublicTransportApi.Services.Contracts.Vehicles.Models;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services
{
    public class VehicleService : BaseService, IVehicleService
    {
        public VehicleService(DefaultDbContext dbContext, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(dbContext, logger, httpContextAccessor)
        {
        }

        public GetVehiclesResponse GetVehicles()
        {
            return ExecuteAction<GetVehiclesResponse>(r => { r.Vehicles = _dbContext.Vehicles.Select(v => new VehicleModel(v)).ToList(); });
        }

        public GetVehicleResponse GetVehicle(int VehicleId)
        {
            return ExecuteAction<GetVehicleResponse>((r) =>
            {
                r.Vehicle = new VehicleModel(_dbContext.Vehicles.FirstOrDefault(u => u.Id == VehicleId));
            });
        }

        public CreateVehicleResponse CreateVehicle(VehicleModel vehicleModel)
        {
            return ExecuteAction<CreateVehicleResponse>(r =>
            {
                var Vehicle = new Vehicle()
                {
                    Id = vehicleModel.Id,
                    Brand = vehicleModel.Brand,
                    Model = vehicleModel.Model,
                    YearOfProduction = vehicleModel.YearOfProduction,
                    Mileage = vehicleModel.Mileage,
                    PurchaseDate = vehicleModel.PurchaseDate,
                    Available = vehicleModel.Available,
                    Seats = vehicleModel.Seats
                };
                _dbContext.Vehicles.Add(Vehicle);
                _dbContext.SaveChanges();
                r.Id = Vehicle.Id;
            });
        }


        public BaseContractResponse UpdateVehicle(VehicleModel vehicleModel)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var vehicle = _dbContext.Vehicles.FirstOrDefault(u => u.Id == vehicleModel.Id);
                vehicle.Brand = vehicleModel.Brand;
                vehicle.Model = vehicleModel.Model;
                vehicle.YearOfProduction = vehicleModel.YearOfProduction;
                vehicle.Mileage = vehicleModel.Mileage;
                vehicle.PurchaseDate = vehicleModel.PurchaseDate;
                vehicle.Available = vehicleModel.Available;
                vehicle.Seats = vehicleModel.Seats;

                _dbContext.Vehicles.Update(vehicle);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse DeleteVehicle(int vehicleId)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var vehicle = _dbContext.Vehicles.FirstOrDefault(v => v.Id == vehicleId);

                _dbContext.Vehicles.Remove(vehicle);
                _dbContext.SaveChanges();
            });

        }

    }
}
