using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(0, 10000000)]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
