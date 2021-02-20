namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleModelColumnToRentalTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "VehicleModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "VehicleModelId");
            AddForeignKey("dbo.Rentals", "VehicleModelId", "dbo.VehicleModels", "VehicleModelId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "VehicleModelId", "dbo.VehicleModels");
            DropIndex("dbo.Rentals", new[] { "VehicleModelId" });
            DropColumn("dbo.Rentals", "VehicleModelId");
        }
    }
}
