namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDeleteRentalsRenturnsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Returns", "ReturnId", "dbo.Rentals");
            AddForeignKey("dbo.Returns", "ReturnId", "dbo.Rentals", "RentalId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Returns", "ReturnId", "dbo.Rentals");
            AddForeignKey("dbo.Returns", "ReturnId", "dbo.Rentals", "RentalId");
        }
    }
}
