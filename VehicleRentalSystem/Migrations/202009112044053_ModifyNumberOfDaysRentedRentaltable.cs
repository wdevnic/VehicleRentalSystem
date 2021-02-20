namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyNumberOfDaysRentedRentaltable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rentals", "NumberOfDaysRented");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "NumberOfDaysRented", c => c.Int(nullable: false));
        }
    }
}
