using OpenTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenTable.ViewModels
{
    public class TableManagementViewModel
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public int TablesMaxId { get; set; }
        public string Tables { get; set; }        
    }
}