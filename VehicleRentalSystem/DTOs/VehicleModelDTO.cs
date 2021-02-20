using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.DTOs
{
    public class VehicleModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeatingCapacity { get; set; }
        public int BaggageCapacity { get; set; }
        public string VehicleManufacturer { get; set; }
        public bool Automatic { get; set; }
        public string VehicleType { get; set; }
    }
}