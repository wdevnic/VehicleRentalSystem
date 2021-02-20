namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUsersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "PersonId", "dbo.People");
            DropIndex("dbo.AspNetUsers", new[] { "PersonId" });
            DropColumn("dbo.AspNetUsers", "PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "PersonId");
            AddForeignKey("dbo.AspNetUsers", "PersonId", "dbo.People", "BusinessEntityId", cascadeDelete: true);
        }
    }
}
