namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewPropertiesToTheOrderTransactionClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_OrderTransaction", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Tbl_OrderTransaction", "TotalItems", c => c.Int());
            AddColumn("dbo.Tbl_OrderTransaction", "DeliveryDay", c => c.String());
            AddColumn("dbo.Tbl_OrderTransaction", "Discount", c => c.Int());
            AddColumn("dbo.Tbl_OrderTransaction", "SubTotal", c => c.Int());
            AddColumn("dbo.Tbl_OrderTransaction", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_OrderTransaction", "Status");
            DropColumn("dbo.Tbl_OrderTransaction", "SubTotal");
            DropColumn("dbo.Tbl_OrderTransaction", "Discount");
            DropColumn("dbo.Tbl_OrderTransaction", "DeliveryDay");
            DropColumn("dbo.Tbl_OrderTransaction", "TotalItems");
            DropColumn("dbo.Tbl_OrderTransaction", "CreatedDate");
        }
    }
}
