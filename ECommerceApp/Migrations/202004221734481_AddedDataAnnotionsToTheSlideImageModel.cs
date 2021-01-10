namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotionsToTheSlideImageModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_SlideImage", "SlideTitle", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_SlideImage", "SlideTitle", c => c.String());
        }
    }
}
