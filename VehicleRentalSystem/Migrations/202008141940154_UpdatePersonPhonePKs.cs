namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePersonPhonePKs : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PersonPhones");
            AlterColumn("dbo.PersonPhones", "PhoneNumber", c => c.String(maxLength: 25));
            AddPrimaryKey("dbo.PersonPhones", new[] { "BusinessEntityId", "PhoneNumberTypeId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PersonPhones");
            AlterColumn("dbo.PersonPhones", "PhoneNumber", c => c.String(nullable: false, maxLength: 25));
            AddPrimaryKey("dbo.PersonPhones", new[] { "BusinessEntityId", "PhoneNumber", "PhoneNumberTypeId" });
        }
    }
}
