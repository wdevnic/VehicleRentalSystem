using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class PersonPhoneConfiguration : EntityTypeConfiguration<PersonPhone>
    {
        public PersonPhoneConfiguration()
        {
            HasKey(p => new { p.BusinessEntityId/*, p.PhoneNumber*/, p.PhoneNumberTypeId });
            Property(p => p.PhoneNumber).HasMaxLength(25);
        }
    }
}