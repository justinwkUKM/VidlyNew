namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTYPEtoGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genres", "type");
        }
    }
}
