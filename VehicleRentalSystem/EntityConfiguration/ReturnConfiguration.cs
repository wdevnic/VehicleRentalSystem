using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class ReturnConfiguration : EntityTypeConfiguration<Return>
    {
        public ReturnConfiguration()
        {
            HasKey(r => r.ReturnId);
            HasRequired(r => r.Rental).WithOptional().WillCascadeOnDelete(true);
        }
    }
}