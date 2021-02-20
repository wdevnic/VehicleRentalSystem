using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.ViewModels
{
    public class PhoneNumberViewModel
    {
        public PersonPhone Phone{ get; set; }
        public ICollection<PhoneNumberType> PhoneNumberTypes { get; set; }
    }
}