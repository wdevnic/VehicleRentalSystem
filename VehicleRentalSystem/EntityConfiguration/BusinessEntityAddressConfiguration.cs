using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class BusinessEntityAddressConfiguration : EntityTypeConfiguration<BusinessEntityAddress>
    {
        public BusinessEntityAddressConfiguration()
        {
            HasKey(b => new { b.BusinessEntityId, b.AddressId, b.AddressTypeId }); 
        }
    }
}