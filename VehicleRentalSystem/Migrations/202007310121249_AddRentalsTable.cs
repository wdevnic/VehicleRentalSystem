namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        RentalId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        NumberOfDaysRented = c.Int(nullable: false),
                        AmountDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RentalId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.CustomerId)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "VehicleId" });
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropTable("dbo.Rentals");
        }
    }
}
