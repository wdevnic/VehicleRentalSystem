namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberTypes1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO PhoneNumberTypes 
                  VALUES
                ('Home'),
                ('Work'),
                ('Mobile')");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM PhoneNumberTypes");
        }
    }
}
