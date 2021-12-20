namespace KioskManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Team", "TeamId", "dbo.Kiosk");
            DropForeignKey("dbo.Employee", "TeamId", "dbo.Team");
            DropIndex("dbo.Team", new[] { "TeamId" });
            DropPrimaryKey("dbo.Team");
            AlterColumn("dbo.Team", "TeamId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Team", "TeamId");
            AddForeignKey("dbo.Employee", "TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "TeamId", "dbo.Team");
            DropPrimaryKey("dbo.Team");
            AlterColumn("dbo.Team", "TeamId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Team", "TeamId");
            CreateIndex("dbo.Team", "TeamId");
            AddForeignKey("dbo.Employee", "TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
            AddForeignKey("dbo.Team", "TeamId", "dbo.Kiosk", "KioskId");
        }
    }
}
