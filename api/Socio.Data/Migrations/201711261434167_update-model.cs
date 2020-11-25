namespace Socio.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.UserAccounts", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccounts", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.UserProfiles", "Role");
        }
    }
}
