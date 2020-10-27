namespace TrailAid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visited",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(),
                        TrailID = c.Int(),
                        AddToFavorites = c.Boolean(nullable: false),
                        Rating = c.Int(nullable: false),
                        Review = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Trail", t => t.TrailID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.TrailID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visited", "UserID", "dbo.User");
            DropForeignKey("dbo.Visited", "TrailID", "dbo.Trail");
            DropIndex("dbo.Visited", new[] { "TrailID" });
            DropIndex("dbo.Visited", new[] { "UserID" });
            DropTable("dbo.Visited");
        }
    }
}
