namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(maxLength: 60),
                        AddressLine2 = c.String(maxLength: 60),
                        City = c.String(maxLength: 30),
                        PostalCode = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Addresses");
        }
    }
}
