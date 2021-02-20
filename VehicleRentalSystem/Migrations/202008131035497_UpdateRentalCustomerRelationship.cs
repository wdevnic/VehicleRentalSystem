namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRentalCustomerRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            AddForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers", "CustomerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            AddForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
