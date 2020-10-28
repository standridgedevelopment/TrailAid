namespace TrailAid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Park", "AverageTrailRating", c => c.Double(nullable: false));
            AlterColumn("dbo.Trail", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trail", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Park", "AverageTrailRating", c => c.Int(nullable: false));
        }
    }
}
