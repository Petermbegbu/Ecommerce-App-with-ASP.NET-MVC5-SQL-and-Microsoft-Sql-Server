namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotionsToTheCategoryModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_Category", "CategoryName", c => c.String(maxLength: 500));
            AlterColumn("dbo.Tbl_Category", "IsActive", c => c.Boolean());
            AlterColumn("dbo.Tbl_Category", "IsDelete", c => c.Boolean());
            CreateIndex("dbo.Tbl_Category", "CategoryName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tbl_Category", new[] { "CategoryName" });
            AlterColumn("dbo.Tbl_Category", "IsDelete", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Category", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Category", "CategoryName", c => c.String());
        }
    }
}
