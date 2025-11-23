# Barber Shop Management System

Dự án web quản lý tiệm cắt tóc và bán sản phẩm chăm sóc tóc, được xây dựng bằng ASP.NET Core MVC.

## 🚀 Tính Năng Chính

Hệ thống bao gồm 2 phân hệ chính:
1. **Đặt Lịch (Booking)**: Cho phép khách hàng đặt lịch hẹn cắt tóc.
2. **Cửa Hàng (E-commerce)**: Cho phép khách hàng mua các sản phẩm chăm sóc tóc.

## 📋 Các Luồng Hoạt Động (User Flows)

### 1. Luồng Đặt Lịch (Booking Flow)
Khách hàng có thể đặt lịch hẹn dịch vụ thông qua các bước sau:
- **Bước 1**: Truy cập trang chủ hoặc trang Dịch vụ (`/Service`).
- **Bước 2**: Chọn dịch vụ mong muốn và nhấn "Đặt lịch" (Book Now).
- **Bước 3**: Điền thông tin vào form đặt lịch (`/Booking`):
  - Tên khách hàng
  - Số điện thoại
  - Thời gian hẹn
  - Dịch vụ (đã chọn hoặc chọn lại)
- **Bước 4**: Xác nhận đặt lịch. Hệ thống sẽ lưu thông tin và chuyển đến trang xác nhận (`/Booking/Confirmation`).

### 2. Luồng Mua Sắm (Shopping Flow)
Khách hàng có thể mua sản phẩm trực tuyến:
- **Xem Sản Phẩm**: Truy cập trang Sản phẩm (`/Product`) để xem danh sách các sản phẩm. Hỗ trợ phân trang.
- **Thêm vào Giỏ**: Nhấn "Thêm vào giỏ hàng" ở sản phẩm mong muốn. Sản phẩm sẽ được thêm vào giỏ hàng (`/Cart`).
- **Quản Lý Giỏ Hàng**: Tại trang Giỏ hàng (`/Cart`), khách hàng có thể xem lại các món đã chọn, điều chỉnh số lượng hoặc xóa sản phẩm.
- **Thanh Toán (Checkout)**:
  - Nhập thông tin giao hàng: Tên, Địa chỉ, Số điện thoại.
  - Nhấn "Đặt hàng" (Checkout).
  - Hệ thống tạo đơn hàng (`Order`), xóa giỏ hàng và hiển thị hóa đơn xác nhận.

### 3. Tra Cứu Đơn Hàng (Order Tracking)
Khách hàng có thể kiểm tra lịch sử mua hàng:
- Truy cập trang Tra cứu đơn hàng (`/Order`).
- Nhập số điện thoại đã dùng để đặt hàng.
- Hệ thống hiển thị danh sách các đơn hàng gắn với số điện thoại đó.
- Xem chi tiết từng đơn hàng (`/Order/Details/{id}`) để thấy danh sách sản phẩm đã mua.

## 🛠 Công Nghệ Sử Dụng

- **Framework**: ASP.NET Core MVC
- **Database**: SQLite (`barbershop.db`)
- **ORM**: Entity Framework Core
- **Session**: Sử dụng để lưu trữ Giỏ hàng tạm thời.

## ⚙️ Cấu Trúc Dữ Liệu (Models)

- **Booking**: Lưu thông tin đặt lịch (Tên, SĐT, Thời gian, Dịch vụ).
- **Product**: Sản phẩm bán lẻ (Tên, Giá, Tồn kho, Ảnh).
- **Service**: Dịch vụ cắt tóc (Tên, Giá, Mô tả).
- **Order**: Đơn hàng mua sắm (Khách hàng, Địa chỉ, Tổng tiền).
- **OrderItem**: Chi tiết sản phẩm trong đơn hàng.

## ▶️ Cách Chạy Dự Án

1. Đảm bảo đã cài đặt .NET SDK.
2. Mở terminal tại thư mục gốc của dự án.
3. Chạy lệnh:
   ```bash
   dotnet run
   ```
4. Truy cập trình duyệt tại địa chỉ: `http://localhost:5000` hoặc `https://localhost:5001` (tùy cấu hình).

## 📝 Ghi Chú
- Cơ sở dữ liệu SQL Server sẽ tự động được tạo nếu chưa tồn tại (dựa trên cấu hình DbContext).
- Hình ảnh sản phẩm và dịch vụ được lưu trong thư mục `wwwroot`.