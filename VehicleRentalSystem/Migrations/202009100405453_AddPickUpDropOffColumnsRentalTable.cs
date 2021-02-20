namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPickUpDropOffColumnsRentalTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "PickUpLocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "DropOffLocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "PickUpLocationId");
            CreateIndex("dbo.Rentals", "DropOffLocationId");
            AddForeignKey("dbo.Rentals", "DropOffLocationId", "dbo.Branches", "BusinessEntityId", cascadeDelete: false);
            AddForeignKey("dbo.Rentals", "PickUpLocationId", "dbo.Branches", "BusinessEntityId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "PickUpLocationId", "dbo.Branches");
            DropForeignKey("dbo.Rentals", "DropOffLocationId", "dbo.Branches");
            DropIndex("dbo.Rentals", new[] { "DropOffLocationId" });
            DropIndex("dbo.Rentals", new[] { "PickUpLocationId" });
            DropColumn("dbo.Rentals", "DropOffLocationId");
            DropColumn("dbo.Rentals", "PickUpLocationId");
        }
    }
}
