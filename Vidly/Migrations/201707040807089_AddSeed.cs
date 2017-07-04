namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeed : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'814cb180-2f20-4c73-a894-c8728d32194a', N'bonele.lusithi@dariel.co.za', 0, N'AAKqI1aedWAFH/NtkH6UlEY0jSrhmdHf4s7bu4i1f79EUv1UKmQhynvwu8vGk5ooHQ==', N'9dd16f5e-2d92-46e9-a8c6-e920cd7abc80', NULL, 0, 0, NULL, 1, 0, N'bonele.lusithi@dariel.co.za')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8b3999f5-899e-44a2-9a7a-a38f2c813995', N'guest@vidly.com', 0, N'AAj01gHESbl9PqxsgRyFx/jaQ/1DLBoTZlMeeg1v6n8a0Icqv5Di+WFJoLeVBZl7Zw==', N'ccdea82d-a039-4d4d-ac9e-93a445103f2e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a4efaf08-2558-4bbd-9644-7a660f38f11e', N'administrator@vidly.com', 0, N'AGXHNjHwOGfqnZr+Ab/IdRqP/dT8fIrx/Kmn5h/myWlfV/aaGUIXi0XMdMz4Al80fg==', N'24a61009-1f76-4248-b1a9-6c6888761c22', NULL, 0, 0, NULL, 1, 0, N'administrator@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ccf8b2d5-2797-4de8-8177-d6bb65fd8fd9', N'admin@vidly.com', 0, N'ANPine8U/c4CeWpqHbmjsemNJC/e9N4UrmJdb59H1x8WCEWtn9YwLE7ZWqSQMSmvTA==', N'ae9ade2d-83d5-4039-b7fb-a520c188c60c', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0b479677-68a0-4210-932e-99da3b59b7d6', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a4efaf08-2558-4bbd-9644-7a660f38f11e', N'0b479677-68a0-4210-932e-99da3b59b7d6')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
