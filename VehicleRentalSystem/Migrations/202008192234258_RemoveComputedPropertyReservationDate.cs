namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveComputedPropertyReservationDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "ReservationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "ReservationDate", c => c.DateTime(nullable: false));
        }
    }
}
