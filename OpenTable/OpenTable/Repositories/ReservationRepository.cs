using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenTable.Models;

namespace OpenTable.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
        }

        public void Delete(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
        }

        public List<Reservation> GetByEmail(string email)
        {
            return _context.Reservations.Where(r => r.ReservingPersonEmail == email).ToList();
        }
    }
}