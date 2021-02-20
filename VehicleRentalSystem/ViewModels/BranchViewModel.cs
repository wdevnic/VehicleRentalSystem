using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.ViewModels
{
    public class BranchViewModel
    {
        public Branch Branch { get; set; }
        public Address Address { get; set; }
    }
}