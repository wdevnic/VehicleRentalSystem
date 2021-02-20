namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonPhoneTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonPhones",
                c => new
                    {
                        BusinessEntityId = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 25),
                        PhoneNumberTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessEntityId, t.PhoneNumber, t.PhoneNumberTypeId })
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntityId, cascadeDelete: true)
                .ForeignKey("dbo.PhoneNumberTypes", t => t.PhoneNumberTypeId, cascadeDelete: true)
                .Index(t => t.BusinessEntityId)
                .Index(t => t.PhoneNumberTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonPhones", "PhoneNumberTypeId", "dbo.PhoneNumberTypes");
            DropForeignKey("dbo.PersonPhones", "BusinessEntityId", "dbo.BusinessEntities");
            DropIndex("dbo.PersonPhones", new[] { "PhoneNumberTypeId" });
            DropIndex("dbo.PersonPhones", new[] { "BusinessEntityId" });
            DropTable("dbo.PersonPhones");
        }
    }
}
