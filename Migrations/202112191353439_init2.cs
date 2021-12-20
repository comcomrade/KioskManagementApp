namespace KioskManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "ItemId", "dbo.Kiosk");
            DropIndex("dbo.Item", new[] { "ItemId" });
            DropPrimaryKey("dbo.Item");
            CreateTable(
                "dbo.KioskItem",
                c => new
                    {
                        ItemId = c.Int(nullable: false),
                        KioskId = c.Int(nullable: false),
                        StockQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemId, t.KioskId })
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Kiosk", t => t.KioskId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.KioskId);
            
            AlterColumn("dbo.Item", "ItemId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Item", "ItemId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KioskItem", "KioskId", "dbo.Kiosk");
            DropForeignKey("dbo.KioskItem", "ItemId", "dbo.Item");
            DropIndex("dbo.KioskItem", new[] { "KioskId" });
            DropIndex("dbo.KioskItem", new[] { "ItemId" });
            DropPrimaryKey("dbo.Item");
            AlterColumn("dbo.Item", "ItemId", c => c.Int(nullable: false));
            DropTable("dbo.KioskItem");
            AddPrimaryKey("dbo.Item", "ItemId");
            CreateIndex("dbo.Item", "ItemId");
            AddForeignKey("dbo.Item", "ItemId", "dbo.Kiosk", "KioskId");
        }
    }
}
