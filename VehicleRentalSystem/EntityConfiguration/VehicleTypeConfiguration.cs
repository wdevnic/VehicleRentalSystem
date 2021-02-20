using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class VehicleTypeConfiguration : EntityTypeConfiguration<VehicleType>
    {
        public VehicleTypeConfiguration()
        {
            HasKey(v => v.VehicleTypeId);
            Property(v => v.Name).HasMaxLength(50);
            
                
        }
    }
}