namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalDateColumnToRentalTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "RentalDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "RentalDate");
        }
    }
}
