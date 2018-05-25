using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenTable.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string ReservingPersonEmail { get; set; }
        public DateTime ReservationTime { get; set; }
        public int TableId { get; set; }

        public Table Table { get; set; }
    }
}