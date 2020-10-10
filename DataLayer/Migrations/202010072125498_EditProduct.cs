namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Product_ID", c => c.Int());
            CreateIndex("dbo.OrderDetails", "Product_ID");
            AddForeignKey("dbo.OrderDetails", "Product_ID", "dbo.Products", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ID", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "Product_ID" });
            DropColumn("dbo.OrderDetails", "Product_ID");
        }
    }
}
