namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReturnTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Returns",
                c => new
                    {
                        ReturnId = c.Int(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        OverdueCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RentalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReturnId)
                .ForeignKey("dbo.Rentals", t => t.ReturnId)
                .Index(t => t.ReturnId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Returns", "ReturnId", "dbo.Rentals");
            DropIndex("dbo.Returns", new[] { "ReturnId" });
            DropTable("dbo.Returns");
        }
    }
}
