namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotionsChangesToTheProductModel1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tbl_Product", new[] { "ProductName" });
            AlterColumn("dbo.Tbl_Product", "ProductName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tbl_Product", "Description", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Tbl_Product", "ProductName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tbl_Product", new[] { "ProductName" });
            AlterColumn("dbo.Tbl_Product", "Description", c => c.DateTime());
            AlterColumn("dbo.Tbl_Product", "ProductName", c => c.String(maxLength: 300));
            CreateIndex("dbo.Tbl_Product", "ProductName", unique: true);
        }
    }
}
