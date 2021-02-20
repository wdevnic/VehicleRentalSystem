namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehiclesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        LicensePlate = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        BranchId = c.Int(nullable: false),
                        VehicleModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.VehicleModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.Vehicles", "BranchId", "dbo.Branches");
            DropIndex("dbo.Vehicles", new[] { "VehicleModelId" });
            DropIndex("dbo.Vehicles", new[] { "BranchId" });
            DropTable("dbo.Vehicles");
        }
    }
}
