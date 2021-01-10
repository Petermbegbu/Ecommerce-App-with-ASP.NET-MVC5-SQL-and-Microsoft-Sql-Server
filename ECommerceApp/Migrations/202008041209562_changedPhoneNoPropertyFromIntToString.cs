namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedPhoneNoPropertyFromIntToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_OrderTransaction", "PhoneNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_OrderTransaction", "PhoneNo", c => c.Int(nullable: false));
        }
    }
}
