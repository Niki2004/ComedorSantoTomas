namespace TCU_Comedor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionApariencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSettings",
                c => new
                    {
                        Id_UserSettings = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        Theme = c.String(),
                        FontSize = c.Int(nullable: false),
                        MenuNotifications = c.Boolean(nullable: false),
                        MealReminders = c.Boolean(nullable: false),
                        ReminderTime = c.Int(nullable: false),
                        DietaryRestrictions = c.String(),
                        PortionSize = c.String(),
                        ShareData = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id_UserSettings)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSettings", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserSettings", new[] { "Id" });
            DropTable("dbo.UserSettings");
        }
    }
}
