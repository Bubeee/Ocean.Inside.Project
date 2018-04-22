namespace Ocean.Inside.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddingReasonEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Type = c.String(),
                        Content = c.String(),
                        Tour_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tour", t => t.Tour_Id)
                .Index(t => t.Tour_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reasons", "Tour_Id", "dbo.Tour");
            DropIndex("dbo.Reasons", new[] { "Tour_Id" });
            DropTable("dbo.Reasons");
        }
    }
}
