namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedUpdatedPopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "AignUpFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "AignUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "SignUpFee");
        }
    }
}
