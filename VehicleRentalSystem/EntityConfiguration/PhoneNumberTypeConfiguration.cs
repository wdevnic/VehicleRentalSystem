using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class PhoneNumberTypeConfiguration : EntityTypeConfiguration<PhoneNumberType>
    {
        public PhoneNumberTypeConfiguration()
        {
            HasKey(p => p.PhoneNumberTypeId);
            Property(p => p.Name).HasMaxLength(50);
        }
    }
}