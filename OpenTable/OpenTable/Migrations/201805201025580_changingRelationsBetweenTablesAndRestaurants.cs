namespace OpenTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingRelationsBetweenTablesAndRestaurants : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tables", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Tables", new[] { "Restaurant_Id" });
            RenameColumn(table: "dbo.Tables", name: "Restaurant_Id", newName: "RestaurantId");
            AlterColumn("dbo.Tables", "RestaurantId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tables", "RestaurantId");
            AddForeignKey("dbo.Tables", "RestaurantId", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tables", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Tables", new[] { "RestaurantId" });
            AlterColumn("dbo.Tables", "RestaurantId", c => c.Int());
            RenameColumn(table: "dbo.Tables", name: "RestaurantId", newName: "Restaurant_Id");
            CreateIndex("dbo.Tables", "Restaurant_Id");
            AddForeignKey("dbo.Tables", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
    }
}
