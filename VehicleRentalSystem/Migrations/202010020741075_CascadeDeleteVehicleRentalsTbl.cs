namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDeleteVehicleRentalsTbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "VehicleId", "dbo.Vehicles");
            AddForeignKey("dbo.Rentals", "VehicleId", "dbo.Vehicles", "VehicleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "VehicleId", "dbo.Vehicles");
            AddForeignKey("dbo.Rentals", "VehicleId", "dbo.Vehicles", "VehicleId");
        }
    }
}
