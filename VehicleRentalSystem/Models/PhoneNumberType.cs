using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class PhoneNumberType
    {
        public int PhoneNumberTypeId { get; set; }
        [Display(Name = "Phone Number Type")]
        public string Name { get; set; }
    }
}