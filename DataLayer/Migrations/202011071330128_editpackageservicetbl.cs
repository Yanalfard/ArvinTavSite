namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editpackageservicetbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PackageServiceDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Response = c.String(maxLength: 100),
                        PackageService_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PackageServices", t => t.PackageService_ID)
                .Index(t => t.PackageService_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PackageServiceDetails", "PackageService_ID", "dbo.PackageServices");
            DropIndex("dbo.PackageServiceDetails", new[] { "PackageService_ID" });
            DropTable("dbo.PackageServiceDetails");
        }
    }
}
