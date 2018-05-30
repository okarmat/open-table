namespace OpenTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeReservationModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "ReservingPersonEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "ReservingPersonEmail", c => c.String());
        }
    }
}
