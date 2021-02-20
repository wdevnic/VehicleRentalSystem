using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class VehicleModelConfiguration : EntityTypeConfiguration<VehicleModel>
    {
        public VehicleModelConfiguration()
        {
            HasKey(v => v.VehicleModelId);
            Property(v => v.Name).HasMaxLength(60);
            HasRequired(v => v.VehicleManufacturer).WithMany(v => v.VehicleModels).HasForeignKey(v => v.VehicleManufacturerId);
        }
    }
}