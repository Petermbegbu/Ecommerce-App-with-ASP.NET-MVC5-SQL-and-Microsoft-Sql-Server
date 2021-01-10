namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDataAnnotationInProductModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_Product", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_Product", "Description", c => c.DateTime(nullable: false));
        }
    }
}
