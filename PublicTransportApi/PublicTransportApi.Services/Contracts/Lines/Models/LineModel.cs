using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Routes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Lines.Models
{
    public class LineModel
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public ICollection<RouteModel> Routes { get; set; }

        public LineModel(Line line)
        {
            Id = line.Id;
            Number = line.Number;
            Routes = line.Routes.Select(r => { return new RouteModel(r); }).ToList();
        }

    }
}
