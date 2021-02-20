namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBusinessEntityAddressTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessEntityAddresses",
                c => new
                    {
                        BusinessEntityId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        AddressTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessEntityId, t.AddressId, t.AddressTypeId })
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.AddressTypes", t => t.AddressTypeId, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntityId, cascadeDelete: true)
                .Index(t => t.BusinessEntityId)
                .Index(t => t.AddressId)
                .Index(t => t.AddressTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessEntityAddresses", "BusinessEntityId", "dbo.BusinessEntities");
            DropForeignKey("dbo.BusinessEntityAddresses", "AddressTypeId", "dbo.AddressTypes");
            DropForeignKey("dbo.BusinessEntityAddresses", "AddressId", "dbo.Addresses");
            DropIndex("dbo.BusinessEntityAddresses", new[] { "AddressTypeId" });
            DropIndex("dbo.BusinessEntityAddresses", new[] { "AddressId" });
            DropIndex("dbo.BusinessEntityAddresses", new[] { "BusinessEntityId" });
            DropTable("dbo.BusinessEntityAddresses");
        }
    }
}
