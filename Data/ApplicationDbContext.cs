using Microsoft.EntityFrameworkCore;
using BarberShop.Models;

namespace BarberShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Cắt Tóc Cổ Điển", Description = "Cắt tóc phong cách truyền thống với kéo và tông đơ.", Price = 200000, ImageUrl = "/img/cattoccodien.png" },
                new Service { Id = 2, Name = "Cạo Râu & Tạo Kiểu", Description = "Cạo râu sạch sẽ và tạo kiểu râu.", Price = 150000, ImageUrl = "/img/caoraucodien.png" },
                new Service { Id = 3, Name = "Cạo Mặt Khăn Nóng", Description = "Thư giãn với dịch vụ cạo mặt khăn nóng.", Price = 100000, ImageUrl = "/img/caomatkhannong.png" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Sáp Vuốt Tóc Cao Cấp", Description = "Giữ nếp mạnh mẽ, độ bóng thấp.", Price = 350000, Stock = 50, ImageUrl = "/img/Pomade.png" },
                new Product { Id = 2, Name = "Dầu Dưỡng Râu", Description = "Nuôi dưỡng và làm mềm râu.", Price = 250000, Stock = 30, ImageUrl = "/img/Beard Oil.jpg" }
            );
        }
    }
}
