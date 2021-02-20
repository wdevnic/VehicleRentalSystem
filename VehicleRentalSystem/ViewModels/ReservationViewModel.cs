using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.ViewModels
{
    public class ReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public ICollection<Branch> Branches { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<VehicleType> VehicleTypes { get; set; }
    }
}