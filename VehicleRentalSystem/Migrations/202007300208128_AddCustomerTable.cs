namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.BranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CustomerId", "dbo.People");
            DropForeignKey("dbo.Customers", "BranchId", "dbo.Branches");
            DropIndex("dbo.Customers", new[] { "BranchId" });
            DropIndex("dbo.Customers", new[] { "CustomerId" });
            DropTable("dbo.Customers");
        }
    }
}
