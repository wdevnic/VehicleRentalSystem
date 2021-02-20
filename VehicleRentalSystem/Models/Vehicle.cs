using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class Vehicle
    {
        [Display(Name = "Id")]
        public int VehicleId { get; set; }
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int VehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }
    }
}