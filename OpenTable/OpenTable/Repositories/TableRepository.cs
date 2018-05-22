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

        public Table GetById(int id)
        {
            return _context.Tables.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<Table> GetByRestaurantId(int restaurantId)
        {
            return _context.Tables.Where(t => t.RestaurantId == restaurantId).ToList();
        }

        public void Update(Table table)
        {
            var tableToUpdate = _context.Tables.First(t => t.Id == table.Id && t.RestaurantId == table.RestaurantId);
            tableToUpdate.Left = table.Left;
            tableToUpdate.Top = table.Top;
            _context.Tables.Add(tableToUpdate);
            _context.Entry(tableToUpdate).State = System.Data.Entity.EntityState.Modified;            
        }

        public void Delete(List<Table> tables)
        {                        
            var tablesToEraseIds = tables.Where(t => t.Erase == true).Select(t => t.Id).ToList();
            var tablesToDelte = _context.Tables.Where(t => tablesToEraseIds.Contains(t.Id)).ToList();
           _context.Tables.RemoveRange(tablesToDelte);
        }
    }
}