using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Services;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class RoomsController : Controller
    {
        IRoomService _service;

        public RoomsController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet("{date}")]
        public string Get(DateTime date)
        {
            return JsonConvert.SerializeObject(_service.GetRoomsWithFreeHours(date), Formatting.Indented);
        }

        [HttpGet("{id, date}")]
        public string Get(int id, DateTime date)
        {
            return JsonConvert.SerializeObject(_service.GetRoomWithFreeHours(id, date));
        }
    }
}