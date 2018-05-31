using OpenTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace OpenTable.Extensions
{
    public static class TablesExtensions
    {
        public static string ToJson(this List<Table> tables)
        {
            var tablesJson = "[]";

            if (tables.Any())
            {
                tablesJson = new JavaScriptSerializer()
                    .Serialize(tables
                    .Select(s => new { s.Id, s.Left, s.Top, s.RestaurantId, s.Reserved }));
            }

            return tablesJson;
        }

        public static List<Table> UpdateTablesReservedStatus(this List<Table> tables, List<Reservation> reservations, DateTime reservationStart, DateTime reservationEnd)
        {
            foreach (var table in tables)
            {
                var reservation = reservations
                    .Where(r => r.TableId == table.Id
                    && (r.ReservationStart.Between(reservationStart, reservationEnd) 
                    || r.ReservationEnd.Between(reservationStart, reservationEnd)))
                    .OrderBy(r => r.ReservationEnd)
                    .ToList();
                table.Reserved = reservation.Any();
            }

            return tables;
        }
    }
}