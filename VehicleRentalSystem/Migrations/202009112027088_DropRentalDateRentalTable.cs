namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropRentalDateRentalTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rentals", "RentalDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "RentalDate", c => c.DateTime(nullable: false));
        }
    }
}
