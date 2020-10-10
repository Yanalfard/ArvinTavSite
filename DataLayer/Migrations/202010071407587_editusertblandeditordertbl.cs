namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editusertblandeditordertbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "RoleID" });
            RenameColumn(table: "dbo.Users", name: "RoleID", newName: "UserRole_RoleID");
            AddColumn("dbo.Orders", "Description", c => c.String(maxLength: 600));
            AddColumn("dbo.Users", "Brand", c => c.String(maxLength: 300));
            AddColumn("dbo.Users", "Image", c => c.String());
            AlterColumn("dbo.Users", "UserRole_RoleID", c => c.Int());
            CreateIndex("dbo.Users", "UserRole_RoleID");
            AddForeignKey("dbo.Users", "UserRole_RoleID", "dbo.UserRoles", "RoleID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRole_RoleID", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRole_RoleID" });
            AlterColumn("dbo.Users", "UserRole_RoleID", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Image");
            DropColumn("dbo.Users", "Brand");
            DropColumn("dbo.Orders", "Description");
            RenameColumn(table: "dbo.Users", name: "UserRole_RoleID", newName: "RoleID");
            CreateIndex("dbo.Users", "RoleID");
            AddForeignKey("dbo.Users", "RoleID", "dbo.UserRoles", "RoleID", cascadeDelete: true);
        }
    }
}
