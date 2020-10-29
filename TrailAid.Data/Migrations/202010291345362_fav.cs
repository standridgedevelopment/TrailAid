namespace TrailAid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fav : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.VisitedListItem", newName: "VisitedFavorite");
            AddColumn("dbo.VisitedFavorite", "VisitID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisitedFavorite", "VisitID");
            RenameTable(name: "dbo.VisitedFavorite", newName: "VisitedListItem");
        }
    }
}
