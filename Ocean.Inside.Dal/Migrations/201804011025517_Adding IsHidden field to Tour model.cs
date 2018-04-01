namespace Ocean.Inside.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingIsHiddenfieldtoTourmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tour", "IsHidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tour", "IsHidden");
        }
    }
}
