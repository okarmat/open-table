using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenTable.Models;

namespace OpenTable.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly ApplicationDbContext _context;

        public TableRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Table table)
        {
            _context.Tables.Add(table);
        }

        public List<Table> GetAll()
        {
            return _context.Tables.ToList();
        }

        public Table GetByRestaurantId(int restaurantId)
        {
            return _context.Tables.Where(t => t.RestaurantId == restaurantId).First();
        }
    }
}