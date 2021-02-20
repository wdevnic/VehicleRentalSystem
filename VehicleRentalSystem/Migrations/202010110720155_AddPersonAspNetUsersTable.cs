namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonAspNetUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "PersonId");
            AddForeignKey("dbo.AspNetUsers", "PersonId", "dbo.People", "BusinessEntityId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PersonId", "dbo.People");
            DropIndex("dbo.AspNetUsers", new[] { "PersonId" });
            DropColumn("dbo.AspNetUsers", "PersonId");
        }
    }
}
