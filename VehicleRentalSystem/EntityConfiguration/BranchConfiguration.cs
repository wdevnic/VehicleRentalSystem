using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class BranchConfiguration : EntityTypeConfiguration<Branch>
    {
        public BranchConfiguration()
        {
            HasKey(b => b.BusinessEntityId);
            Property(b => b.Name).HasMaxLength(50);
            HasRequired(p => p.BusinessEntity).WithOptional().WillCascadeOnDelete(true);
        }
    }
}