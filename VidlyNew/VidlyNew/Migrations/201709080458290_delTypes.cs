namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delTypes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Genres", "type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "type", c => c.String());
        }
    }
}
