using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(0, 10000000)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
