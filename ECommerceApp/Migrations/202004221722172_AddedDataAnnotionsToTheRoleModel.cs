namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotionsToTheRoleModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_Role", "RoleName", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_Role", "RoleName", c => c.String());
        }
    }
}
