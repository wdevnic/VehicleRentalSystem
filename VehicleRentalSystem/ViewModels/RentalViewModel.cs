using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.ViewModels
{
    public class RentalViewModel
    {    
        public Rental Rental { get; set; }
        public Return Return { get; set; }
        [Display(Name="Days Rented")]
        public decimal DaysRented { get; set; }
        [Display(Name ="Rental Cost")]
        public decimal RentalCost { get; set; }
        [Display(Name = "Days Overdue")]
        public decimal DaysOverdue { get; set; }
        [Display(Name = "Overdue Cost")]
        public decimal OverdueCost { get; set; }
        public ICollection<Branch> Branches { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<VehicleModel> VehicleModels { get; set; }
        public ICollection<VehicleType> VehicleTypes { get; set; }
    }
}