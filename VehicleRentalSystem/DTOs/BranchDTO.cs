﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.DTOs
{
    public class BranchDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}