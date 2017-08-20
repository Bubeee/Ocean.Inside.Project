namespace Ocean.Inside.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGalleryv3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Image", name: "GalleryItem_Id", newName: "GalleryItemId");
            RenameIndex(table: "dbo.Image", name: "IX_GalleryItem_Id", newName: "IX_GalleryItemId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Image", name: "IX_GalleryItemId", newName: "IX_GalleryItem_Id");
            RenameColumn(table: "dbo.Image", name: "GalleryItemId", newName: "GalleryItem_Id");
        }
    }
}
