using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenTable.Models;

namespace OpenTable.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _context;

        public RestaurantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetById(int id)
        {
            return _context.Restaurants.Where(r => r.Id == id).First();
        }
    }
}