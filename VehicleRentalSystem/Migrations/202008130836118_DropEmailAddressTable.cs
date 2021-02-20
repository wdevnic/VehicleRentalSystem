namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropEmailAddressTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmailAddresses", "BusinessEntityId", "dbo.BusinessEntities");
            DropIndex("dbo.EmailAddresses", new[] { "BusinessEntityId" });
            DropTable("dbo.EmailAddresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmailAddresses",
                c => new
                    {
                        BusinessEntityId = c.Int(nullable: false),
                        EmailAddressId = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => new { t.BusinessEntityId, t.EmailAddressId });
            
            CreateIndex("dbo.EmailAddresses", "BusinessEntityId");
            AddForeignKey("dbo.EmailAddresses", "BusinessEntityId", "dbo.BusinessEntities", "BusinessEntityId", cascadeDelete: true);
        }
    }
}
