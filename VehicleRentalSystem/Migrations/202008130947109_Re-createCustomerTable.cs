namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.BranchId);
            
            CreateIndex("dbo.Reservations", "CustomerId");
            CreateIndex("dbo.Rentals", "CustomerId");
            AddForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "PersonId", "dbo.People");
            DropForeignKey("dbo.Customers", "BranchId", "dbo.Branches");
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropIndex("dbo.Reservations", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "BranchId" });
            DropIndex("dbo.Customers", new[] { "PersonId" });
            DropTable("dbo.Customers");
        }
    }
}
