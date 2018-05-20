namespace OpenTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setRestaurantNameAsRequiredField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String());
        }
    }
}
