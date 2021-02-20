﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.ViewModels
{
    public class AddressViewModel
    {        
        public BusinessEntityAddress BEAddress { get; set; }
        public ICollection<AddressType> AddressTypes { get; set; }
    }
}