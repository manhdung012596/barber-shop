using BarberShop.Data;
using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BarberShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string CartSessionKey = "Cart";

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(c => c.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Add(new OrderItem
                {
                    ProductId = productId,
                    Product = product,
                    Quantity = 1,
                    Price = product.Price
                });
            }

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(c => c.ProductId == productId);

            if (cartItem != null)
            {
                cart.Remove(cartItem);
                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(string customerName, string address, string phoneNumber)
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                return RedirectToAction("Index");
            }

            var order = new Order
            {
                CustomerName = customerName,
                Address = address,
                PhoneNumber = phoneNumber,
                OrderDate = DateTime.Now,
                TotalAmount = cart.Sum(i => i.Price * i.Quantity),
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in cart)
            {
                // Re-fetch product to ensure price is correct and to attach to context if needed, 
                // but here we just create new OrderItems.
                // Note: In a real app, we should check stock again.
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Clear cart
            HttpContext.Session.Remove(CartSessionKey);

            return View("OrderConfirmation", order);
        }

        private List<OrderItem> GetCart()
        {
            var sessionCart = HttpContext.Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(sessionCart))
            {
                return new List<OrderItem>();
            }
            return JsonSerializer.Deserialize<List<OrderItem>>(sessionCart) ?? new List<OrderItem>();
        }

        private void SaveCart(List<OrderItem> cart)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };
            HttpContext.Session.SetString(CartSessionKey, JsonSerializer.Serialize(cart, options));
        }
    }
}
