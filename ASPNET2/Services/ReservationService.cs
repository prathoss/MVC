using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Data;
using MVC.Models;

namespace MVC.Services
{
    public class ReservationService : IReservationService
    {
        DBModel _context;

        public ReservationService(DBModel context)
        {
            _context = context;
        }

        public Reservation GetById(int id)
        {
            return _context.Reservations.Find(id);
        }
    }
}
