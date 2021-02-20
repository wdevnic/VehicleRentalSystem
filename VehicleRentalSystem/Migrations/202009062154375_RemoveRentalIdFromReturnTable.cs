namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRentalIdFromReturnTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Returns", "RentalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Returns", "RentalId", c => c.Int(nullable: false));
        }
    }
}
