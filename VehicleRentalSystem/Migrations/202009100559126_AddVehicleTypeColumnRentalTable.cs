namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleTypeColumnRentalTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "VehicleTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "VehicleTypeId");
            AddForeignKey("dbo.Rentals", "VehicleTypeId", "dbo.VehicleTypes", "VehicleTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "VehicleTypeId", "dbo.VehicleTypes");
            DropIndex("dbo.Rentals", new[] { "VehicleTypeId" });
            DropColumn("dbo.Rentals", "VehicleTypeId");
        }
    }
}
