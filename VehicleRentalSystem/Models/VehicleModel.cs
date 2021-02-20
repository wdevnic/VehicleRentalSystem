using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class VehicleModel
    {
        [Display(Name = "Id")]
        public int VehicleModelId { get; set; }
        [Display(Name = "Vehicle Model")]
        public string Name { get; set; }
        public bool Automatic { get; set; }
        [Display(Name = "Seating Capacity")]
        public int SeatingCapacity { get; set; }
        [Display(Name = "Bag Capacity")]
        public int BagCapacity { get; set; }      
        public int VehicleManufacturerId { get; set; }
        public int VehicleTypeId { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
        public VehicleType VehicleType { get; set; }
        public VehicleManufacturer VehicleManufacturer { get; set; }
    }
           
}