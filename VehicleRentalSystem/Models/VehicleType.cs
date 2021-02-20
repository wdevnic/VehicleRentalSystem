using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class VehicleType
    {
        [Display(Name = "Id")]
        public int VehicleTypeId { get; set; }
        [Display(Name = "Vehicle Type")]
        public string Name { get; set; }
        public decimal Rate { get; set; }
    }
}