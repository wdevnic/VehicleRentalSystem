using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class VehicleManufacturer
    {
        [Display(Name = "Id")]
        public int VehicleManufacturerId { get; set; }
        [Display(Name = "Manufacturer Name")]
        public string Name { get; set; }

        public ICollection<VehicleModel> VehicleModels  { get; set; }
    }
}