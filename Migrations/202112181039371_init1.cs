namespace KioskManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Employee_name = c.String(maxLength: 150),
                        Gender = c.String(maxLength: 20),
                        Address = c.String(maxLength: 150),
                        Date_of_birth = c.DateTime(nullable: false),
                        Phone = c.String(maxLength: 11),
                        TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false),
                        Team_name = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Kiosk", t => t.TeamId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Kiosk",
                c => new
                    {
                        KioskId = c.Int(nullable: false, identity: true),
                        Kiosk_name = c.String(maxLength: 150),
                        Address = c.String(maxLength: 150),
                        Phone = c.String(maxLength: 11),
                    })
                .PrimaryKey(t => t.KioskId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false),
                        ItemName = c.String(maxLength: 100),
                        Price = c.String(maxLength: 100),
                        Unit = c.String(maxLength: 50),
                        ItemDescription = c.String(maxLength: 250),
                        ItemCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.ItemCategory", t => t.ItemCategoryId)
                .ForeignKey("dbo.Kiosk", t => t.ItemId)
                .Index(t => t.ItemId)
                .Index(t => t.ItemCategoryId);
            
            CreateTable(
                "dbo.ItemCategory",
                c => new
                    {
                        ItemCategoryId = c.Int(nullable: false, identity: true),
                        Item_category_name = c.String(maxLength: 150),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ItemCategoryId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 100),
                        Password = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Team", "TeamId", "dbo.Kiosk");
            DropForeignKey("dbo.Item", "ItemId", "dbo.Kiosk");
            DropForeignKey("dbo.Item", "ItemCategoryId", "dbo.ItemCategory");
            DropForeignKey("dbo.Employee", "TeamId", "dbo.Team");
            DropIndex("dbo.Item", new[] { "ItemCategoryId" });
            DropIndex("dbo.Item", new[] { "ItemId" });
            DropIndex("dbo.Team", new[] { "TeamId" });
            DropIndex("dbo.Employee", new[] { "TeamId" });
            DropTable("dbo.User");
            DropTable("dbo.ItemCategory");
            DropTable("dbo.Item");
            DropTable("dbo.Kiosk");
            DropTable("dbo.Team");
            DropTable("dbo.Employee");
        }
    }
}
