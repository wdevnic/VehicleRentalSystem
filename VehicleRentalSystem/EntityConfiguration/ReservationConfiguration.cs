using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class ReservationConfiguration : EntityTypeConfiguration<Reservation>
    {
        public ReservationConfiguration()
        {
            HasKey(r => r.ReservationId);
            //Property(r => r.ReservationDate).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
}