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
    }
}