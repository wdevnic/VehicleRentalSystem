using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class EmailAddress
    {
        public int BusinessEntityId { get; set; }
        public int EmailAddressId { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public BusinessEntity BusinessEntity { get; set; }
    }
}