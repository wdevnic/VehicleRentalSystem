using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.EntityConfiguration
{
    public class BusinessEntityConfiguration : EntityTypeConfiguration<BusinessEntity>
    {
        public BusinessEntityConfiguration()
        {
            HasKey(b => b.BusinessEntityId);
        }  
    }
}