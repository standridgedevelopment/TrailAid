namespace TrailAid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class state : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trail", "Distance", c => c.Double(nullable: false));
            AlterColumn("dbo.Trail", "Elevation", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trail", "Elevation", c => c.Int(nullable: false));
            AlterColumn("dbo.Trail", "Distance", c => c.Int(nullable: false));
        }
    }
}
