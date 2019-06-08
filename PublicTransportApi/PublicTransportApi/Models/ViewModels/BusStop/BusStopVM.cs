using PublicTransportApi.Services.Contracts.BusStops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Models.ViewModels.BusStop
{
    public class BusStopVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public BusStopModel MapToBusStopModel()
        {
            var result = new BusStopModel
            {
                Id = this.Id,
                Name = this.Name,
                Address = this.Address
            };
            return result;

        }

    }
}
