using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class PersonPhone
    {
        public int BusinessEntityId { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeId { get; set; }

        public BusinessEntity BusinessEntity { get; set; }
        [Display(Name = "Phone Number Type")]
        public PhoneNumberType PhoneNumberType { get; set; }

    }
}