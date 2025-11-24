using BarberShop.Data;
using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BarberShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index(string phoneNumber)
        {
            var viewModel = new LookupViewModel();

            if (User.Identity.IsAuthenticated && string.IsNullOrEmpty(phoneNumber))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                viewModel.Orders = await _context.Orders
                    .Where(o => o.UserId == userId)
                    .OrderByDescending(o => o.OrderDate)
                    .ToListAsync();
                
                viewModel.Bookings = await _context.Bookings
                    .Where(b => b.UserId == userId)
                    .Include(b => b.Service)
                    .OrderByDescending(b => b.AppointmentTime)
                    .ToListAsync();

                return View(viewModel);
            }

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return View(viewModel);
            }

            viewModel.PhoneNumber = phoneNumber;

            // Normalize phone number if needed, for now exact match
            viewModel.Orders = await _context.Orders
                .Where(o => o.PhoneNumber.Contains(phoneNumber))
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            viewModel.Bookings = await _context.Bookings
                .Where(b => b.PhoneNumber.Contains(phoneNumber))
                .Include(b => b.Service)
                .OrderByDescending(b => b.AppointmentTime)
                .ToListAsync();

            ViewBag.PhoneNumber = phoneNumber;
            return View(viewModel);
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
