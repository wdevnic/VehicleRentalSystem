namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleManufacturerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleManufacturers",
                c => new
                    {
                        VehicleManufactererId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                    })
                .PrimaryKey(t => t.VehicleManufactererId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehicleManufacturers");
        }
    }
}
