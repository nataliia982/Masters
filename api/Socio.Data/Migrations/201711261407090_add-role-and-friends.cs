namespace Socio.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addroleandfriends : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "UserProfile_Id", c => c.Int());
            AddColumn("dbo.UserAccounts", "Role", c => c.Int(nullable: false, defaultValue: 1));
            CreateIndex("dbo.UserProfiles", "UserProfile_Id");
            AddForeignKey("dbo.UserProfiles", "UserProfile_Id", "dbo.UserProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.UserProfiles", new[] { "UserProfile_Id" });
            DropColumn("dbo.UserAccounts", "Role");
            DropColumn("dbo.UserProfiles", "UserProfile_Id");
        }
    }
}
