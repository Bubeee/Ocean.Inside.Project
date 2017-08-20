namespace Ocean.Inside.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GalleryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Image", "GalleryItem_Id", c => c.Int());
            CreateIndex("dbo.Image", "GalleryItem_Id");
            AddForeignKey("dbo.Image", "GalleryItem_Id", "dbo.GalleryItems", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "GalleryItem_Id", "dbo.GalleryItems");
            DropIndex("dbo.Image", new[] { "GalleryItem_Id" });
            DropColumn("dbo.Image", "GalleryItem_Id");
            DropTable("dbo.GalleryItems");
        }
    }
}
