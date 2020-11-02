namespace TrailAid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrailDetail", "StateID", c => c.Int());
            AddColumn("dbo.TrailDetail", "StateName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrailDetail", "StateName");
            DropColumn("dbo.TrailDetail", "StateID");
        }
    }
}
