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
    }
}