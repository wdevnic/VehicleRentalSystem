﻿namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreasePersonTypeMaxLengthPersonTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "PersonType", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "PersonType", c => c.String(maxLength: 2));
        }
    }
}
