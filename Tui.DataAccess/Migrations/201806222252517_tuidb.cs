namespace Tui.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tuidb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AirPlanes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AirPlaneName = c.String(),
                        TakeOffEffort = c.Double(nullable: false),
                        Speed = c.Double(nullable: false),
                        Consumption = c.Double(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Airport_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airports", t => t.Airport_Id)
                .Index(t => t.Airport_Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AirPlaneId = c.Int(nullable: false),
                        DepartureAirportId = c.Int(nullable: false),
                        ArrivalAirportId = c.Int(nullable: false),
                        FuelConsumption = c.Double(nullable: false),
                        Distance = c.Double(nullable: false),
                        Duration = c.Double(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AirPlanes", t => t.AirPlaneId, cascadeDelete: true)
                .ForeignKey("dbo.Airports", t => t.DepartureAirportId, cascadeDelete: false)
                .ForeignKey("dbo.Airports", t => t.ArrivalAirportId, cascadeDelete: false)
                .Index(t => t.AirPlaneId)
                .Index(t => t.ArrivalAirportId)
                .Index(t => t.DepartureAirportId);
            
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameAirport = c.String(),
                        CityOfAirport = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flights", "DepartureAirportId", "dbo.Airports");
            DropForeignKey("dbo.AirPlanes", "Airport_Id", "dbo.Airports");
            DropForeignKey("dbo.Flights", "AirPlaneId", "dbo.AirPlanes");
            DropIndex("dbo.Flights", new[] { "DepartureAirportId" });
            DropIndex("dbo.Flights", new[] { "AirPlaneId" });
            DropIndex("dbo.AirPlanes", new[] { "Airport_Id" });
            DropTable("dbo.Airports");
            DropTable("dbo.Flights");
            DropTable("dbo.AirPlanes");
        }
    }
}
