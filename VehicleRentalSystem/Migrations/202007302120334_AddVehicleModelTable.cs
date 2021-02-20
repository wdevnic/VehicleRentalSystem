namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleModelTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        VehicleModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        Automatic = c.Boolean(nullable: false),
                        SeatingCapacity = c.Int(nullable: false),
                        BagCapacity = c.Int(nullable: false),
                        VehicleManufacturerId = c.Int(nullable: false),
                        VehicleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleModelId)
                .ForeignKey("dbo.VehicleManufacturers", t => t.VehicleManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.VehicleManufacturerId)
                .Index(t => t.VehicleTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModels", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleModels", "VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropIndex("dbo.VehicleModels", new[] { "VehicleTypeId" });
            DropIndex("dbo.VehicleModels", new[] { "VehicleManufacturerId" });
            DropTable("dbo.VehicleModels");
        }
    }
}
