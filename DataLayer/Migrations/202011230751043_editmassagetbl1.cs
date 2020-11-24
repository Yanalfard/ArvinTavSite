namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editmassagetbl1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Massages", "PhoneNumber", c => c.String(maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Massages", "PhoneNumber", c => c.String(maxLength: 15));
        }
    }
}
