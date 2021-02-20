using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.ViewModels
{
    public class VehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public ICollection<Branch> Branches { get; set; }
        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}