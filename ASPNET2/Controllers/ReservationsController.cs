using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ASPNET2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.Services;

namespace MVC.Controllers
{
    public class ReservationsController : Controller
    {
        IReservationService _reservationService;
        IRoomService _roomService;

        public ReservationsController(IReservationService reservationService, IRoomService roomService)
        {
            _reservationService = reservationService;
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult Create(int roomId)
        {
            ViewBag.Room = _roomService.GetById(roomId);
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Date")] Reservation reservation, int roomId, int hour)
        {
            reservation.Date = reservation.Date.AddHours(hour);
            return RedirectToAction("CustomerDetails", new { date = reservation.Date, roomId = roomId });
        }

        [HttpGet]
        public IActionResult CustomerDetails(DateTime date, int roomId)
        {
            Reservation reservation = new Reservation() { Date = date, Room = _roomService.GetById(roomId) };
            return View(reservation);
        }

        [HttpPost]
        public IActionResult CustomerDetails([Bind("CustomersName,CustomersLastName,CustomersEmail,CustomersPhone,CustomersNote")] Reservation reservation, int roomId, DateTime date)
        {
            reservation.Room = _roomService.GetById(roomId);
            reservation.Date = date;
            if(!ModelState.IsValid) return View(reservation);
            int? reservationId = _reservationService.Save(reservation);
            //If save to database wasnt successful
            if (reservationId == null) return View("Error");
            return RedirectToAction("Created", new { reservationId = reservationId });
        }

        [HttpGet]
        public IActionResult Created(int reservationId)
        {
            return View(_reservationService.GetById(reservationId));
        }

        public JsonResult FreeHours(int roomId, int year, int month, int day)
        {
            return new JsonResult(_roomService.GetFreeHours(roomId, year, month, day));
        }
    }
}
