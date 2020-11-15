using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab4.Controllers
{
    public class OrdersController : Controller
    {
        HotelContext _context = new HotelContext();

        public OrdersController(HotelContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            var orders = _context.Orders.Include(x => x.Client).Include(x => x.Employee).Include(x => x.Room).Take(20);
            return View(orders.ToList());
        }
    }
}