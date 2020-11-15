using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab4.Data;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    public class ClientsController : Controller
    {
        HotelContext _context = new HotelContext();

        public ClientsController(HotelContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Clients()
        {
            return View(_context.Clients.Take(20).ToList());
        }
    }
}