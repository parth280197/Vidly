namespace Vidly.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class NameAddToMembershipType : DbMigration
  {
    public override void Up()
    {
      AddColumn("dbo.MembershipTypes", "Name", c => c.String());
      Sql("UPDATE MEMBERSHIPTYPES SET NAME='Pay as You Go' WHERE Id=1");
      Sql("UPDATE MEMBERSHIPTYPES SET NAME='Monthly' WHERE Id=2");
      Sql("UPDATE MEMBERSHIPTYPES SET NAME='Three month' WHERE Id=3");
      Sql("UPDATE MEMBERSHIPTYPES SET NAME='Yearly' WHERE Id=4");
    }

    public override void Down()
    {
      DropColumn("dbo.MembershipTypes", "Name");
    }
  }
}
