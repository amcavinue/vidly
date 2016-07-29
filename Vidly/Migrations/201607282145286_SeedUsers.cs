namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'523260b5-e9d7-43cd-a9a0-3fe446f1756a', N'admin1@vidly.com', 0, N'AL7nCeDk8KvbEUPtZ0GqI6iWD3JDxdbookFG28UlPwjDDsqSVdCovQiOx2hoRwS6OA==', N'ef7c66f1-ced6-48f6-bbb2-d87ba3ed927d', NULL, 0, 0, NULL, 1, 0, N'admin1@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b750fe4e-7ab8-42ae-b042-e263da73aeff', N'guest@vidly.com', 0, N'ABf6my6PibUL36qMUQknqzpoaXefUgneVrBCiCbdn+ujEDI0/MI+KZ13Sv90aQaiSg==', N'd8b1eccc-f17c-4cc0-b325-36c3483fa20f', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2a2758d1-6747-462b-8ff9-bdc045220215', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'523260b5-e9d7-43cd-a9a0-3fe446f1756a', N'2a2758d1-6747-462b-8ff9-bdc045220215')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
