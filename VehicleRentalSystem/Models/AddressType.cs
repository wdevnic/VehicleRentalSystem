using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class AddressType
    {
        public int AddressTypeId { get; set; }
        [Display(Name = "Address Type")]
        public string Name { get; set; }
    }
}