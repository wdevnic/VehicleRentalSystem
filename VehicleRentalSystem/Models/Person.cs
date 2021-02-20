using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class Person
    {
        public int BusinessEntityId { get; set; }
        public string PersonType { get; set; }
        public string Title { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Customer")]
        public string FullName
        {
            get
            {
                return Title + " "+ FirstName + " " + LastName;
            }
        }

        public BusinessEntity BusinessEntity { get; set; }
    }
}