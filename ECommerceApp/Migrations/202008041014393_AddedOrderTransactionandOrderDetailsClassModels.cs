namespace ECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderTransactionandOrderDetailsClassModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_OrderDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        SubTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_OrderTransaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDetailId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AdditionalOrderInfo = c.String(),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        DeliveryAddress = c.String(),
                        PhoneNo = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_OrderDetail", t => t.OrderDetailId, cascadeDelete: true)
                .Index(t => t.OrderDetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_OrderTransaction", "OrderDetailId", "dbo.Tbl_OrderDetail");
            DropIndex("dbo.Tbl_OrderTransaction", new[] { "OrderDetailId" });
            DropTable("dbo.Tbl_OrderTransaction");
            DropTable("dbo.Tbl_OrderDetail");
        }
    }
}
