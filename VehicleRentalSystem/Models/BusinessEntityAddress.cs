using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class BusinessEntityAddress
    {
        public int BusinessEntityId { get; set; }
        public BusinessEntity BusinessEntity { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int AddressTypeId { get; set; }
        [Display(Name = "Address Type")]
        public AddressType AddressType { get; set; }
    }
}