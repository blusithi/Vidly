namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMovies : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Genres(Id, Name) Values (1, 'Action')");
            Sql("INSERT INTO Genres(Id, Name) Values (2, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) Values (3, 'Sci-Fi')");
            Sql("INSERT INTO Genres(Id, Name) Values (4, 'Drama')");
            Sql("INSERT INTO Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) Values ('Shrek', 2, '20130101', '20161101', 4)");
            Sql("INSERT INTO Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) Values ('Hangover', 2, '20130101', '20130601', 2)");
            Sql("INSERT INTO Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) Values ('Avatar', 3, '20140425', '20140501', 6)");

        }

        public override void Down()
        {
        }
    }
}
