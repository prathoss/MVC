using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return _context.Reservations.Include(r => r.Room).Where(r => r.Id == id).First();
        }
        /// <summary>
        /// Saves reservation to database
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns>reservations Id if was possible to save otherwise null</returns>
        public int? Save(Reservation reservation)
        {
            if (_context.Reservations.Where(r => r.Date == reservation.Date && r.Room.Id == reservation.Room.Id).Any()) return null;  
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return reservation.Id;
        }
    }
}
