namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotionsChangesToTheProductModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tbl_Product", "Categories_DataGroupField");
            DropColumn("dbo.Tbl_Product", "Categories_DataTextField");
            DropColumn("dbo.Tbl_Product", "Categories_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_Product", "Categories_DataValueField", c => c.String());
            AddColumn("dbo.Tbl_Product", "Categories_DataTextField", c => c.String());
            AddColumn("dbo.Tbl_Product", "Categories_DataGroupField", c => c.String());
        }
    }
}
