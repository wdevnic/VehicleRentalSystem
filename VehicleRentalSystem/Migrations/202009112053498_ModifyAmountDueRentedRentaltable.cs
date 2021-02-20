namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyAmountDueRentedRentaltable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rentals", "AmountDue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "AmountDue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
