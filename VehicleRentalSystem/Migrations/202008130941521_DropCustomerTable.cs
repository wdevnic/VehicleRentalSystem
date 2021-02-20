namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropCustomerTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Customers", "CustomerId", "dbo.People");
            DropForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Customers", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "BranchId" });
            DropIndex("dbo.Reservations", new[] { "CustomerId" });
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateIndex("dbo.Rentals", "CustomerId");
            CreateIndex("dbo.Reservations", "CustomerId");
            CreateIndex("dbo.Customers", "BranchId");
            CreateIndex("dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "CustomerId", "dbo.People", "BusinessEntityId");
            AddForeignKey("dbo.Customers", "BranchId", "dbo.Branches", "BusinessEntityId", cascadeDelete: true);
        }
    }
}
