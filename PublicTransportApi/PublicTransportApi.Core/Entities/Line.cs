using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PublicTransportApi.Core.Entities
{
    public class Line
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
    }
}
