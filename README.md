# 👟 ShoeStore - Desktop Application Management System

## 📝 Giới thiệu
Là một ứng dụng quản trị cửa hàng giày được xây dựng trên nền tảng **Windows Forms (C#)**. Dự án tập trung vào việc giải quyết các bài toán quản lý kho hàng, tối ưu quy trình bán hàng và thống kê doanh thu cho các cửa hàng bán lẻ.

Sử dụng **ADO.NET** để tối truy vấn và hiểu sâu về cách thức tương tác với hệ quản trị cơ sở dữ liệu.

---

## 🚀 Tính Năng Cốt Lõi

### 🔹 Quản Lý Nghiệp Vụ
**Quản lý Sản phẩm:** Theo dõi chi tiết thông tin giày (size, màu sắc, thương hiệu, giá bán). [cite: 57, 60]
**Quản lý Nhập hàng:** Lập phiếu nhập, cập nhật số lượng tồn kho theo thời gian thực. [cite: 55]
**Quy trình Bán hàng:** Giao diện lập hóa đơn trực quan, tự động tính tổng tiền và chiết khấu. [cite: 53]

### 🔹 Quản Trị & Thống Kê
**Báo cáo Doanh thu:** Tổng hợp dữ liệu bán hàng theo ngày, tháng, năm thông qua các câu lệnh SQL phức tạp. [cite: 61]
**Quản lý Khách hàng & Nhân viên:** Lưu trữ thông tin, phân quyền truy cập hệ thống. [cite: 57, 60]

---

## 🛠️ Công Nghệ Sử Dụng

| Thành phần | Công nghệ | Mô tả |
| :--- | :--- | :--- |
| **Language** | **C#** | [cite_start]Ngôn ngữ chính xử lý logic nghiệp vụ. [cite: 31, 70] |
| **UI Framework** | **WinForms** | Xây dựng giao diện ứng dụng desktop truyền thống. |
| **Database** | **SQL Server** | [cite_start]Lưu trữ và quản lý dữ liệu quan hệ. [cite: 12, 49] |
| **Data Access** | **ADO.NET** | Tương tác trực tiếp với SQL Server thông qua SqlConnection, SqlCommand. |

---

## 🏗️ Kiến Trúc Hệ Thống (Layered Architecture)

Dự án được tổ chức theo mô hình phân lớp để đảm bảo tính dễ bảo trì và mở rộng:

1. **Presentation Layer (GUI):** Chứa các Windows Form xử lý giao diện và sự kiện từ người dùng.
2. **Business Logic Layer (BLL):** Xử lý các quy tắc nghiệp vụ (tính toán, kiểm tra điều kiện dữ liệu).
3. **Data Access Layer (DAL):** Thực hiện các câu lệnh SQL thuần (CRUD) để giao tiếp với Database.



---

## 💻 Hướng Dẫn Cài Đặt

1. **Clone dự án:**
   ```bash
   git clone [https://github.com/thuong3011/ShoeStore.git](https://github.com/thuong3011/ShoeStore.git)
