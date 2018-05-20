using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Services;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.Controllers
{
    public class ApiController : Controller
    {
        IRoomService _service;

        public ApiController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet("{year, month, day}")]
        public string Get(int year, int month, int day)
        {
            return JsonConvert.SerializeObject(_service.GetRoomsWithFreeHours(year, month, day), Formatting.Indented);
        }

        [HttpGet("{id, year, month, day}")]
        public string Get(int id, int year, int month, int day)
        {
            return JsonConvert.SerializeObject(_service.GetRoomWithFreeHours(id, year, month, day));
        }
    }
}
