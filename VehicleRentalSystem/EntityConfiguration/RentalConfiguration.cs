using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class RentalConfiguration : EntityTypeConfiguration<Rental>
    {
        public RentalConfiguration()
        {
            HasKey(r => r.RentalId);
            //Property(r => r.NumberOfDaysRented).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed); 
            //Property(r => r.AmountDue).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            HasRequired(r => r.Vehicle).WithMany().WillCascadeOnDelete(true);
            HasRequired(r => r.Customer).WithMany().WillCascadeOnDelete(false);
            HasRequired(r => r.VehicleType).WithMany().WillCascadeOnDelete(false);

        }
    }
}