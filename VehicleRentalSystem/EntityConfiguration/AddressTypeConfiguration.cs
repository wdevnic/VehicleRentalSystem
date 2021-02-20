using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class AddressTypeConfiguration : EntityTypeConfiguration<AddressType>
    {
        public AddressTypeConfiguration()
        {
            HasKey(a => a.AddressTypeId);
            Property(a => a.Name).HasMaxLength(50);
        }
    }
}