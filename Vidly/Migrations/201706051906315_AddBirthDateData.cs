namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = '19851013' WHERE ID = 1 ");
        }
        
        public override void Down()
        {
        }
    }
}
