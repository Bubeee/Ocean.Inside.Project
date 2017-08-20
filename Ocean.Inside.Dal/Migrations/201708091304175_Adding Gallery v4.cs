namespace Ocean.Inside.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGalleryv4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Image", "TourId", "dbo.Tour");
            DropIndex("dbo.Image", new[] { "TourId" });
            AlterColumn("dbo.Image", "TourId", c => c.Int());
            CreateIndex("dbo.Image", "TourId");
            AddForeignKey("dbo.Image", "TourId", "dbo.Tour", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "TourId", "dbo.Tour");
            DropIndex("dbo.Image", new[] { "TourId" });
            AlterColumn("dbo.Image", "TourId", c => c.Int(nullable: false));
            CreateIndex("dbo.Image", "TourId");
            AddForeignKey("dbo.Image", "TourId", "dbo.Tour", "Id", cascadeDelete: true);
        }
    }
}
