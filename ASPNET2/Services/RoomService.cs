﻿using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class RoomService : IRoomService
    {
        DBModel _context;

        public RoomService(DBModel context)
        {
            _context = context;
        }

        public Room GetById(int id)
        {
            return _context.Rooms.Find(id);
        }

        public DbSet<Room> GetAll()
        {
            return _context.Rooms;
        }

        public int[] GetFreeHours(int id, int year, int month, int day)
        {
            Room room = GetRoomWithReservations(id);
            List<int> freeHours = new List<int>();
            for (int i = room.OpeningAt; i <= room.ClosingAt - 1; i++) freeHours.Add(i);
            foreach (Reservation reservation in room.Reservations.Where(r => r.Date.Date == new DateTime(year, month, day)))
            {
                if (freeHours.Contains(reservation.Date.Hour)) freeHours.Remove(reservation.Date.Hour);
            }
            return freeHours.ToArray();
        }

        public Room GetRoomWithReservations(int id)
        {
            Room room = GetById(id);
            room.Reservations = _context.Reservations.Where(r => r.Room == room).ToList();
            return room;
        }
    }
}
