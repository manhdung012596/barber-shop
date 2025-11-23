using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public DateTime AppointmentTime { get; set; }

        public int ServiceId { get; set; }
        public Service? Service { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Completed, Cancelled
    }
}
