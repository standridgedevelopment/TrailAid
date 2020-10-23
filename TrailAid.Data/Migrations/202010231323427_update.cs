namespace TrailAid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
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
                        Rating = c.Int(nullable: false),
                        Difficulty = c.String(),
                        Description = c.String(),
                        Distance = c.Int(nullable: false),
                        TypeOftTerrain = c.String(),
                        Tags = c.String(),
                        Elevation = c.Int(nullable: false),
                        RouteType = c.String(),
                        City_ID = c.Int(),
                        Park_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.City_ID)
                .ForeignKey("dbo.Park", t => t.Park_ID)
                .Index(t => t.City_ID)
                .Index(t => t.Park_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trail", "Park_ID", "dbo.Park");
            DropForeignKey("dbo.Trail", "City_ID", "dbo.City");
            DropForeignKey("dbo.Park", "CityID", "dbo.City");
            DropIndex("dbo.Trail", new[] { "Park_ID" });
            DropIndex("dbo.Trail", new[] { "City_ID" });
            DropIndex("dbo.Park", new[] { "CityID" });
            DropTable("dbo.Trail");
            DropTable("dbo.Park");
        }
    }
}
