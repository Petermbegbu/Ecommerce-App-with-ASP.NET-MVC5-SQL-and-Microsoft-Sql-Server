namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDataAnnotationChangesInCategoryModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_Category", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Category", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_Category", "IsDelete", c => c.Boolean());
            AlterColumn("dbo.Tbl_Category", "IsActive", c => c.Boolean());
        }
    }
}
