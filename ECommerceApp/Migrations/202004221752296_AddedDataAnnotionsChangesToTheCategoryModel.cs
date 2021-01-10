namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotionsChangesToTheCategoryModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tbl_Category", new[] { "CategoryName" });
            AlterColumn("dbo.Tbl_Category", "CategoryName", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Tbl_Category", "CategoryName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tbl_Category", new[] { "CategoryName" });
            AlterColumn("dbo.Tbl_Category", "CategoryName", c => c.String(maxLength: 300));
            CreateIndex("dbo.Tbl_Category", "CategoryName", unique: true);
        }
    }
}
