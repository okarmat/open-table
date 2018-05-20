using OpenTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenTable.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ITableRepository TableRepository { get; set; }
        public IRestaurantRepository RestaurantRepository { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            TableRepository = new TableRepository(_context);
            RestaurantRepository = new RestaurantRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}