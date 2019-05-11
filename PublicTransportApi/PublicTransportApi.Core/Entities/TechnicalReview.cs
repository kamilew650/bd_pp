using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PublicTransportApi.Core.Entities
{
    public class TechnicalReview
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public bool Passed { get; set; }
    }
}
