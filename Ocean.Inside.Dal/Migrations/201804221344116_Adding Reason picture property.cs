namespace Ocean.Inside.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddingReasonpictureproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reasons", "Picture_Id", c => c.Int());
            CreateIndex("dbo.Reasons", "Picture_Id");
            AddForeignKey("dbo.Reasons", "Picture_Id", "dbo.Image", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reasons", "Picture_Id", "dbo.Image");
            DropIndex("dbo.Reasons", new[] { "Picture_Id" });
            DropColumn("dbo.Reasons", "Picture_Id");
        }
    }
}
