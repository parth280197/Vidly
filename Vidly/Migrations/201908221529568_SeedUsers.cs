namespace Vidly.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class SeedUsers : DbMigration
  {
    public override void Up()
    {
      Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'47f8fc13-4889-408c-97f8-2b93aab5b951', N'admin@vidly.com', 0, N'AAXmjkV22De+HPZd0RNu2Dq5LJO1SqGL4xcv5Dq3xurP8pwKuXlEUX3VjY7rA8wLZQ==', N'9e481510-6284-4e3c-9b8e-1ffac9f6e0dd', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'da868805-a640-4624-b824-da70d71c17c4', N'guest@vidly.com', 0, N'ALPpF4ip7ctBL9nfK5OtDqtA10nl/uL/ejpOTWsfXWRdhn/aoyu1CQHzsJgdgmYdVg==', N'cadd3529-ded2-4aec-97da-eb6182a13e9e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'31d88e25-7ffb-492f-bf1b-a8a0be4a5bb6', N'canManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'47f8fc13-4889-408c-97f8-2b93aab5b951', N'31d88e25-7ffb-492f-bf1b-a8a0be4a5bb6')");
    }

    public override void Down()
    {
    }
  }
}
