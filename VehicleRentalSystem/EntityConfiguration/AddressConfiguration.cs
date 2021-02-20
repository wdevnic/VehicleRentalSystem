using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            HasKey(a => a.AddressId);
            Property(a => a.AddressLine1).HasMaxLength(60);
            Property(a => a.AddressLine2).HasMaxLength(60);
            Property(a => a.City).HasMaxLength(30);
            Property(a => a.PostalCode).HasMaxLength(15);
        }
    }
}