namespace VehicleRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressTypesData : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO AddressTypes 
                  VALUES
                ('Billing'),
                ('Business'),
                ('Home'),
                ('Mailing'),
                ('Shipping'),
                ('Work')");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM AddressTypes");
        }
    }
}
