namespace Ocean.Inside.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TourId = c.Int(nullable: false),
                        Path = c.String(nullable: false),
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
                        Hotel = c.String(),
                        Location = c.String(),
                        DepartFrom = c.String(),
                        Price = c.Decimal(nullable: false, precision: 10, scale: 2),
                        CurrencyCode = c.Int(nullable: false),
                        DurationDays = c.Int(nullable: false),
                        DurationNights = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TourProgram",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        StartingDay = c.Int(nullable: false),
                        EndingDay = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        TourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tour", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourProgram", "TourId", "dbo.Tour");
            DropForeignKey("dbo.Image", "TourId", "dbo.Tour");
            DropIndex("dbo.TourProgram", new[] { "TourId" });
            DropIndex("dbo.Image", new[] { "TourId" });
            DropTable("dbo.TourProgram");
            DropTable("dbo.Tour");
            DropTable("dbo.Image");
            DropTable("dbo.ApplicationUsers");
        }
    }
}
