using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class VehicleManufacturerConfiguration : EntityTypeConfiguration<VehicleManufacturer>
    {
        public VehicleManufacturerConfiguration()
        {
            HasKey(v => v.VehicleManufacturerId);
            Property(v => v.Name).HasMaxLength(60);
        }
    }
}