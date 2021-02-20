namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        VehicleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.VehicleTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Reservations", new[] { "VehicleTypeId" });
            DropIndex("dbo.Reservations", new[] { "CustomerId" });
            DropTable("dbo.Reservations");
        }
    }
}
