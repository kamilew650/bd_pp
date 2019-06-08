using PublicTransportApi.Services.Contracts.Routes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Models.ViewModels.Route
{
    public class RouteVM
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? LineId { get; set; }
        public string Name { get; set; }

        public RouteModel MapToRouteModel()
        {
            var result = new RouteModel
            {
                Id = this.Id,
                CourseId = this.CourseId,
                LineId = this.LineId,
                Name = this.Name

            };
            return result;
        }
    }
}
