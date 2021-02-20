namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCasacadeDeleteVehicleTypeRentalTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "VehicleTypeId", "dbo.VehicleTypes");
            AddForeignKey("dbo.Rentals", "VehicleTypeId", "dbo.VehicleTypes", "VehicleTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "VehicleTypeId", "dbo.VehicleTypes");
            AddForeignKey("dbo.Rentals", "VehicleTypeId", "dbo.VehicleTypes", "VehicleTypeId", cascadeDelete: true);
        }
    }
}
