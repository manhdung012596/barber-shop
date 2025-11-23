using BarberShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 6;
            var products = _context.Products.AsQueryable();
            
            // Pagination Logic
            int pageIndex = pageNumber ?? 1;
            var count = await products.CountAsync();
            var items = await products.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            ViewBag.PageIndex = pageIndex;
            ViewBag.TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            return View(items);
        }
    }
}
