using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class Branch
    {
        [Display(Name = "Id")]
        public int BusinessEntityId { get; set; }
        [Display(Name = "Branch Name")]
        public string Name { get; set; }
        public BusinessEntity BusinessEntity { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public ICollection<Vehicle> Vehicles{ get; set; }
    }
}