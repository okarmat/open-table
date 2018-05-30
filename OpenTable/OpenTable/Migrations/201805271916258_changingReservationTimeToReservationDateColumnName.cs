namespace OpenTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingReservationTimeToReservationDateColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ReservationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "ReservationTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "ReservationTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "ReservationDate");
        }
    }
}
