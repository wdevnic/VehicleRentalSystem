using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class EmailAddressConfiguration : EntityTypeConfiguration<EmailAddress>
    {
        public EmailAddressConfiguration()
        {
            HasKey(e => new { e.BusinessEntityId, e.EmailAddressId });
            Property(e => e.EmailAddressId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Email).HasMaxLength(50);
        }
    }
}