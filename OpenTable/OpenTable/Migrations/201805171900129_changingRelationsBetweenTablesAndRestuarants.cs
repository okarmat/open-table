namespace OpenTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingRelationsBetweenTablesAndRestuarants : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Left = c.Double(nullable: false),
                        Top = c.Double(nullable: false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tables", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Tables", new[] { "Restaurant_Id" });
            DropTable("dbo.Tables");
            DropTable("dbo.Restaurants");
        }
    }
}
