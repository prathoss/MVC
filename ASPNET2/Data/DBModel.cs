using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC.Data
{
    public class DBModel : DbContext
    {
        public DBModel(DbContextOptions<DBModel> options)
            : base(options)
        { }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
