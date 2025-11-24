namespace BarberShop.Models
{
    public class LookupViewModel
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
