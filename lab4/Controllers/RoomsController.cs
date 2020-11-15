using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab4.Data;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    public class RoomsController : Controller
    {
        HotelContext _context = new HotelContext();

        public RoomsController(HotelContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rooms()
        {
            return View(_context.Rooms.Take(20).ToList());
        }
    }
}