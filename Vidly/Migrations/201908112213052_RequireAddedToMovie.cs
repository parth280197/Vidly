namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireAddedToMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ReleasedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "AddedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "AddedDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "ReleasedDate", c => c.DateTime());
        }
    }
}
