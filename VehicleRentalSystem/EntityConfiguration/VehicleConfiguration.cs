using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class VehicleConfiguration : EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
            HasKey(v => v.VehicleId);
            HasRequired(v => v.Branch).WithMany(b => b.Vehicles).HasForeignKey(v => v.BranchId);
            HasRequired(v => v.VehicleModel).WithMany(b => b.Vehicles).HasForeignKey(v => v.VehicleModelId);


        }
    }
}