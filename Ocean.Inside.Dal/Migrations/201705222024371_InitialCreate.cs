namespace Ocean.Inside.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tour", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.Tour",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Place = c.String(),
                        FlyFrom = c.String(),
                        Price = c.Decimal(nullable: false, precision: 10, scale: 2),
                        CurrencyCode = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Hotel = c.String(),
                        DurationNights = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false),
                        TourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tour", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.TourSteps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Day = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Description = c.String(),
                        TourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tour", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.Wastes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IsIncluded = c.Boolean(nullable: false),
                        TourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tour", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wastes", "TourId", "dbo.Tour");
            DropForeignKey("dbo.TourSteps", "TourId", "dbo.Tour");
            DropForeignKey("dbo.Image", "TourId", "dbo.Tour");
            DropForeignKey("dbo.CheckIns", "TourId", "dbo.Tour");
            DropIndex("dbo.Wastes", new[] { "TourId" });
            DropIndex("dbo.TourSteps", new[] { "TourId" });
            DropIndex("dbo.Image", new[] { "TourId" });
            DropIndex("dbo.CheckIns", new[] { "TourId" });
            DropTable("dbo.Wastes");
            DropTable("dbo.TourSteps");
            DropTable("dbo.Image");
            DropTable("dbo.Tour");
            DropTable("dbo.CheckIns");
        }
    }
}
