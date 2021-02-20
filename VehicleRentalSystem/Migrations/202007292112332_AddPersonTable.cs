namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        BusinessEntityId = c.Int(nullable: false),
                        PersonType = c.String(maxLength: 2),
                        Title = c.String(maxLength: 8),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BusinessEntityId)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntityId)
                .Index(t => t.BusinessEntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "BusinessEntityId", "dbo.BusinessEntities");
            DropIndex("dbo.People", new[] { "BusinessEntityId" });
            DropTable("dbo.People");
        }
    }
}
