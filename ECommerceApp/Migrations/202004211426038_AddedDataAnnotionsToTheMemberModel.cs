namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotionsToTheMemberModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_Member", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Tbl_Member", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Tbl_Member", "EmailId", c => c.String(nullable: false));
            AlterColumn("dbo.Tbl_Member", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Tbl_Member", "IsActive", c => c.Boolean());
            AlterColumn("dbo.Tbl_Member", "IsDelete", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_Member", "IsDelete", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Member", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Member", "Password", c => c.String());
            AlterColumn("dbo.Tbl_Member", "EmailId", c => c.String());
            AlterColumn("dbo.Tbl_Member", "LastName", c => c.String());
            AlterColumn("dbo.Tbl_Member", "FirstName", c => c.String());
        }
    }
}
