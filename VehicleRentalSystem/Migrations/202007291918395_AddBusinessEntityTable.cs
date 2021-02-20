namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBusinessEntityTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessEntities",
                c => new
                    {
                        BusinessEntityId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BusinessEntityId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BusinessEntities");
        }
    }
}
