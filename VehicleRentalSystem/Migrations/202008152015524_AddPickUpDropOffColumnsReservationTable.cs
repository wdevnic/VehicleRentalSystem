namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPickUpDropOffColumnsReservationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "PickUpLocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Reservations", "DropOffLocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "PickUpLocationId");
            CreateIndex("dbo.Reservations", "DropOffLocationId");
            AddForeignKey("dbo.Reservations", "DropOffLocationId", "dbo.Branches", "BusinessEntityId", cascadeDelete: false);
            AddForeignKey("dbo.Reservations", "PickUpLocationId", "dbo.Branches", "BusinessEntityId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "PickUpLocationId", "dbo.Branches");
            DropForeignKey("dbo.Reservations", "DropOffLocationId", "dbo.Branches");
            DropIndex("dbo.Reservations", new[] { "DropOffLocationId" });
            DropIndex("dbo.Reservations", new[] { "PickUpLocationId" });
            DropColumn("dbo.Reservations", "DropOffLocationId");
            DropColumn("dbo.Reservations", "PickUpLocationId");
        }
    }
}
