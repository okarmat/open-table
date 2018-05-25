namespace OpenTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReservationTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ReservationTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "ReservationTime");
        }
    }
}
