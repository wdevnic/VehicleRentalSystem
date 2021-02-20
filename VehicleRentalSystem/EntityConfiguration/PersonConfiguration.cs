using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            HasKey(p => p.BusinessEntityId);
            Property(p => p.FirstName).HasMaxLength(50);
            Property(p => p.LastName).HasMaxLength(50);
            Property(p => p.Title).HasMaxLength(8);
            Property(p => p.PersonType).HasMaxLength(20);

            HasRequired(p => p.BusinessEntity).WithOptional();

        }
    }
}