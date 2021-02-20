namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCasacadeDeleteToBranchTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Branches", "BusinessEntityId", "dbo.BusinessEntities");
            AddForeignKey("dbo.Branches", "BusinessEntityId", "dbo.BusinessEntities", "BusinessEntityId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "BusinessEntityId", "dbo.BusinessEntities");
            AddForeignKey("dbo.Branches", "BusinessEntityId", "dbo.BusinessEntities", "BusinessEntityId");
        }
    }
}
