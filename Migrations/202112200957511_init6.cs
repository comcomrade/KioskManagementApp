namespace KioskManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String(maxLength: 500));
            AlterColumn("dbo.User", "Username", c => c.String(maxLength: 150));
        }
    }
}
