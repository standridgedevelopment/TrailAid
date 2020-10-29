namespace TrailAid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favorites : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.VisitedDetail", newName: "VisitedListItem");
            DropColumn("dbo.VisitedListItem", "CityID");
            DropColumn("dbo.VisitedListItem", "CityName");
            DropColumn("dbo.VisitedListItem", "ParkID");
            DropColumn("dbo.VisitedListItem", "ParkName");
            DropColumn("dbo.VisitedListItem", "Rating");
            DropColumn("dbo.VisitedListItem", "Review");
            DropColumn("dbo.VisitedListItem", "AddToFavorites");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VisitedListItem", "AddToFavorites", c => c.Boolean(nullable: false));
            AddColumn("dbo.VisitedListItem", "Review", c => c.String());
            AddColumn("dbo.VisitedListItem", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.VisitedListItem", "ParkName", c => c.String());
            AddColumn("dbo.VisitedListItem", "ParkID", c => c.Int());
            AddColumn("dbo.VisitedListItem", "CityName", c => c.String());
            AddColumn("dbo.VisitedListItem", "CityID", c => c.Int());
            RenameTable(name: "dbo.VisitedListItem", newName: "VisitedDetail");
        }
    }
}
