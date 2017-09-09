namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setDataofTypesInGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id,Name, type) VALUES (6, 'My', 'Advanced')");
            Sql("INSERT INTO Genres (Id,Name, type) VALUES (7, 'Your','Intermediate')");
        }
        
        public override void Down()
        {
        }
    }
}
