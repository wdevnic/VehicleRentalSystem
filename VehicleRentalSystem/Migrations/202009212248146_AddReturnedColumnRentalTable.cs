﻿namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReturnedColumnRentalTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "Returned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "Returned");
        }
    }
}
