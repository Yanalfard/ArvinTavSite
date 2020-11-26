namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editmassagetbl2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Massages", "Text", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Massages", "Text", c => c.String(maxLength: 500));
        }
    }
}
