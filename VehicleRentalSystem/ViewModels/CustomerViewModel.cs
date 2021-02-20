using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.ViewModels
{
    public class CustomerViewModel
    {

        public CustomerViewModel()
        {
            PhoneNumbers = new List<PhoneNumberViewModel>();
            Addresses = new List<AddressViewModel>();
        }
        
        public Customer Customer { get; set; }

        public IEnumerable<Branch> Branches { get; set; }
        //     public IEnumerable<PhoneNumberType> PhoneNumberTypes { get; set; }

        public ICollection<PhoneNumberViewModel> PhoneNumbers { get; set; }
        public ICollection<AddressViewModel> Addresses { get; set; }

        public ICollection<EmailViewModel> EmailAddresses { get; set; }

    }
    
}