using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.DTOs
{
    public class RentalDTO
    {
       
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string RentalDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public bool Returned { get; set; }

    }
}