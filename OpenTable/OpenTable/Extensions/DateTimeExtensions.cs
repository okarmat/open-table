using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenTable.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool Between(this DateTime dateTime, DateTime dateFrom, DateTime dateTo)
        {
            if (dateTime > dateFrom && dateTime < dateTo)
                return true;
            return false;
        }
    }
}