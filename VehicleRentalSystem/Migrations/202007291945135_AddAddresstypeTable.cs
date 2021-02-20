namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddresstypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        AddressTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AddressTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AddressTypes");
        }
    }
}
