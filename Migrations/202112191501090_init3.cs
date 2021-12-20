namespace KioskManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "EmployeeName", c => c.String(maxLength: 150));
            AddColumn("dbo.Employee", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Team", "TeamName", c => c.String(maxLength: 150));
            AddColumn("dbo.Kiosk", "KioskName", c => c.String(maxLength: 150));
            AddColumn("dbo.ItemCategory", "ItemCategoryName", c => c.String(maxLength: 150));
            DropColumn("dbo.Employee", "Employee_name");
            DropColumn("dbo.Employee", "Date_of_birth");
            DropColumn("dbo.Team", "Team_name");
            DropColumn("dbo.Kiosk", "Kiosk_name");
            DropColumn("dbo.ItemCategory", "Item_category_name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemCategory", "Item_category_name", c => c.String(maxLength: 150));
            AddColumn("dbo.Kiosk", "Kiosk_name", c => c.String(maxLength: 150));
            AddColumn("dbo.Team", "Team_name", c => c.String(maxLength: 150));
            AddColumn("dbo.Employee", "Date_of_birth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employee", "Employee_name", c => c.String(maxLength: 150));
            DropColumn("dbo.ItemCategory", "ItemCategoryName");
            DropColumn("dbo.Kiosk", "KioskName");
            DropColumn("dbo.Team", "TeamName");
            DropColumn("dbo.Employee", "DateOfBirth");
            DropColumn("dbo.Employee", "EmployeeName");
        }
    }
}
