namespace Socio.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwaseditedflagtofeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedMessages", "WasEdited", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedMessages", "WasEdited");
        }
    }
}
