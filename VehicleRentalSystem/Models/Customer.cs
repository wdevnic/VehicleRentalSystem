using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class Customer
    {
        public Customer()
        {
            Reservations = new List<Reservation>();
        }
        [Display(Name = "Id")]
        public int CustomerId { get; set; }
        public int PersonId { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }       

        public ICollection<Reservation> Reservations { get; set; }
    }
}