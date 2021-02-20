namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhoneNumberTypes",
                c => new
                    {
                        PhoneNumberTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PhoneNumberTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhoneNumberTypes");
        }
    }
}
