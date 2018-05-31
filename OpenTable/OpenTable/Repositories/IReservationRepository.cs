using OpenTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTable.Repositories
{
    public interface IReservationRepository
    {
        void Add(Reservation reservation);
        void Delete(Reservation reservation);
        List<Reservation> GetByEmail(string email);
        List<Reservation> GetByRestaurantId(int restaurantId);
    }
}
