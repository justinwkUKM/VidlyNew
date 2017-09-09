namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setBirthdateOfCustomerModel : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = CAST('1990-01-01' AS DATETIME) WHERE Id = 1");
            Sql("UPDATE Customers SET Birthdate = CAST('1991-02-05' AS DATETIME) WHERE Id = 2");
            Sql("UPDATE Customers SET Birthdate = CAST('1992-03-06' AS DATETIME) WHERE Id = 3");
            Sql("UPDATE Customers SET Birthdate = CAST('1993-04-07' AS DATETIME) WHERE Id = 4");


        }

        public override void Down()
        {
        }
    }
}
