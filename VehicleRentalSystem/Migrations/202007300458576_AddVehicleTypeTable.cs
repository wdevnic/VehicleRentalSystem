namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.VehicleTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehicleTypes");
        }
    }
}
