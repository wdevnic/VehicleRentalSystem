namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDeleteCascadeVehiclesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "VehicleModelId", "dbo.VehicleModels");
            AddForeignKey("dbo.Vehicles", "VehicleModelId", "dbo.VehicleModels", "VehicleModelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "VehicleModelId", "dbo.VehicleModels");
            AddForeignKey("dbo.Vehicles", "VehicleModelId", "dbo.VehicleModels", "VehicleModelId", cascadeDelete: true);
        }
    }
}
