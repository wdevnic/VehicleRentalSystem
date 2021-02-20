namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservationDateColumnToReservationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ReservationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "ReservationDate");
        }
    }
}
