namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyVirtualToCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "MemberShipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MemberShipTypeId", c => c.Byte(nullable: false));
        }
    }
}
