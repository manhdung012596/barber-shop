using BarberShop.Data;
using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? serviceId)
        {
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", serviceId);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,PhoneNumber,AppointmentTime,ServiceId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Confirmation));
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", booking.ServiceId);
            return View("Index", booking);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
