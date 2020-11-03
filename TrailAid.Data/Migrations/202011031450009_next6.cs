namespace TrailAid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next6 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TrailDetail", newName: "TrailListInPark");
            RenameColumn(table: "dbo.TrailListInPark", name: "ParkID", newName: "Park_ID");
            RenameIndex(table: "dbo.TrailListInPark", name: "IX_ParkID", newName: "IX_Park_ID");
            AlterColumn("dbo.Trail", "Name", c => c.String());
            DropColumn("dbo.TrailListInPark", "CityID");
            DropColumn("dbo.TrailListInPark", "CityName");
            DropColumn("dbo.TrailListInPark", "StateID");
            DropColumn("dbo.TrailListInPark", "StateName");
            DropColumn("dbo.TrailListInPark", "ParkName");
            DropColumn("dbo.TrailListInPark", "Difficulty");
            DropColumn("dbo.TrailListInPark", "Description");
            DropColumn("dbo.TrailListInPark", "Distance");
            DropColumn("dbo.TrailListInPark", "TypeOfTerrain");
            DropColumn("dbo.TrailListInPark", "Tags");
            DropColumn("dbo.TrailListInPark", "Elevation");
            DropColumn("dbo.TrailListInPark", "RouteType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrailListInPark", "RouteType", c => c.String());
            AddColumn("dbo.TrailListInPark", "Elevation", c => c.Int(nullable: false));
            AddColumn("dbo.TrailListInPark", "Tags", c => c.String());
            AddColumn("dbo.TrailListInPark", "TypeOfTerrain", c => c.String());
            AddColumn("dbo.TrailListInPark", "Distance", c => c.Int(nullable: false));
            AddColumn("dbo.TrailListInPark", "Description", c => c.String());
            AddColumn("dbo.TrailListInPark", "Difficulty", c => c.String());
            AddColumn("dbo.TrailListInPark", "ParkName", c => c.String());
            AddColumn("dbo.TrailListInPark", "StateName", c => c.String());
            AddColumn("dbo.TrailListInPark", "StateID", c => c.Int());
            AddColumn("dbo.TrailListInPark", "CityName", c => c.String());
            AddColumn("dbo.TrailListInPark", "CityID", c => c.Int());
            AlterColumn("dbo.Trail", "Name", c => c.String(nullable: false));
            RenameIndex(table: "dbo.TrailListInPark", name: "IX_Park_ID", newName: "IX_ParkID");
            RenameColumn(table: "dbo.TrailListInPark", name: "Park_ID", newName: "ParkID");
            RenameTable(name: "dbo.TrailListInPark", newName: "TrailDetail");
        }
    }
}
