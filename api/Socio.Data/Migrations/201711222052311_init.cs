namespace Socio.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserProfileId = c.Int(nullable: false),
                        ConversationId = c.Int(nullable: false),
                        Body = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conversations", t => t.ConversationId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId)
                .Index(t => t.ConversationId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Position = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Phone = c.String(),
                        ProfileImageUrl = c.String(),
                        WebsiteLink = c.String(),
                        FacebookLink = c.String(),
                        TwitterLink = c.String(),
                        City = c.String(),
                        UserAccountId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountId, cascadeDelete: true)
                .Index(t => t.UserAccountId);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeedText = c.String(),
                        ToUserProfileId = c.Int(nullable: false),
                        FromUserProfileId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.FromUserProfileId, cascadeDelete: false)
                .ForeignKey("dbo.UserProfiles", t => t.ToUserProfileId, cascadeDelete: false)
                .Index(t => t.ToUserProfileId)
                .Index(t => t.FromUserProfileId);
            
            CreateTable(
                "dbo.UserProfileConversations",
                c => new
                    {
                        UserProfile_Id = c.Int(nullable: false),
                        Conversation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserProfile_Id, t.Conversation_Id })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Conversations", t => t.Conversation_Id, cascadeDelete: true)
                .Index(t => t.UserProfile_Id)
                .Index(t => t.Conversation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedMessages", "ToUserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.FeedMessages", "FromUserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Messages", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "UserAccountId", "dbo.UserAccounts");
            DropForeignKey("dbo.UserProfileConversations", "Conversation_Id", "dbo.Conversations");
            DropForeignKey("dbo.UserProfileConversations", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.Messages", "ConversationId", "dbo.Conversations");
            DropIndex("dbo.UserProfileConversations", new[] { "Conversation_Id" });
            DropIndex("dbo.UserProfileConversations", new[] { "UserProfile_Id" });
            DropIndex("dbo.FeedMessages", new[] { "FromUserProfileId" });
            DropIndex("dbo.FeedMessages", new[] { "ToUserProfileId" });
            DropIndex("dbo.UserProfiles", new[] { "UserAccountId" });
            DropIndex("dbo.Messages", new[] { "ConversationId" });
            DropIndex("dbo.Messages", new[] { "UserProfileId" });
            DropTable("dbo.UserProfileConversations");
            DropTable("dbo.FeedMessages");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Messages");
            DropTable("dbo.Conversations");
        }
    }
}
