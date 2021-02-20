using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.DTOs
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public bool IsAvailable { get; set; }
        public string Branch { get; set; }
        public string VehicleModel{ get; set; }
    }
}