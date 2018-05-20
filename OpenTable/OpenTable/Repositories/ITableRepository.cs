using OpenTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTable.Repositories
{
    public interface ITableRepository
    {
        void Add(Table table);
        List<Table> GetAll();
        Table GetById(int id);
        List<Table> GetByRestaurantId(int restaurantId);
        void Update(Table table);
    }
}
