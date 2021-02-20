namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReCreateEmailAddressTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailAddresses",
                c => new
                    {
                        BusinessEntityId = c.Int(nullable: false),
                        EmailAddressId = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => new { t.BusinessEntityId, t.EmailAddressId })
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntityId, cascadeDelete: true)
                .Index(t => t.BusinessEntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailAddresses", "BusinessEntityId", "dbo.BusinessEntities");
            DropIndex("dbo.EmailAddresses", new[] { "BusinessEntityId" });
            DropTable("dbo.EmailAddresses");
        }
    }
}
