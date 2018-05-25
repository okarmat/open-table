namespace OpenTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingReservationCyclesOrMultopleCascadePath : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Reservations", new[] { "Restaurant_Id" });
            DropColumn("dbo.Reservations", "RestuarantId");
            DropColumn("dbo.Reservations", "Restaurant_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Restaurant_Id", c => c.Int());
            AddColumn("dbo.Reservations", "RestuarantId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "Restaurant_Id");
            AddForeignKey("dbo.Reservations", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
    }
}
