namespace TrailAid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VisitedDetail", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VisitedDetail", "UserName", c => c.String());
        }
    }
}
