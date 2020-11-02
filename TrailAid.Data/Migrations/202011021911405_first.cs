namespace TrailAid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllTags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ListOfAllTags = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Park",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityID = c.Int(nullable: false),
                        CityName = c.String(),
                        Acreage = c.Int(nullable: false),
                        Hours = c.String(),
                        PhoneNumber = c.String(),
                        Website = c.String(),
                        AverageTrailRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Trail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CityID = c.Int(),
                        ParkID = c.Int(),
                        TagsID = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        Difficulty = c.String(),
                        Description = c.String(),
                        Distance = c.Int(nullable: false),
                        TypeOfTerrain = c.String(),
                        Tags = c.String(),
                        Elevation = c.Int(nullable: false),
                        RouteType = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AllTags", t => t.TagsID, cascadeDelete: true)
                .ForeignKey("dbo.City", t => t.CityID)
                .ForeignKey("dbo.Park", t => t.ParkID)
                .Index(t => t.CityID)
                .Index(t => t.ParkID)
                .Index(t => t.TagsID);
            
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
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitedFavorite",
                c => new
                    {
                        TrailID = c.Int(nullable: false, identity: true),
                        TrailName = c.String(),
                        User_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.TrailID)
                .ForeignKey("dbo.User", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.TrailDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityID = c.Int(),
                        CityName = c.String(),
                        ParkID = c.Int(),
                        ParkName = c.String(),
                        Rating = c.Double(nullable: false),
                        Difficulty = c.String(),
                        Description = c.String(),
                        Distance = c.Int(nullable: false),
                        TypeOfTerrain = c.String(),
                        Tags = c.String(),
                        Elevation = c.Int(nullable: false),
                        RouteType = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Park", t => t.ParkID)
                .Index(t => t.ParkID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.TrailDetail", "ParkID", "dbo.Park");
            DropForeignKey("dbo.Visited", "UserID", "dbo.User");
            DropForeignKey("dbo.VisitedFavorite", "User_ID", "dbo.User");
            DropForeignKey("dbo.Visited", "TrailID", "dbo.Trail");
            DropForeignKey("dbo.Trail", "ParkID", "dbo.Park");
            DropForeignKey("dbo.Trail", "CityID", "dbo.City");
            DropForeignKey("dbo.Trail", "TagsID", "dbo.AllTags");
            DropForeignKey("dbo.Park", "CityID", "dbo.City");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.TrailDetail", new[] { "ParkID" });
            DropIndex("dbo.VisitedFavorite", new[] { "User_ID" });
            DropIndex("dbo.Visited", new[] { "TrailID" });
            DropIndex("dbo.Visited", new[] { "UserID" });
            DropIndex("dbo.Trail", new[] { "TagsID" });
            DropIndex("dbo.Trail", new[] { "ParkID" });
            DropIndex("dbo.Trail", new[] { "CityID" });
            DropIndex("dbo.Park", new[] { "CityID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.State");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.TrailDetail");
            DropTable("dbo.VisitedFavorite");
            DropTable("dbo.User");
            DropTable("dbo.Visited");
            DropTable("dbo.Trail");
            DropTable("dbo.Park");
            DropTable("dbo.City");
            DropTable("dbo.AllTags");
        }
    }
}
