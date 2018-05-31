namespace OpenTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReservationStarAndEndFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ReservationStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "ReservationEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "ReservationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "ReservationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "ReservationEnd");
            DropColumn("dbo.Reservations", "ReservationStart");
        }
    }
}
