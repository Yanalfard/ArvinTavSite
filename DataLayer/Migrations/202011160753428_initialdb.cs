namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpiderCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Spiders", "SpiderCategory_ID", c => c.Int());
            CreateIndex("dbo.Spiders", "SpiderCategory_ID");
            AddForeignKey("dbo.Spiders", "SpiderCategory_ID", "dbo.SpiderCategories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Spiders", "SpiderCategory_ID", "dbo.SpiderCategories");
            DropIndex("dbo.Spiders", new[] { "SpiderCategory_ID" });
            DropColumn("dbo.Spiders", "SpiderCategory_ID");
            DropTable("dbo.SpiderCategories");
        }
    }
}
