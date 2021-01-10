namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotionsToTheShippingDeatailModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_ShippingDetail", "Address", c => c.String(maxLength: 300));
            AlterColumn("dbo.Tbl_ShippingDetail", "City", c => c.String(maxLength: 100));
            AlterColumn("dbo.Tbl_ShippingDetail", "State", c => c.String(maxLength: 100));
            AlterColumn("dbo.Tbl_ShippingDetail", "Country", c => c.String(maxLength: 50));
            AlterColumn("dbo.Tbl_ShippingDetail", "ZipCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.Tbl_ShippingDetail", "PaymentType", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_ShippingDetail", "PaymentType", c => c.String());
            AlterColumn("dbo.Tbl_ShippingDetail", "ZipCode", c => c.String());
            AlterColumn("dbo.Tbl_ShippingDetail", "Country", c => c.String());
            AlterColumn("dbo.Tbl_ShippingDetail", "State", c => c.String());
            AlterColumn("dbo.Tbl_ShippingDetail", "City", c => c.String());
            AlterColumn("dbo.Tbl_ShippingDetail", "Address", c => c.String());
        }
    }
}
