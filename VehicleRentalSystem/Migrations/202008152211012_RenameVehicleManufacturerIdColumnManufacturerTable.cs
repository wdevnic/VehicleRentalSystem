namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameVehicleManufacturerIdColumnManufacturerTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleModels", "VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropPrimaryKey("dbo.VehicleManufacturers");
            DropColumn("dbo.VehicleManufacturers", "VehicleManufactererId");
            AddColumn("dbo.VehicleManufacturers", "VehicleManufacturerId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.VehicleManufacturers", "VehicleManufacturerId");
            AddForeignKey("dbo.VehicleModels", "VehicleManufacturerId", "dbo.VehicleManufacturers", "VehicleManufacturerId", cascadeDelete: true);
            
        }
        
        public override void Down()
        {           
            DropForeignKey("dbo.VehicleModels", "VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropPrimaryKey("dbo.VehicleManufacturers");
            AddColumn("dbo.VehicleManufacturers", "VehicleManufactererId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.VehicleManufacturers", "VehicleManufacturerId");
            AddPrimaryKey("dbo.VehicleManufacturers", "VehicleManufactererId");
            AddForeignKey("dbo.VehicleModels", "VehicleManufacturerId", "dbo.VehicleManufacturers", "VehicleManufactererId", cascadeDelete: true);
        }
    }
}
