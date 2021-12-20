namespace KioskManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Item", "ItemCategoryId", "dbo.ItemCategory");
            DropIndex("dbo.Employee", new[] { "TeamId" });
            DropIndex("dbo.Item", new[] { "ItemCategoryId" });
            AlterColumn("dbo.Employee", "Gender", c => c.String(maxLength: 10));
            AlterColumn("dbo.Employee", "DateOfBirth", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Employee", "TeamId", c => c.Int(nullable: false));
            AlterColumn("dbo.Item", "ItemName", c => c.String(maxLength: 500));
            AlterColumn("dbo.Item", "Price", c => c.Long(nullable: false));
            AlterColumn("dbo.Item", "ItemDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Item", "ItemCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.ItemCategory", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.User", "Username", c => c.String(maxLength: 150));
            AlterColumn("dbo.User", "Password", c => c.String(maxLength: 500));
            CreateIndex("dbo.Employee", "TeamId");
            CreateIndex("dbo.Item", "ItemCategoryId");
            AddForeignKey("dbo.Employee", "TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
            AddForeignKey("dbo.Item", "ItemCategoryId", "dbo.ItemCategory", "ItemCategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "ItemCategoryId", "dbo.ItemCategory");
            DropForeignKey("dbo.Employee", "TeamId", "dbo.Team");
            DropIndex("dbo.Item", new[] { "ItemCategoryId" });
            DropIndex("dbo.Employee", new[] { "TeamId" });
            AlterColumn("dbo.User", "Password", c => c.String(maxLength: 200));
            AlterColumn("dbo.User", "Username", c => c.String(maxLength: 100));
            AlterColumn("dbo.ItemCategory", "Description", c => c.String(maxLength: 250));
            AlterColumn("dbo.Item", "ItemCategoryId", c => c.Int());
            AlterColumn("dbo.Item", "ItemDescription", c => c.String(maxLength: 250));
            AlterColumn("dbo.Item", "Price", c => c.String(maxLength: 100));
            AlterColumn("dbo.Item", "ItemName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employee", "TeamId", c => c.Int());
            AlterColumn("dbo.Employee", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employee", "Gender", c => c.String(maxLength: 20));
            CreateIndex("dbo.Item", "ItemCategoryId");
            CreateIndex("dbo.Employee", "TeamId");
            AddForeignKey("dbo.Item", "ItemCategoryId", "dbo.ItemCategory", "ItemCategoryId");
            AddForeignKey("dbo.Employee", "TeamId", "dbo.Team", "TeamId");
        }
    }
}
