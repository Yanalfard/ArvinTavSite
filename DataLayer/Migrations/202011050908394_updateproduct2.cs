namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproduct2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "SignUpTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "SignUpTime", c => c.DateTime());
        }
    }
}
