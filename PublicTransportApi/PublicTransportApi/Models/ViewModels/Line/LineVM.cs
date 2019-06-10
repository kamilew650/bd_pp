using PublicTransportApi.Services.Contracts.Lines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Models.ViewModels.Line
{
    public class LineVM
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public LineModel MapToLineModel()
        {
            var result = new LineModel
            {
                Id = this.Id,
                Number = this.Number
            };
            return result;
        }
    }
}
