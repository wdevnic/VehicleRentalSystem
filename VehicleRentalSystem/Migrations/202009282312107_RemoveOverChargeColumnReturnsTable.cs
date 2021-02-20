namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOverChargeColumnReturnsTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Returns", "OverdueCharge");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Returns", "OverdueCharge", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
