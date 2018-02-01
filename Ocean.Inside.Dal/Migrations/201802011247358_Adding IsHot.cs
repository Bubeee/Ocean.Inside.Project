namespace Ocean.Inside.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingIsHot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tour", "IsHot", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Tour", "IsHot");
        }
    }
}
