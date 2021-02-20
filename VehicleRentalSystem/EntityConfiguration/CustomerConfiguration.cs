using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class CustomerConfiguration  : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            HasKey(c => c.CustomerId);
            Property(c => c.CustomerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.Branch).WithMany(b => b.Customers).HasForeignKey(c => c.BranchId);
        }
    }
}