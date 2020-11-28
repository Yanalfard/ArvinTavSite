namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editslider : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sliders", "Title", c => c.String(maxLength: 900));
            AlterColumn("dbo.Sliders", "Link", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sliders", "Link", c => c.String(maxLength: 300));
            AlterColumn("dbo.Sliders", "Title", c => c.String(maxLength: 100));
        }
    }
}
