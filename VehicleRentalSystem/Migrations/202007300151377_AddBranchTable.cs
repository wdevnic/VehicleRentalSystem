namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBranchTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BusinessEntityId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BusinessEntityId)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntityId)
                .Index(t => t.BusinessEntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "BusinessEntityId", "dbo.BusinessEntities");
            DropIndex("dbo.Branches", new[] { "BusinessEntityId" });
            DropTable("dbo.Branches");
        }
    }
}
