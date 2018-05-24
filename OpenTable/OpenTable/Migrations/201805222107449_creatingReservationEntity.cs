namespace OpenTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatingReservationEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestuarantId = c.Int(nullable: false),
                        ReservingPersonEmail = c.String(),
                        TableId = c.Int(nullable: false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .ForeignKey("dbo.Tables", t => t.TableId, cascadeDelete: true)
                .Index(t => t.TableId)
                .Index(t => t.Restaurant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "TableId", "dbo.Tables");
            DropForeignKey("dbo.Reservations", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Reservations", new[] { "Restaurant_Id" });
            DropIndex("dbo.Reservations", new[] { "TableId" });
            DropTable("dbo.Reservations");
        }
    }
}
