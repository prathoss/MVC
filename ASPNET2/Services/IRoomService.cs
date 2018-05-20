using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public interface IRoomService
    {
        Room GetById(int id);
        DbSet<Room> GetAll();
        int[] GetFreeHours(int id, int year, int month, int day);
        Room GetRoomWithReservations(int id);
        Dictionary<Room, int[]> GetRoomWithFreeHours(int id, DateTime date);
        Dictionary<Room, int[]> GetRoomsWithFreeHours(DateTime date);
    }
}
