namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'A3AE79E5-240D-47E3-9694-7362707AAA06', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a4efaf08-2558-4bbd-9644-7a660f38f11e', N'A3AE79E5-240D-47E3-9694-7362707AAA06')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
