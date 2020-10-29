namespace TrailAid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.VisitedFavorite");
            AlterColumn("dbo.VisitedFavorite", "VisitID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.VisitedFavorite", "VisitID");
            DropColumn("dbo.VisitedFavorite", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VisitedFavorite", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.VisitedFavorite");
            AlterColumn("dbo.VisitedFavorite", "VisitID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.VisitedFavorite", "ID");
        }
    }
}
