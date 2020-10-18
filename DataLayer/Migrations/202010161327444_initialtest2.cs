namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialtest2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeoTages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tage = c.String(),
                        Spider_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Spiders", t => t.Spider_ID)
                .Index(t => t.Spider_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeoTages", "Spider_ID", "dbo.Spiders");
            DropIndex("dbo.SeoTages", new[] { "Spider_ID" });
            DropTable("dbo.SeoTages");
        }
    }
}
