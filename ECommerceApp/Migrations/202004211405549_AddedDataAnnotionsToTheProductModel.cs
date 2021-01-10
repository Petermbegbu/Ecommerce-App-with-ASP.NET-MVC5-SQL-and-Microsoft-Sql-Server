namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotionsToTheProductModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tbl_Category", new[] { "CategoryName" });
            AlterColumn("dbo.Tbl_Product", "ProductName", c => c.String(maxLength: 300));
            AlterColumn("dbo.Tbl_Product", "IsActive", c => c.Boolean());
            AlterColumn("dbo.Tbl_Product", "IsDelete", c => c.Boolean());
            AlterColumn("dbo.Tbl_Product", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Tbl_Product", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Tbl_Product", "Description", c => c.DateTime());
            AlterColumn("dbo.Tbl_Product", "IsFeatured", c => c.Boolean());
            AlterColumn("dbo.Tbl_Category", "CategoryName", c => c.String(maxLength: 300));
            CreateIndex("dbo.Tbl_Product", "ProductName", unique: true);
            CreateIndex("dbo.Tbl_Category", "CategoryName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tbl_Category", new[] { "CategoryName" });
            DropIndex("dbo.Tbl_Product", new[] { "ProductName" });
            AlterColumn("dbo.Tbl_Category", "CategoryName", c => c.String(maxLength: 500));
            AlterColumn("dbo.Tbl_Product", "IsFeatured", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Product", "Description", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tbl_Product", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tbl_Product", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tbl_Product", "IsDelete", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Product", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Product", "ProductName", c => c.String());
            CreateIndex("dbo.Tbl_Category", "CategoryName", unique: true);
        }
    }
}
