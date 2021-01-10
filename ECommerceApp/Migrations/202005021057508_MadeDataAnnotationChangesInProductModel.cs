namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDataAnnotationChangesInProductModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_Product", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Product", "IsDelete", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Product", "IsFeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_Product", "IsFeatured", c => c.Boolean());
            AlterColumn("dbo.Tbl_Product", "IsDelete", c => c.Boolean());
            AlterColumn("dbo.Tbl_Product", "IsActive", c => c.Boolean());
        }
    }
}
