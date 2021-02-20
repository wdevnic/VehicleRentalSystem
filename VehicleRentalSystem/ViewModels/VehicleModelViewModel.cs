using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.ViewModels
{
    public class VehicleModelViewModel
    {
        public VehicleModel VehicleModel { get; set; }
        public ICollection<VehicleManufacturer> VehicleManufacturers { get; set; }
        public ICollection<VehicleType> VehicleTypes { get; set; }

    }
}