using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
