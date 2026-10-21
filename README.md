# Quản lý tàu điện ngầm

Project Windows Forms (.NET Framework 4.8) + SQL Server.

- Mở bằng **Visual Studio** trên Windows
- Chạy database bằng **SSMS** (SQL Server Management Studio)
- Mac / VS Code không chạy được WinForms

Repo: https://github.com/thanhhale288/dotnet-quan-ly-tau

---

## Máy Windows clone về thì làm gì?

### Bước 0 — Cài phần mềm (chỉ lần đầu)

1. **Visual Studio 2019 hoặc 2022**  
   Khi cài, chọn workload **.NET desktop development** (Windows Forms, .NET Framework 4.8).
2. **SQL Server** (Express cũng được) + **SQL Server Management Studio (SSMS)**.
3. **Git** (nếu chưa có): https://git-scm.com

### Bước 1 — Clone project

Mở Command Prompt hoặc PowerShell:

```bat
git clone https://github.com/thanhhale288/dotnet-quan-ly-tau.git
cd dotnet-quan-ly-tau
```

Hoặc trên Visual Studio: **File → Clone Repository** → dán link repo → Clone.

### Bước 2 — Tạo database trong SSMS

1. Mở **SQL Server Management Studio**.
2. Kết nối server (thường là `.` hoặc `.\SQLEXPRESS` hoặc `(localdb)\MSSQLLocalDB`).
3. **File → Open → File** → chọn `Database/QuanLyTau.sql`.
4. Bấm **Execute** (F5).  
   Script tạo database `QuanLyTau`, bảng, view, stored procedure và dữ liệu mẫu.
5. Nếu báo database đang được dùng: đóng các cửa sổ query khác rồi chạy lại.

### Bước 3 — Sửa chuỗi kết nối (nếu cần)

Mở `QuanLyTau/App.config`. Mặc định:

```xml
Data Source=.;Initial Catalog=QuanLyTau;Integrated Security=True
```

Đổi `Data Source` cho khớp server bạn vừa kết nối trong SSMS:

| SQL Server trên máy | Data Source |
|---|---|
| Instance mặc định | `.` |
| SQL Express | `.\SQLEXPRESS` |
| LocalDB | `(localdb)\MSSQLLocalDB` |

### Bước 4 — Chạy app

1. Double-click `QuanLyTau.sln` (mở bằng Visual Studio).
2. Chờ Visual Studio restore / load xong.
3. Bấm **Build → Build Solution**, rồi **Start** (F5).
4. Đăng nhập bằng tài khoản mẫu bên dưới.

Nếu báo lỗi kết nối SQL: kiểm tra lại bước 2 (đã Execute script chưa) và bước 3 (`Data Source` đúng chưa).

---

## Tài khoản mẫu

Mật khẩu của tất cả tài khoản là `123456`.

| Tên đăng nhập | Quyền |
|---|---|
| admin | Quản lý, vào được mọi màn |
| banve | Bán vé, tra cứu, hành khách, chuyến |
| kythuat | Tàu, chi tiết tàu, bảo trì |
| laixe | Xem và cập nhật chuyến |

## Các form

Đăng nhập mở trang chủ. Trang chủ mở đúng module theo quyền. Từ tuyến mở chi tiết ga, từ tàu mở toa và bảo trì, từ lịch trình sinh chuyến, từ chuyến mở bán vé, từ vé mở hành khách.

Giá vé = số ga đi qua × 10.000 đồng. Vé ưu tiên bằng một nửa.
