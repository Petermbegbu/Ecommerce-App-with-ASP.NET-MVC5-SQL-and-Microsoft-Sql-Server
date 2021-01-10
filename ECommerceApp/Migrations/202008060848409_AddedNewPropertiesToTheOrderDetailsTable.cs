namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewPropertiesToTheOrderDetailsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_OrderDetail", "ProductName", c => c.String());
            AddColumn("dbo.Tbl_OrderDetail", "ProductImage", c => c.String());
            AddColumn("dbo.Tbl_OrderDetail", "CreateDate", c => c.DateTime());
            AddColumn("dbo.Tbl_OrderDetail", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_OrderDetail", "Status");
            DropColumn("dbo.Tbl_OrderDetail", "CreateDate");
            DropColumn("dbo.Tbl_OrderDetail", "ProductImage");
            DropColumn("dbo.Tbl_OrderDetail", "ProductName");
        }
    }
}
