/*
    QuanLyTau.sql
    Database quan ly tau dien ngam cho bai .NET Windows Forms.
    Chay toan bo script nay trong SSMS (file -> Open -> Execute).

    Script xoa database QuanLyTau neu da ton tai, roi tao lai tu dau.
    Dong cac cua so query khac dang dung QuanLyTau truoc khi chay.

    Tai khoan dang nhap (mat khau goc, app bam SHA-256 roi moi so sanh):
        admin    / 123456    Quan ly
        banve    / 123456    Ban ve
        kythuat  / 123456    Ky thuat
        laixe    / 123456    Lai tau
        laixe2   / 123456    Lai tau
*/
USE master;
GO

IF DB_ID(N'QuanLyTau') IS NOT NULL
BEGIN
    ALTER DATABASE QuanLyTau SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyTau;
END
GO

CREATE DATABASE QuanLyTau;
GO

USE QuanLyTau;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/* ===================== BANG ===================== */

CREATE TABLE NhanVien
(
    MaNV        INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    HoTen       NVARCHAR(100) NOT NULL,
    ChucVu      NVARCHAR(20)  NOT NULL,
    TenDangNhap VARCHAR(50)   NOT NULL,
    MatKhau     VARCHAR(64)   NOT NULL,
    DienThoai   VARCHAR(20)   NULL,
    TrangThai   NVARCHAR(20)  NOT NULL CONSTRAINT DF_NhanVien_TrangThai DEFAULT (N'DangLam'),
    CONSTRAINT UQ_NhanVien_TenDangNhap UNIQUE (TenDangNhap),
    CONSTRAINT CK_NhanVien_ChucVu CHECK (ChucVu IN (N'QuanLy', N'BanVe', N'KyThuat', N'LaiTau')),
    CONSTRAINT CK_NhanVien_TrangThai CHECK (TrangThai IN (N'DangLam', N'NghiViec'))
);
GO

CREATE TABLE Ga
(
    MaGa      INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    TenGa     NVARCHAR(100) NOT NULL,
    DiaChi    NVARCHAR(200) NULL,
    KhuVuc    NVARCHAR(50)  NULL,
    TrangThai NVARCHAR(20)  NOT NULL CONSTRAINT DF_Ga_TrangThai DEFAULT (N'HoatDong'),
    CONSTRAINT CK_Ga_TrangThai CHECK (TrangThai IN (N'HoatDong', N'Ngung'))
);
GO

CREATE TABLE Tuyen
(
    MaTuyen   INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    TenTuyen  NVARCHAR(100) NOT NULL,
    MaGaDau   INT NULL,
    MaGaCuoi  INT NULL,
    TrangThai NVARCHAR(20) NOT NULL CONSTRAINT DF_Tuyen_TrangThai DEFAULT (N'HoatDong'),
    CONSTRAINT FK_Tuyen_GaDau FOREIGN KEY (MaGaDau) REFERENCES Ga (MaGa),
    CONSTRAINT FK_Tuyen_GaCuoi FOREIGN KEY (MaGaCuoi) REFERENCES Ga (MaGa),
    CONSTRAINT CK_Tuyen_TrangThai CHECK (TrangThai IN (N'HoatDong', N'Ngung'))
);
GO

CREATE TABLE Tuyen_Ga
(
    MaTuyen  INT NOT NULL,
    MaGa     INT NOT NULL,
    ThuTu    INT NOT NULL,
    PhutDung INT NOT NULL CONSTRAINT DF_TuyenGa_PhutDung DEFAULT (1),
    CONSTRAINT PK_Tuyen_Ga PRIMARY KEY (MaTuyen, MaGa),
    CONSTRAINT UQ_Tuyen_Ga_ThuTu UNIQUE (MaTuyen, ThuTu),
    CONSTRAINT FK_TuyenGa_Tuyen FOREIGN KEY (MaTuyen) REFERENCES Tuyen (MaTuyen),
    CONSTRAINT FK_TuyenGa_Ga FOREIGN KEY (MaGa) REFERENCES Ga (MaGa),
    CONSTRAINT CK_TuyenGa_ThuTu CHECK (ThuTu > 0),
    CONSTRAINT CK_TuyenGa_PhutDung CHECK (PhutDung >= 0)
);
GO

CREATE TABLE Tau
(
    MaTau     INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    TenTau    NVARCHAR(50) NOT NULL,
    LoaiTau   NVARCHAR(20) NOT NULL CONSTRAINT DF_Tau_Loai DEFAULT (N'Metro'),
    SucChua   INT          NOT NULL,
    MaTuyen   INT          NULL,
    TrangThai NVARCHAR(20) NOT NULL CONSTRAINT DF_Tau_TrangThai DEFAULT (N'SanSang'),
    CONSTRAINT UQ_Tau_Ten UNIQUE (TenTau),
    CONSTRAINT FK_Tau_Tuyen FOREIGN KEY (MaTuyen) REFERENCES Tuyen (MaTuyen),
    CONSTRAINT CK_Tau_SucChua CHECK (SucChua > 0),
    CONSTRAINT CK_Tau_Loai CHECK (LoaiTau IN (N'Metro', N'TauHoa')),
    CONSTRAINT CK_Tau_TrangThai CHECK (TrangThai IN (N'SanSang', N'DangChay', N'BaoTri', N'Hong'))
);
GO

CREATE TABLE ToaTau
(
    MaToa    INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    MaTau    INT          NOT NULL,
    SoThuTu  INT          NOT NULL,
    LoaiToa  NVARCHAR(30) NOT NULL,
    SucChua  INT          NOT NULL,
    CONSTRAINT UQ_ToaTau_ThuTu UNIQUE (MaTau, SoThuTu),
    CONSTRAINT FK_ToaTau_Tau FOREIGN KEY (MaTau) REFERENCES Tau (MaTau),
    CONSTRAINT CK_ToaTau_ThuTu CHECK (SoThuTu > 0),
    CONSTRAINT CK_ToaTau_SucChua CHECK (SucChua > 0)
);
GO

CREATE TABLE LichTrinh
(
    MaLich       INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    MaTuyen      INT          NOT NULL,
    MaTau        INT          NOT NULL,
    GioDi        TIME         NOT NULL,
    GioDen       TIME         NOT NULL,
    ThuTrongTuan VARCHAR(40)  NOT NULL,
    TrangThai    NVARCHAR(20) NOT NULL CONSTRAINT DF_Lich_TrangThai DEFAULT (N'HoatDong'),
    CONSTRAINT FK_Lich_Tuyen FOREIGN KEY (MaTuyen) REFERENCES Tuyen (MaTuyen),
    CONSTRAINT FK_Lich_Tau FOREIGN KEY (MaTau) REFERENCES Tau (MaTau),
    CONSTRAINT CK_Lich_Gio CHECK (GioDen > GioDi),
    CONSTRAINT CK_Lich_TrangThai CHECK (TrangThai IN (N'HoatDong', N'Ngung'))
);
GO

CREATE TABLE ChuyenTau
(
    MaChuyen  INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    MaLich    INT          NOT NULL,
    NgayChay  DATE         NOT NULL,
    MaLaiTau  INT          NULL,
    TrangThai NVARCHAR(20) NOT NULL CONSTRAINT DF_Chuyen_TrangThai DEFAULT (N'ChoChay'),
    CONSTRAINT UQ_Chuyen_LichNgay UNIQUE (MaLich, NgayChay),
    CONSTRAINT FK_Chuyen_Lich FOREIGN KEY (MaLich) REFERENCES LichTrinh (MaLich),
    CONSTRAINT FK_Chuyen_LaiTau FOREIGN KEY (MaLaiTau) REFERENCES NhanVien (MaNV),
    CONSTRAINT CK_Chuyen_TrangThai CHECK (TrangThai IN (N'ChoChay', N'DangChay', N'HoanThanh', N'Huy'))
);
GO

CREATE TABLE HanhKhach
(
    MaHK      INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    HoTen     NVARCHAR(100) NOT NULL,
    CCCD      VARCHAR(20)   NOT NULL,
    DienThoai VARCHAR(20)   NULL,
    CONSTRAINT UQ_HanhKhach_CCCD UNIQUE (CCCD)
);
GO

CREATE TABLE Ve
(
    MaVe      INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    MaChuyen  INT            NOT NULL,
    MaHK      INT            NOT NULL,
    MaGaDi    INT            NOT NULL,
    MaGaDen   INT            NOT NULL,
    LoaiVe    NVARCHAR(20)   NOT NULL CONSTRAINT DF_Ve_Loai DEFAULT (N'Thuong'),
    Gia       DECIMAL(18, 0) NOT NULL,
    NgayMua   DATETIME       NOT NULL CONSTRAINT DF_Ve_NgayMua DEFAULT (GETDATE()),
    MaNVBan   INT            NULL,
    TrangThai NVARCHAR(20)   NOT NULL CONSTRAINT DF_Ve_TrangThai DEFAULT (N'DaBan'),
    CONSTRAINT FK_Ve_Chuyen FOREIGN KEY (MaChuyen) REFERENCES ChuyenTau (MaChuyen),
    CONSTRAINT FK_Ve_HanhKhach FOREIGN KEY (MaHK) REFERENCES HanhKhach (MaHK),
    CONSTRAINT FK_Ve_GaDi FOREIGN KEY (MaGaDi) REFERENCES Ga (MaGa),
    CONSTRAINT FK_Ve_GaDen FOREIGN KEY (MaGaDen) REFERENCES Ga (MaGa),
    CONSTRAINT FK_Ve_NhanVien FOREIGN KEY (MaNVBan) REFERENCES NhanVien (MaNV),
    CONSTRAINT CK_Ve_Gia CHECK (Gia >= 0),
    CONSTRAINT CK_Ve_Loai CHECK (LoaiVe IN (N'Thuong', N'UuTien')),
    CONSTRAINT CK_Ve_TrangThai CHECK (TrangThai IN (N'DaBan', N'DaSuDung', N'Huy')),
    CONSTRAINT CK_Ve_Ga CHECK (MaGaDi <> MaGaDen)
);
GO

CREATE TABLE BaoTri
(
    MaBT        INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    MaTau       INT            NOT NULL,
    NgayBatDau  DATE           NOT NULL,
    NgayKetThuc DATE           NULL,
    NoiDung     NVARCHAR(300)  NOT NULL,
    ChiPhi      DECIMAL(18, 0) NOT NULL CONSTRAINT DF_BaoTri_ChiPhi DEFAULT (0),
    MaNV        INT            NULL,
    TrangThai   NVARCHAR(20)   NOT NULL CONSTRAINT DF_BaoTri_TrangThai DEFAULT (N'DangLam'),
    CONSTRAINT FK_BaoTri_Tau FOREIGN KEY (MaTau) REFERENCES Tau (MaTau),
    CONSTRAINT FK_BaoTri_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien (MaNV),
    CONSTRAINT CK_BaoTri_ChiPhi CHECK (ChiPhi >= 0),
    CONSTRAINT CK_BaoTri_Ngay CHECK (NgayKetThuc IS NULL OR NgayKetThuc >= NgayBatDau),
    CONSTRAINT CK_BaoTri_TrangThai CHECK (TrangThai IN (N'DangLam', N'HoanThanh'))
);
GO

/* ===================== HAM ===================== */

GO
CREATE FUNCTION dbo.fn_Thu (@Ngay DATE)
RETURNS VARCHAR(3)
AS
BEGIN
    /* 1900-01-01 la thu Hai. Khong phu thuoc DATEFIRST. */
    DECLARE @n INT = DATEDIFF(DAY, CONVERT(DATE, '19000101'), @Ngay) % 7;
    RETURN CASE @n
        WHEN 0 THEN 'T2'
        WHEN 1 THEN 'T3'
        WHEN 2 THEN 'T4'
        WHEN 3 THEN 'T5'
        WHEN 4 THEN 'T6'
        WHEN 5 THEN 'T7'
        ELSE 'CN'
    END;
END
GO

CREATE FUNCTION dbo.fn_TenTrangThai (@Ma NVARCHAR(20))
RETURNS NVARCHAR(50)
AS
BEGIN
    RETURN CASE @Ma
        WHEN N'HoatDong' THEN N'Hoạt động'
        WHEN N'Ngung' THEN N'Ngừng'
        WHEN N'DangLam' THEN N'Đang làm'
        WHEN N'NghiViec' THEN N'Nghỉ việc'
        WHEN N'SanSang' THEN N'Sẵn sàng'
        WHEN N'DangChay' THEN N'Đang chạy'
        WHEN N'BaoTri' THEN N'Bảo trì'
        WHEN N'Hong' THEN N'Hỏng'
        WHEN N'ChoChay' THEN N'Chờ chạy'
        WHEN N'HoanThanh' THEN N'Hoàn thành'
        WHEN N'Huy' THEN N'Hủy'
        WHEN N'DaBan' THEN N'Đã bán'
        WHEN N'DaSuDung' THEN N'Đã sử dụng'
        WHEN N'Thuong' THEN N'Thường'
        WHEN N'UuTien' THEN N'Ưu tiên'
        WHEN N'QuanLy' THEN N'Quản lý'
        WHEN N'BanVe' THEN N'Bán vé'
        WHEN N'KyThuat' THEN N'Kỹ thuật'
        WHEN N'LaiTau' THEN N'Lái tàu'
        WHEN N'Metro' THEN N'Metro'
        WHEN N'TauHoa' THEN N'Tàu hỏa'
        ELSE @Ma
    END;
END
GO

CREATE FUNCTION dbo.fn_TinhGia
(
    @MaChuyen INT,
    @MaGaDi INT,
    @MaGaDen INT,
    @LoaiVe NVARCHAR(20)
)
RETURNS DECIMAL(18, 0)
AS
BEGIN
    DECLARE @MaTuyen INT, @ThuTuDi INT, @ThuTuDen INT, @Gia DECIMAL(18, 0);

    SELECT @MaTuyen = l.MaTuyen
    FROM ChuyenTau AS c
    INNER JOIN LichTrinh AS l ON c.MaLich = l.MaLich
    WHERE c.MaChuyen = @MaChuyen;

    SELECT @ThuTuDi = ThuTu FROM Tuyen_Ga WHERE MaTuyen = @MaTuyen AND MaGa = @MaGaDi;
    SELECT @ThuTuDen = ThuTu FROM Tuyen_Ga WHERE MaTuyen = @MaTuyen AND MaGa = @MaGaDen;

    IF @ThuTuDi IS NULL OR @ThuTuDen IS NULL OR @ThuTuDi >= @ThuTuDen
        RETURN NULL;

    SET @Gia = (@ThuTuDen - @ThuTuDi) * 10000;
    IF @LoaiVe = N'UuTien'
        SET @Gia = @Gia / 2;

    RETURN @Gia;
END
GO

/* ===================== VIEW ===================== */

CREATE VIEW vw_ChuyenTauChiTiet
AS
SELECT
    c.MaChuyen,
    c.NgayChay,
    c.TrangThai,
    c.MaLaiTau,
    l.MaLich,
    l.GioDi,
    l.GioDen,
    l.MaTuyen,
    t.TenTuyen,
    tau.MaTau,
    tau.TenTau,
    tau.SucChua,
    nv.HoTen AS LaiTau,
    ve.SoVe,
    tau.SucChua - ve.SoVe AS SoChoTrong
FROM ChuyenTau AS c
INNER JOIN LichTrinh AS l ON c.MaLich = l.MaLich
INNER JOIN Tuyen AS t ON l.MaTuyen = t.MaTuyen
INNER JOIN Tau AS tau ON l.MaTau = tau.MaTau
LEFT JOIN NhanVien AS nv ON c.MaLaiTau = nv.MaNV
CROSS APPLY
(
    SELECT COUNT(*) AS SoVe
    FROM Ve AS v
    WHERE v.MaChuyen = c.MaChuyen AND v.TrangThai <> N'Huy'
) AS ve;
GO

CREATE VIEW vw_VeChiTiet
AS
SELECT
    v.MaVe,
    v.MaChuyen,
    hk.MaHK,
    hk.HoTen,
    hk.CCCD,
    hk.DienThoai,
    v.MaGaDi,
    gd.TenGa AS GaDi,
    v.MaGaDen,
    gn.TenGa AS GaDen,
    v.LoaiVe,
    dbo.fn_TenTrangThai(v.LoaiVe) AS TenLoaiVe,
    v.Gia,
    v.NgayMua,
    v.TrangThai,
    dbo.fn_TenTrangThai(v.TrangThai) AS TenTrangThai,
    nv.HoTen AS NguoiBan,
    t.TenTuyen,
    c.NgayChay
FROM Ve AS v
INNER JOIN HanhKhach AS hk ON v.MaHK = hk.MaHK
INNER JOIN Ga AS gd ON v.MaGaDi = gd.MaGa
INNER JOIN Ga AS gn ON v.MaGaDen = gn.MaGa
INNER JOIN ChuyenTau AS c ON v.MaChuyen = c.MaChuyen
INNER JOIN LichTrinh AS l ON c.MaLich = l.MaLich
INNER JOIN Tuyen AS t ON l.MaTuyen = t.MaTuyen
LEFT JOIN NhanVien AS nv ON v.MaNVBan = nv.MaNV;
GO

CREATE VIEW vw_DoanhThuTheoNgay
AS
SELECT
    CAST(v.NgayMua AS DATE) AS Ngay,
    COUNT(*) AS SoVe,
    SUM(v.Gia) AS DoanhThu
FROM Ve AS v
WHERE v.TrangThai <> N'Huy'
GROUP BY CAST(v.NgayMua AS DATE);
GO

/* ===================== DU LIEU MAU ===================== */
/* Mat khau 123456 -> SHA-256 hex (UTF-8), trung voi BamMatKhau trong C#. */

SET IDENTITY_INSERT NhanVien ON;
INSERT INTO NhanVien (MaNV, HoTen, ChucVu, TenDangNhap, MatKhau, DienThoai, TrangThai) VALUES
(1, N'Nguyễn Minh Quân', N'QuanLy',  'admin',   '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '0901000001', N'DangLam'),
(2, N'Trần Thị Vé',     N'BanVe',   'banve',   '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '0901000002', N'DangLam'),
(3, N'Lê Văn Kỹ',       N'KyThuat', 'kythuat', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '0901000003', N'DangLam'),
(4, N'Phạm Đức Tài',    N'LaiTau',  'laixe',   '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '0901000004', N'DangLam'),
(5, N'Võ Thị Mai',      N'LaiTau',  'laixe2',  '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '0901000005', N'DangLam');
SET IDENTITY_INSERT NhanVien OFF;
GO

SET IDENTITY_INSERT Ga ON;
INSERT INTO Ga (MaGa, TenGa, DiaChi, KhuVuc, TrangThai) VALUES
(1, N'Ga Trung Tâm',        N'1 Lê Lợi',        N'Trung tâm', N'HoatDong'),
(2, N'Ga Chợ Đêm',          N'20 Nguyễn Huệ',   N'Trung tâm', N'HoatDong'),
(3, N'Ga Đại Học',          N'15 Lý Tự Trọng',  N'Tây',       N'HoatDong'),
(4, N'Ga Công Viên',        N'8 Pasteur',       N'Tây',       N'HoatDong'),
(5, N'Ga Sân Bay',          N'Đường sân bay',   N'Bắc',       N'HoatDong'),
(6, N'Ga Bến Sông',         N'3 Bạch Đằng',     N'Đông',      N'HoatDong'),
(7, N'Ga Khu Công Nghiệp',  N'Quốc lộ 1',       N'Nam',       N'HoatDong'),
(8, N'Ga Bến Xe',           N'50 Xa lộ',        N'Nam',       N'HoatDong'),
(9, N'Ga Cảng',             N'Đường cảng',      N'Đông',      N'HoatDong');
SET IDENTITY_INSERT Ga OFF;
GO

SET IDENTITY_INSERT Tuyen ON;
INSERT INTO Tuyen (MaTuyen, TenTuyen, MaGaDau, MaGaCuoi, TrangThai) VALUES
(1, N'Tuyến Xanh', 1, 5, N'HoatDong'),
(2, N'Tuyến Đỏ',   6, 8, N'HoatDong'),
(3, N'Tuyến Vàng', 5, 6, N'HoatDong');
SET IDENTITY_INSERT Tuyen OFF;
GO

INSERT INTO Tuyen_Ga (MaTuyen, MaGa, ThuTu, PhutDung) VALUES
(1, 1, 1, 1), (1, 2, 2, 1), (1, 3, 3, 1), (1, 4, 4, 1), (1, 5, 5, 1),
(2, 6, 1, 1), (2, 2, 2, 1), (2, 7, 3, 1), (2, 8, 4, 1),
(3, 5, 1, 1), (3, 7, 2, 1), (3, 9, 3, 1), (3, 6, 4, 1);
GO

SET IDENTITY_INSERT Tau ON;
INSERT INTO Tau (MaTau, TenTau, LoaiTau, SucChua, MaTuyen, TrangThai) VALUES
(1, N'Tàu Xanh 01', N'Metro', 240, 1, N'SanSang'),
(2, N'Tàu Xanh 02', N'Metro', 240, 1, N'SanSang'),
(3, N'Tàu Đỏ 01',   N'Metro', 180, 2, N'SanSang'),
(4, N'Tàu Đỏ 02',   N'Metro', 180, 2, N'BaoTri'),
(5, N'Tàu Vàng 01', N'Metro', 200, 3, N'SanSang'),
(6, N'Tàu Vàng 02', N'Metro', 200, 3, N'Hong');
SET IDENTITY_INSERT Tau OFF;
GO

INSERT INTO ToaTau (MaTau, SoThuTu, LoaiToa, SucChua) VALUES
(1, 1, N'Thường', 120), (1, 2, N'Thường', 120),
(2, 1, N'Thường', 120), (2, 2, N'Ưu tiên', 120),
(3, 1, N'Thường', 90),  (3, 2, N'Thường', 90),
(4, 1, N'Thường', 90),  (4, 2, N'Thường', 90),
(5, 1, N'Thường', 100), (5, 2, N'Thường', 100),
(6, 1, N'Thường', 100), (6, 2, N'Ưu tiên', 100);
GO

SET IDENTITY_INSERT LichTrinh ON;
INSERT INTO LichTrinh (MaLich, MaTuyen, MaTau, GioDi, GioDen, ThuTrongTuan, TrangThai) VALUES
(1, 1, 1, '06:30', '07:20', 'T2,T3,T4,T5,T6,T7,CN', N'HoatDong'),
(2, 1, 2, '17:00', '17:50', 'T2,T3,T4,T5,T6,T7,CN', N'HoatDong'),
(3, 2, 3, '07:10', '07:55', 'T2,T3,T4,T5,T6,T7,CN', N'HoatDong'),
(4, 3, 5, '08:00', '08:40', 'T2,T3,T4,T5,T6',       N'HoatDong');
SET IDENTITY_INSERT LichTrinh OFF;
GO

INSERT INTO ChuyenTau (MaLich, NgayChay, MaLaiTau, TrangThai) VALUES
(1, CAST(GETDATE() AS DATE), 4, N'ChoChay'),
(2, CAST(GETDATE() AS DATE), 5, N'ChoChay'),
(3, CAST(GETDATE() AS DATE), 4, N'ChoChay');
GO

SET IDENTITY_INSERT HanhKhach ON;
INSERT INTO HanhKhach (MaHK, HoTen, CCCD, DienThoai) VALUES
(1, N'Lê Minh Khoa',  '079123456789', '0912345678'),
(2, N'Phạm Gia Hân',  '079987654321', '0922223333'),
(3, N'Đỗ Anh Thư',    '079111222333', '0933334444');
SET IDENTITY_INSERT HanhKhach OFF;
GO

/* Gia = (thu tu ga den - thu tu ga di) * 10000. Uu tien con mot nua. */
INSERT INTO Ve (MaChuyen, MaHK, MaGaDi, MaGaDen, LoaiVe, Gia, NgayMua, MaNVBan, TrangThai) VALUES
(1, 1, 1, 4, N'Thuong', 30000, GETDATE(), 2, N'DaBan'),
(1, 2, 2, 5, N'Thuong', 30000, GETDATE(), 2, N'DaBan'),
(1, 3, 1, 3, N'UuTien', 10000, GETDATE(), 2, N'DaBan');
GO

INSERT INTO BaoTri (MaTau, NgayBatDau, NgayKetThuc, NoiDung, ChiPhi, MaNV, TrangThai) VALUES
(4, CAST(GETDATE() AS DATE), NULL, N'Thay má phanh toa 1', 1500000, 3, N'DangLam'),
(1, DATEADD(DAY, -10, CAST(GETDATE() AS DATE)), DATEADD(DAY, -8, CAST(GETDATE() AS DATE)), N'Bảo dưỡng định kỳ', 800000, 3, N'HoanThanh');
GO

/* ===================== STORED PROCEDURE ===================== */

GO
CREATE PROCEDURE sp_DangNhap
    @TenDangNhap VARCHAR(50),
    @MatKhau     VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaNV, HoTen, ChucVu, TenDangNhap
    FROM NhanVien
    WHERE TenDangNhap = @TenDangNhap
      AND MatKhau = @MatKhau
      AND TrangThai = N'DangLam';
END
GO

CREATE PROCEDURE sp_ThongKeTrangChu
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        (SELECT COUNT(*) FROM Tau WHERE TrangThai = N'SanSang') AS TauSanSang,
        (SELECT COUNT(*) FROM ChuyenTau WHERE NgayChay = CAST(GETDATE() AS DATE) AND TrangThai <> N'Huy') AS ChuyenHomNay,
        (SELECT COUNT(*) FROM Ve WHERE CAST(NgayMua AS DATE) = CAST(GETDATE() AS DATE) AND TrangThai <> N'Huy') AS VeHomNay;
END
GO

CREATE PROCEDURE sp_Ga_Select
    @ChiHoatDong BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        MaGa, TenGa, DiaChi, KhuVuc, TrangThai,
        dbo.fn_TenTrangThai(TrangThai) AS TenTrangThai
    FROM Ga
    WHERE @ChiHoatDong = 0 OR TrangThai = N'HoatDong'
    ORDER BY TenGa;
END
GO

CREATE PROCEDURE sp_Ga_Them
    @TenGa   NVARCHAR(100),
    @DiaChi  NVARCHAR(200) = NULL,
    @KhuVuc  NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF LTRIM(RTRIM(ISNULL(@TenGa, N''))) = N''
    BEGIN
        RAISERROR(N'Tên ga không được để trống.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Ga WHERE TenGa = @TenGa AND TrangThai = N'HoatDong')
    BEGIN
        RAISERROR(N'Đã có ga cùng tên đang hoạt động.', 16, 1);
        RETURN;
    END
    INSERT INTO Ga (TenGa, DiaChi, KhuVuc, TrangThai)
    VALUES (LTRIM(RTRIM(@TenGa)), @DiaChi, @KhuVuc, N'HoatDong');
END
GO

CREATE PROCEDURE sp_Ga_Sua
    @MaGa   INT,
    @TenGa  NVARCHAR(100),
    @DiaChi NVARCHAR(200) = NULL,
    @KhuVuc NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Ga WHERE MaGa = @MaGa)
    BEGIN
        RAISERROR(N'Không tìm thấy ga.', 16, 1);
        RETURN;
    END
    IF LTRIM(RTRIM(ISNULL(@TenGa, N''))) = N''
    BEGIN
        RAISERROR(N'Tên ga không được để trống.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Ga WHERE TenGa = @TenGa AND TrangThai = N'HoatDong' AND MaGa <> @MaGa)
    BEGIN
        RAISERROR(N'Đã có ga cùng tên đang hoạt động.', 16, 1);
        RETURN;
    END
    UPDATE Ga
    SET TenGa = LTRIM(RTRIM(@TenGa)), DiaChi = @DiaChi, KhuVuc = @KhuVuc
    WHERE MaGa = @MaGa;
END
GO

CREATE PROCEDURE sp_Ga_Ngung
    @MaGa INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Ga WHERE MaGa = @MaGa)
    BEGIN
        RAISERROR(N'Không tìm thấy ga.', 16, 1);
        RETURN;
    END
    IF EXISTS
    (
        SELECT 1
        FROM Tuyen_Ga AS tg
        INNER JOIN Tuyen AS t ON tg.MaTuyen = t.MaTuyen
        WHERE tg.MaGa = @MaGa AND t.TrangThai = N'HoatDong'
    )
    BEGIN
        RAISERROR(N'Ga đang nằm trên tuyến hoạt động. Hãy gỡ ga khỏi tuyến trước.', 16, 1);
        RETURN;
    END
    UPDATE Ga SET TrangThai = N'Ngung' WHERE MaGa = @MaGa;
END
GO

CREATE PROCEDURE sp_Tuyen_Select
    @MaTuyen INT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        t.MaTuyen,
        t.TenTuyen,
        ISNULL(gd.TenGa, N'') AS GaDau,
        ISNULL(gc.TenGa, N'') AS GaCuoi,
        t.TrangThai,
        dbo.fn_TenTrangThai(t.TrangThai) AS TenTrangThai,
        t.MaGaDau,
        t.MaGaCuoi,
        (SELECT COUNT(*) FROM Tuyen_Ga AS tg WHERE tg.MaTuyen = t.MaTuyen) AS SoGa
    FROM Tuyen AS t
    LEFT JOIN Ga AS gd ON t.MaGaDau = gd.MaGa
    LEFT JOIN Ga AS gc ON t.MaGaCuoi = gc.MaGa
    WHERE @MaTuyen = 0 OR t.MaTuyen = @MaTuyen
    ORDER BY t.TenTuyen;
END
GO

CREATE PROCEDURE sp_Tuyen_Them
    @TenTuyen NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF LTRIM(RTRIM(ISNULL(@TenTuyen, N''))) = N''
    BEGIN
        RAISERROR(N'Tên tuyến không được để trống.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Tuyen WHERE TenTuyen = @TenTuyen AND TrangThai = N'HoatDong')
    BEGIN
        RAISERROR(N'Đã có tuyến cùng tên đang hoạt động.', 16, 1);
        RETURN;
    END
    INSERT INTO Tuyen (TenTuyen, TrangThai)
    VALUES (LTRIM(RTRIM(@TenTuyen)), N'HoatDong');
END
GO

CREATE PROCEDURE sp_Tuyen_Sua
    @MaTuyen  INT,
    @TenTuyen NVARCHAR(100),
    @TrangThai NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Tuyen WHERE MaTuyen = @MaTuyen)
    BEGIN
        RAISERROR(N'Không tìm thấy tuyến.', 16, 1);
        RETURN;
    END
    IF LTRIM(RTRIM(ISNULL(@TenTuyen, N''))) = N''
    BEGIN
        RAISERROR(N'Tên tuyến không được để trống.', 16, 1);
        RETURN;
    END
    IF @TrangThai NOT IN (N'HoatDong', N'Ngung')
    BEGIN
        RAISERROR(N'Trạng thái tuyến không hợp lệ.', 16, 1);
        RETURN;
    END
    IF @TrangThai = N'Ngung' AND EXISTS
    (
        SELECT 1
        FROM ChuyenTau AS c
        INNER JOIN LichTrinh AS l ON c.MaLich = l.MaLich
        WHERE l.MaTuyen = @MaTuyen
          AND c.TrangThai = N'ChoChay'
          AND c.NgayChay >= CAST(GETDATE() AS DATE)
    )
    BEGIN
        RAISERROR(N'Còn chuyến sắp chạy trên tuyến này.', 16, 1);
        RETURN;
    END
    UPDATE Tuyen
    SET TenTuyen = LTRIM(RTRIM(@TenTuyen)), TrangThai = @TrangThai
    WHERE MaTuyen = @MaTuyen;

    IF @TrangThai = N'Ngung'
        UPDATE LichTrinh SET TrangThai = N'Ngung' WHERE MaTuyen = @MaTuyen AND TrangThai = N'HoatDong';
END
GO

CREATE PROCEDURE sp_Tuyen_Ngung
    @MaTuyen INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Ten NVARCHAR(100);
    SELECT @Ten = TenTuyen FROM Tuyen WHERE MaTuyen = @MaTuyen;
    IF @Ten IS NULL
    BEGIN
        RAISERROR(N'Không tìm thấy tuyến.', 16, 1);
        RETURN;
    END
    EXEC sp_Tuyen_Sua @MaTuyen = @MaTuyen, @TenTuyen = @Ten, @TrangThai = N'Ngung';
END
GO

CREATE PROCEDURE sp_CapNhatGaDauCuoi
    @MaTuyen INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Dau INT, @Cuoi INT;
    SELECT TOP 1 @Dau = MaGa FROM Tuyen_Ga WHERE MaTuyen = @MaTuyen ORDER BY ThuTu ASC;
    SELECT TOP 1 @Cuoi = MaGa FROM Tuyen_Ga WHERE MaTuyen = @MaTuyen ORDER BY ThuTu DESC;
    UPDATE Tuyen SET MaGaDau = @Dau, MaGaCuoi = @Cuoi WHERE MaTuyen = @MaTuyen;
END
GO

CREATE PROCEDURE sp_TuyenGa_Select
    @MaTuyen INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT tg.ThuTu, g.MaGa, g.TenGa, tg.PhutDung, g.KhuVuc
    FROM Tuyen_Ga AS tg
    INNER JOIN Ga AS g ON tg.MaGa = g.MaGa
    WHERE tg.MaTuyen = @MaTuyen
    ORDER BY tg.ThuTu;
END
GO

CREATE PROCEDURE sp_TuyenGa_Them
    @MaTuyen INT,
    @MaGa INT,
    @ThuTu INT,
    @PhutDung INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Tuyen WHERE MaTuyen = @MaTuyen AND TrangThai = N'HoatDong')
    BEGIN
        RAISERROR(N'Tuyến không còn hoạt động.', 16, 1);
        RETURN;
    END
    IF NOT EXISTS (SELECT 1 FROM Ga WHERE MaGa = @MaGa AND TrangThai = N'HoatDong')
    BEGIN
        RAISERROR(N'Ga không hoạt động hoặc không tồn tại.', 16, 1);
        RETURN;
    END
    IF @ThuTu < 1
    BEGIN
        RAISERROR(N'Thứ tự ga phải từ 1 trở lên.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Tuyen_Ga WHERE MaTuyen = @MaTuyen AND MaGa = @MaGa)
    BEGIN
        RAISERROR(N'Ga này đã có trên tuyến.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Tuyen_Ga WHERE MaTuyen = @MaTuyen AND ThuTu = @ThuTu)
    BEGIN
        RAISERROR(N'Thứ tự này đã có ga khác.', 16, 1);
        RETURN;
    END
    IF @PhutDung < 0 SET @PhutDung = 0;

    INSERT INTO Tuyen_Ga (MaTuyen, MaGa, ThuTu, PhutDung)
    VALUES (@MaTuyen, @MaGa, @ThuTu, @PhutDung);

    EXEC sp_CapNhatGaDauCuoi @MaTuyen = @MaTuyen;
END
GO

CREATE PROCEDURE sp_TuyenGa_Xoa
    @MaTuyen INT,
    @MaGa INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Tuyen_Ga WHERE MaTuyen = @MaTuyen AND MaGa = @MaGa)
    BEGIN
        RAISERROR(N'Ga không nằm trên tuyến này.', 16, 1);
        RETURN;
    END
    DELETE FROM Tuyen_Ga WHERE MaTuyen = @MaTuyen AND MaGa = @MaGa;
    EXEC sp_CapNhatGaDauCuoi @MaTuyen = @MaTuyen;
END
GO

CREATE PROCEDURE sp_Tau_Select
    @MaTuyen INT = 0,
    @TrangThai NVARCHAR(20) = N'',
    @MaTau INT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        tau.MaTau,
        tau.TenTau,
        tau.LoaiTau,
        dbo.fn_TenTrangThai(tau.LoaiTau) AS TenLoai,
        tau.SucChua,
        tau.MaTuyen,
        ISNULL(t.TenTuyen, N'') AS TenTuyen,
        tau.TrangThai,
        dbo.fn_TenTrangThai(tau.TrangThai) AS TenTrangThai,
        (SELECT COUNT(*) FROM ToaTau AS toa WHERE toa.MaTau = tau.MaTau) AS SoToa
    FROM Tau AS tau
    LEFT JOIN Tuyen AS t ON tau.MaTuyen = t.MaTuyen
    WHERE (@MaTau = 0 OR tau.MaTau = @MaTau)
      AND (@MaTuyen = 0 OR tau.MaTuyen = @MaTuyen)
      AND (@TrangThai = N'' OR tau.TrangThai = @TrangThai)
    ORDER BY tau.TenTau;
END
GO

CREATE PROCEDURE sp_Tau_Them
    @TenTau NVARCHAR(50),
    @LoaiTau NVARCHAR(20),
    @SucChua INT,
    @MaTuyen INT = 0,
    @TrangThai NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF LTRIM(RTRIM(ISNULL(@TenTau, N''))) = N''
    BEGIN
        RAISERROR(N'Tên tàu không được để trống.', 16, 1);
        RETURN;
    END
    IF @LoaiTau NOT IN (N'Metro', N'TauHoa')
    BEGIN
        RAISERROR(N'Loại tàu không hợp lệ.', 16, 1);
        RETURN;
    END
    IF @SucChua < 1
    BEGIN
        RAISERROR(N'Sức chứa phải lớn hơn 0.', 16, 1);
        RETURN;
    END
    IF @TrangThai NOT IN (N'SanSang', N'DangChay', N'BaoTri', N'Hong')
    BEGIN
        RAISERROR(N'Trạng thái tàu không hợp lệ.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Tau WHERE TenTau = @TenTau)
    BEGIN
        RAISERROR(N'Tên tàu đã tồn tại.', 16, 1);
        RETURN;
    END
    IF @MaTuyen <> 0 AND NOT EXISTS (SELECT 1 FROM Tuyen WHERE MaTuyen = @MaTuyen)
    BEGIN
        RAISERROR(N'Không tìm thấy tuyến.', 16, 1);
        RETURN;
    END

    INSERT INTO Tau (TenTau, LoaiTau, SucChua, MaTuyen, TrangThai)
    VALUES
    (
        LTRIM(RTRIM(@TenTau)),
        @LoaiTau,
        @SucChua,
        CASE WHEN @MaTuyen = 0 THEN NULL ELSE @MaTuyen END,
        @TrangThai
    );
END
GO

CREATE PROCEDURE sp_Tau_Sua
    @MaTau INT,
    @TenTau NVARCHAR(50),
    @LoaiTau NVARCHAR(20),
    @SucChua INT,
    @MaTuyen INT = 0,
    @TrangThai NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Tau WHERE MaTau = @MaTau)
    BEGIN
        RAISERROR(N'Không tìm thấy tàu.', 16, 1);
        RETURN;
    END
    IF LTRIM(RTRIM(ISNULL(@TenTau, N''))) = N''
    BEGIN
        RAISERROR(N'Tên tàu không được để trống.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Tau WHERE TenTau = @TenTau AND MaTau <> @MaTau)
    BEGIN
        RAISERROR(N'Tên tàu đã tồn tại.', 16, 1);
        RETURN;
    END
    IF @LoaiTau NOT IN (N'Metro', N'TauHoa') OR @TrangThai NOT IN (N'SanSang', N'DangChay', N'BaoTri', N'Hong')
    BEGIN
        RAISERROR(N'Loại tàu hoặc trạng thái không hợp lệ.', 16, 1);
        RETURN;
    END
    IF @TrangThai = N'SanSang' AND EXISTS (SELECT 1 FROM BaoTri WHERE MaTau = @MaTau AND TrangThai = N'DangLam')
    BEGIN
        RAISERROR(N'Còn phiếu bảo trì đang làm. Hãy hoàn thành phiếu trước.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM ToaTau WHERE MaTau = @MaTau)
        SELECT @SucChua = SUM(SucChua) FROM ToaTau WHERE MaTau = @MaTau;
    IF @SucChua < 1
    BEGIN
        RAISERROR(N'Sức chứa phải lớn hơn 0.', 16, 1);
        RETURN;
    END

    UPDATE Tau
    SET TenTau = LTRIM(RTRIM(@TenTau)),
        LoaiTau = @LoaiTau,
        SucChua = @SucChua,
        MaTuyen = CASE WHEN @MaTuyen = 0 THEN NULL ELSE @MaTuyen END,
        TrangThai = @TrangThai
    WHERE MaTau = @MaTau;
END
GO

CREATE PROCEDURE sp_ToaTau_Select
    @MaTau INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaToa, SoThuTu, LoaiToa, SucChua
    FROM ToaTau
    WHERE MaTau = @MaTau
    ORDER BY SoThuTu;
END
GO

CREATE PROCEDURE sp_ToaTau_Them
    @MaTau INT,
    @SoThuTu INT,
    @LoaiToa NVARCHAR(30),
    @SucChua INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Tau WHERE MaTau = @MaTau)
    BEGIN
        RAISERROR(N'Không tìm thấy tàu.', 16, 1);
        RETURN;
    END
    IF @SoThuTu < 1 OR @SucChua < 1 OR LTRIM(RTRIM(ISNULL(@LoaiToa, N''))) = N''
    BEGIN
        RAISERROR(N'Nhập số thứ tự, loại toa và sức chứa.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM ToaTau WHERE MaTau = @MaTau AND SoThuTu = @SoThuTu)
    BEGIN
        RAISERROR(N'Số thứ tự toa đã tồn tại.', 16, 1);
        RETURN;
    END

    INSERT INTO ToaTau (MaTau, SoThuTu, LoaiToa, SucChua)
    VALUES (@MaTau, @SoThuTu, LTRIM(RTRIM(@LoaiToa)), @SucChua);

    UPDATE Tau
    SET SucChua = (SELECT SUM(SucChua) FROM ToaTau WHERE MaTau = @MaTau)
    WHERE MaTau = @MaTau;
END
GO

CREATE PROCEDURE sp_ToaTau_Xoa
    @MaToa INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @MaTau INT;
    SELECT @MaTau = MaTau FROM ToaTau WHERE MaToa = @MaToa;
    IF @MaTau IS NULL
    BEGIN
        RAISERROR(N'Không tìm thấy toa.', 16, 1);
        RETURN;
    END
    DELETE FROM ToaTau WHERE MaToa = @MaToa;

    DECLARE @Tong INT = (SELECT SUM(SucChua) FROM ToaTau WHERE MaTau = @MaTau);
    IF @Tong IS NOT NULL
        UPDATE Tau SET SucChua = @Tong WHERE MaTau = @MaTau;
END
GO

CREATE PROCEDURE sp_Lich_Select
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        l.MaLich,
        t.TenTuyen,
        tau.TenTau,
        CONVERT(VARCHAR(5), l.GioDi, 108) AS GioDi,
        CONVERT(VARCHAR(5), l.GioDen, 108) AS GioDen,
        l.ThuTrongTuan,
        l.TrangThai,
        dbo.fn_TenTrangThai(l.TrangThai) AS TenTrangThai,
        l.MaTuyen,
        l.MaTau
    FROM LichTrinh AS l
    INNER JOIN Tuyen AS t ON l.MaTuyen = t.MaTuyen
    INNER JOIN Tau AS tau ON l.MaTau = tau.MaTau
    ORDER BY t.TenTuyen, l.GioDi;
END
GO

CREATE PROCEDURE sp_Lich_Them
    @MaTuyen INT,
    @MaTau INT,
    @GioDi TIME,
    @GioDen TIME,
    @ThuTrongTuan VARCHAR(40)
AS
BEGIN
    SET NOCOUNT ON;
    IF @GioDen <= @GioDi
    BEGIN
        RAISERROR(N'Giờ đến phải sau giờ đi.', 16, 1);
        RETURN;
    END
    IF LTRIM(RTRIM(ISNULL(@ThuTrongTuan, ''))) = ''
    BEGIN
        RAISERROR(N'Chọn ít nhất một thứ trong tuần.', 16, 1);
        RETURN;
    END
    IF (SELECT COUNT(*) FROM Tuyen_Ga WHERE MaTuyen = @MaTuyen) < 2
    BEGIN
        RAISERROR(N'Tuyến cần ít nhất hai ga trước khi lập lịch.', 16, 1);
        RETURN;
    END
    IF NOT EXISTS (SELECT 1 FROM Tuyen WHERE MaTuyen = @MaTuyen AND TrangThai = N'HoatDong')
    BEGIN
        RAISERROR(N'Tuyến không hoạt động.', 16, 1);
        RETURN;
    END

    DECLARE @TrangThaiTau NVARCHAR(20), @TuyenTau INT;
    SELECT @TrangThaiTau = TrangThai, @TuyenTau = MaTuyen FROM Tau WHERE MaTau = @MaTau;
    IF @TrangThaiTau IS NULL
    BEGIN
        RAISERROR(N'Không tìm thấy tàu.', 16, 1);
        RETURN;
    END
    IF @TrangThaiTau IN (N'BaoTri', N'Hong')
    BEGIN
        RAISERROR(N'Không xếp lịch cho tàu đang bảo trì hoặc hỏng.', 16, 1);
        RETURN;
    END
    IF @TuyenTau IS NOT NULL AND @TuyenTau <> @MaTuyen
    BEGIN
        RAISERROR(N'Tàu đang được gán cho tuyến khác.', 16, 1);
        RETURN;
    END

    INSERT INTO LichTrinh (MaTuyen, MaTau, GioDi, GioDen, ThuTrongTuan, TrangThai)
    VALUES (@MaTuyen, @MaTau, @GioDi, @GioDen, @ThuTrongTuan, N'HoatDong');

    IF @TuyenTau IS NULL
        UPDATE Tau SET MaTuyen = @MaTuyen WHERE MaTau = @MaTau;
END
GO

CREATE PROCEDURE sp_Lich_Sua
    @MaLich INT,
    @MaTuyen INT,
    @MaTau INT,
    @GioDi TIME,
    @GioDen TIME,
    @ThuTrongTuan VARCHAR(40),
    @TrangThai NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM LichTrinh WHERE MaLich = @MaLich)
    BEGIN
        RAISERROR(N'Không tìm thấy lịch trình.', 16, 1);
        RETURN;
    END
    IF @GioDen <= @GioDi
    BEGIN
        RAISERROR(N'Giờ đến phải sau giờ đi.', 16, 1);
        RETURN;
    END
    IF @TrangThai NOT IN (N'HoatDong', N'Ngung')
    BEGIN
        RAISERROR(N'Trạng thái lịch không hợp lệ.', 16, 1);
        RETURN;
    END
    IF @TrangThai = N'HoatDong'
    BEGIN
        DECLARE @TrangThaiTau NVARCHAR(20);
        SELECT @TrangThaiTau = TrangThai FROM Tau WHERE MaTau = @MaTau;
        IF @TrangThaiTau IN (N'BaoTri', N'Hong')
        BEGIN
            RAISERROR(N'Không kích hoạt lịch của tàu đang bảo trì hoặc hỏng.', 16, 1);
            RETURN;
        END
    END

    UPDATE LichTrinh
    SET MaTuyen = @MaTuyen,
        MaTau = @MaTau,
        GioDi = @GioDi,
        GioDen = @GioDen,
        ThuTrongTuan = @ThuTrongTuan,
        TrangThai = @TrangThai
    WHERE MaLich = @MaLich;
END
GO

CREATE PROCEDURE sp_Lich_Ngung
    @MaLich INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM LichTrinh WHERE MaLich = @MaLich)
    BEGIN
        RAISERROR(N'Không tìm thấy lịch trình.', 16, 1);
        RETURN;
    END
    UPDATE LichTrinh SET TrangThai = N'Ngung' WHERE MaLich = @MaLich;
END
GO

CREATE PROCEDURE sp_SinhChuyen
    @MaLich INT,
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    IF @DenNgay < @TuNgay
    BEGIN
        RAISERROR(N'Ngày kết thúc phải sau ngày bắt đầu.', 16, 1);
        RETURN;
    END
    IF DATEDIFF(DAY, @TuNgay, @DenNgay) > 60
    BEGIN
        RAISERROR(N'Chỉ sinh chuyến trong tối đa 60 ngày.', 16, 1);
        RETURN;
    END

    DECLARE @MaTau INT, @TrangThaiTau NVARCHAR(20), @Thu VARCHAR(40), @LichOn NVARCHAR(20);
    SELECT
        @MaTau = l.MaTau,
        @TrangThaiTau = t.TrangThai,
        @Thu = l.ThuTrongTuan,
        @LichOn = l.TrangThai
    FROM LichTrinh AS l
    INNER JOIN Tau AS t ON l.MaTau = t.MaTau
    WHERE l.MaLich = @MaLich;

    IF @MaTau IS NULL
    BEGIN
        RAISERROR(N'Không tìm thấy lịch trình.', 16, 1);
        RETURN;
    END
    IF @LichOn <> N'HoatDong'
    BEGIN
        RAISERROR(N'Lịch trình đang ngừng.', 16, 1);
        RETURN;
    END
    IF @TrangThaiTau IN (N'BaoTri', N'Hong')
    BEGIN
        RAISERROR(N'Không sinh chuyến cho tàu đang bảo trì hoặc hỏng.', 16, 1);
        RETURN;
    END

    DECLARE @d DATE = @TuNgay, @So INT = 0;
    WHILE @d <= @DenNgay
    BEGIN
        IF CHARINDEX(dbo.fn_Thu(@d), @Thu) > 0
           AND NOT EXISTS (SELECT 1 FROM ChuyenTau WHERE MaLich = @MaLich AND NgayChay = @d)
        BEGIN
            INSERT INTO ChuyenTau (MaLich, NgayChay, TrangThai)
            VALUES (@MaLich, @d, N'ChoChay');
            SET @So = @So + 1;
        END
        SET @d = DATEADD(DAY, 1, @d);
    END
    SELECT @So AS SoChuyenTao;
END
GO

CREATE PROCEDURE sp_Chuyen_Select
    @Ngay DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        MaChuyen,
        TenTuyen,
        TenTau,
        CONVERT(VARCHAR(5), GioDi, 108) AS GioDi,
        CONVERT(VARCHAR(5), GioDen, 108) AS GioDen,
        ISNULL(LaiTau, N'') AS LaiTau,
        TrangThai,
        dbo.fn_TenTrangThai(TrangThai) AS TenTrangThai,
        SucChua,
        SoVe,
        SoChoTrong,
        MaLaiTau
    FROM vw_ChuyenTauChiTiet
    WHERE NgayChay = @Ngay
    ORDER BY GioDi;
END
GO

CREATE PROCEDURE sp_Chuyen_ChoBan
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        MaChuyen,
        TenTuyen + N' | ' + CONVERT(VARCHAR(10), NgayChay, 103) + N' '
            + CONVERT(VARCHAR(5), GioDi, 108) + N' | còn '
            + CAST(SoChoTrong AS NVARCHAR(10)) + N' chỗ' AS MoTa
    FROM vw_ChuyenTauChiTiet
    WHERE TrangThai = N'ChoChay'
      AND NgayChay >= CAST(GETDATE() AS DATE)
    ORDER BY NgayChay, GioDi;
END
GO

CREATE PROCEDURE sp_Chuyen_CapNhat
    @MaChuyen INT,
    @MaLaiTau INT = 0,
    @TrangThai NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM ChuyenTau WHERE MaChuyen = @MaChuyen)
    BEGIN
        RAISERROR(N'Không tìm thấy chuyến.', 16, 1);
        RETURN;
    END
    IF @TrangThai NOT IN (N'ChoChay', N'DangChay', N'HoanThanh', N'Huy')
    BEGIN
        RAISERROR(N'Trạng thái chuyến không hợp lệ.', 16, 1);
        RETURN;
    END
    IF @MaLaiTau <> 0 AND NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @MaLaiTau AND ChucVu = N'LaiTau' AND TrangThai = N'DangLam')
    BEGIN
        RAISERROR(N'Lái tàu không hợp lệ.', 16, 1);
        RETURN;
    END
    IF @TrangThai = N'DangChay'
    BEGIN
        DECLARE @TrangThaiTau NVARCHAR(20);
        SELECT @TrangThaiTau = tau.TrangThai
        FROM ChuyenTau AS c
        INNER JOIN LichTrinh AS l ON c.MaLich = l.MaLich
        INNER JOIN Tau AS tau ON l.MaTau = tau.MaTau
        WHERE c.MaChuyen = @MaChuyen;
        IF @TrangThaiTau IN (N'BaoTri', N'Hong')
        BEGIN
            RAISERROR(N'Tàu của chuyến đang bảo trì hoặc hỏng.', 16, 1);
            RETURN;
        END
    END

    UPDATE ChuyenTau
    SET MaLaiTau = CASE WHEN @MaLaiTau = 0 THEN NULL ELSE @MaLaiTau END,
        TrangThai = @TrangThai
    WHERE MaChuyen = @MaChuyen;
END
GO

CREATE PROCEDURE sp_Ga_TheoChuyen
    @MaChuyen INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT g.MaGa, CAST(tg.ThuTu AS NVARCHAR(10)) + N'. ' + g.TenGa AS TenGa, tg.ThuTu
    FROM ChuyenTau AS c
    INNER JOIN LichTrinh AS l ON c.MaLich = l.MaLich
    INNER JOIN Tuyen_Ga AS tg ON tg.MaTuyen = l.MaTuyen
    INNER JOIN Ga AS g ON g.MaGa = tg.MaGa
    WHERE c.MaChuyen = @MaChuyen
    ORDER BY tg.ThuTu;
END
GO

CREATE PROCEDURE sp_TinhGia
    @MaChuyen INT,
    @MaGaDi INT,
    @MaGaDen INT,
    @LoaiVe NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Gia DECIMAL(18, 0) = dbo.fn_TinhGia(@MaChuyen, @MaGaDi, @MaGaDen, @LoaiVe);
    IF @Gia IS NULL
    BEGIN
        RAISERROR(N'Ga đi phải đứng trước ga đến trên cùng tuyến của chuyến.', 16, 1);
        RETURN;
    END
    SELECT @Gia AS Gia;
END
GO

CREATE PROCEDURE sp_BanVe
    @MaChuyen INT,
    @HoTen NVARCHAR(100),
    @CCCD VARCHAR(20),
    @DienThoai VARCHAR(20) = NULL,
    @MaGaDi INT,
    @MaGaDen INT,
    @LoaiVe NVARCHAR(20),
    @MaNVBan INT
AS
BEGIN
    SET NOCOUNT ON;
    IF LTRIM(RTRIM(ISNULL(@HoTen, N''))) = N'' OR LTRIM(RTRIM(ISNULL(@CCCD, ''))) = ''
    BEGIN
        RAISERROR(N'Nhập họ tên và CCCD.', 16, 1);
        RETURN;
    END
    SET @CCCD = LTRIM(RTRIM(@CCCD));
    IF LEN(@CCCD) < 9 OR LEN(@CCCD) > 12
    BEGIN
        RAISERROR(N'CCCD phải từ 9 đến 12 ký tự.', 16, 1);
        RETURN;
    END
    IF @LoaiVe NOT IN (N'Thuong', N'UuTien')
    BEGIN
        RAISERROR(N'Loại vé không hợp lệ.', 16, 1);
        RETURN;
    END

    DECLARE @TrangThaiChuyen NVARCHAR(20), @NgayChay DATE, @SucChua INT, @DaBan INT, @Gia DECIMAL(18, 0);
    SELECT
        @TrangThaiChuyen = c.TrangThai,
        @NgayChay = c.NgayChay,
        @SucChua = tau.SucChua
    FROM ChuyenTau AS c
    INNER JOIN LichTrinh AS l ON c.MaLich = l.MaLich
    INNER JOIN Tau AS tau ON l.MaTau = tau.MaTau
    WHERE c.MaChuyen = @MaChuyen;

    IF @TrangThaiChuyen IS NULL
    BEGIN
        RAISERROR(N'Không tìm thấy chuyến.', 16, 1);
        RETURN;
    END
    IF @TrangThaiChuyen <> N'ChoChay'
    BEGIN
        RAISERROR(N'Chỉ bán vé cho chuyến đang chờ chạy.', 16, 1);
        RETURN;
    END
    IF @NgayChay < CAST(GETDATE() AS DATE)
    BEGIN
        RAISERROR(N'Chuyến đã qua ngày chạy.', 16, 1);
        RETURN;
    END

    SET @Gia = dbo.fn_TinhGia(@MaChuyen, @MaGaDi, @MaGaDen, @LoaiVe);
    IF @Gia IS NULL
    BEGIN
        RAISERROR(N'Ga đi phải đứng trước ga đến trên cùng tuyến của chuyến.', 16, 1);
        RETURN;
    END

    SELECT @DaBan = COUNT(*) FROM Ve WHERE MaChuyen = @MaChuyen AND TrangThai <> N'Huy';
    IF @DaBan >= @SucChua
    BEGIN
        RAISERROR(N'Chuyến đã hết chỗ.', 16, 1);
        RETURN;
    END
    IF EXISTS
    (
        SELECT 1
        FROM Ve AS v
        INNER JOIN HanhKhach AS h ON v.MaHK = h.MaHK
        WHERE v.MaChuyen = @MaChuyen AND h.CCCD = @CCCD AND v.TrangThai <> N'Huy'
    )
    BEGIN
        RAISERROR(N'Hành khách đã có vé còn hiệu lực trên chuyến này.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;
        DECLARE @MaHK INT;
        SELECT @MaHK = MaHK FROM HanhKhach WHERE CCCD = @CCCD;
        IF @MaHK IS NULL
        BEGIN
            INSERT INTO HanhKhach (HoTen, CCCD, DienThoai)
            VALUES (LTRIM(RTRIM(@HoTen)), @CCCD, @DienThoai);
            SET @MaHK = CONVERT(INT, SCOPE_IDENTITY());
        END
        ELSE
        BEGIN
            UPDATE HanhKhach
            SET HoTen = LTRIM(RTRIM(@HoTen)), DienThoai = @DienThoai
            WHERE MaHK = @MaHK;
        END

        INSERT INTO Ve (MaChuyen, MaHK, MaGaDi, MaGaDen, LoaiVe, Gia, NgayMua, MaNVBan, TrangThai)
        VALUES (@MaChuyen, @MaHK, @MaGaDi, @MaGaDen, @LoaiVe, @Gia, GETDATE(), @MaNVBan, N'DaBan');

        DECLARE @MaVe INT = CONVERT(INT, SCOPE_IDENTITY());
        COMMIT TRANSACTION;
        SELECT @MaVe AS MaVe;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE sp_Ve_TraCuu
    @MaVe INT = 0,
    @CCCD VARCHAR(20) = '',
    @Ngay DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @MaVe = 0 AND LTRIM(RTRIM(ISNULL(@CCCD, ''))) = '' AND @Ngay IS NULL
        SET @Ngay = CAST(GETDATE() AS DATE);

    SELECT
        MaVe, MaChuyen, MaHK, HoTen, CCCD, DienThoai,
        GaDi, GaDen, TenLoaiVe, Gia, NgayMua, TenTrangThai, NguoiBan, TenTuyen, NgayChay,
        TrangThai, LoaiVe
    FROM vw_VeChiTiet
    WHERE (@MaVe = 0 OR MaVe = @MaVe)
      AND (@CCCD = '' OR CCCD LIKE '%' + @CCCD + '%')
      AND (@Ngay IS NULL OR NgayChay = @Ngay)
    ORDER BY NgayMua DESC;
END
GO

CREATE PROCEDURE sp_HuyVe
    @MaVe INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @TrangThai NVARCHAR(20), @TrangThaiChuyen NVARCHAR(20);
    SELECT @TrangThai = v.TrangThai, @TrangThaiChuyen = c.TrangThai
    FROM Ve AS v
    INNER JOIN ChuyenTau AS c ON v.MaChuyen = c.MaChuyen
    WHERE v.MaVe = @MaVe;

    IF @TrangThai IS NULL
    BEGIN
        RAISERROR(N'Không tìm thấy vé.', 16, 1);
        RETURN;
    END
    IF @TrangThai <> N'DaBan'
    BEGIN
        RAISERROR(N'Chỉ hủy vé đang ở trạng thái đã bán.', 16, 1);
        RETURN;
    END
    IF @TrangThaiChuyen <> N'ChoChay'
    BEGIN
        RAISERROR(N'Chỉ hủy vé khi chuyến còn chờ chạy.', 16, 1);
        RETURN;
    END
    UPDATE Ve SET TrangThai = N'Huy' WHERE MaVe = @MaVe;
END
GO

CREATE PROCEDURE sp_HanhKhach_Select
    @TuKhoa NVARCHAR(100) = N''
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaHK, HoTen, CCCD, DienThoai
    FROM HanhKhach
    WHERE @TuKhoa = N''
       OR HoTen LIKE N'%' + @TuKhoa + N'%'
       OR CCCD LIKE N'%' + @TuKhoa + N'%'
    ORDER BY HoTen;
END
GO

CREATE PROCEDURE sp_Ve_TheoKhach
    @MaHK INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaVe, TenTuyen, NgayChay, GaDi, GaDen, TenLoaiVe, Gia, TenTrangThai, MaHK, CCCD
    FROM vw_VeChiTiet
    WHERE MaHK = @MaHK
    ORDER BY NgayMua DESC;
END
GO

CREATE PROCEDURE sp_NhanVien_Select
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        MaNV, HoTen, ChucVu, dbo.fn_TenTrangThai(ChucVu) AS TenChucVu,
        TenDangNhap, DienThoai, TrangThai, dbo.fn_TenTrangThai(TrangThai) AS TenTrangThai
    FROM NhanVien
    ORDER BY HoTen;
END
GO

CREATE PROCEDURE sp_NhanVien_LaiTau
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaNV, HoTen
    FROM NhanVien
    WHERE ChucVu = N'LaiTau' AND TrangThai = N'DangLam'
    ORDER BY HoTen;
END
GO

CREATE PROCEDURE sp_NhanVien_Them
    @HoTen NVARCHAR(100),
    @ChucVu NVARCHAR(20),
    @TenDangNhap VARCHAR(50),
    @MatKhau VARCHAR(64),
    @DienThoai VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF LTRIM(RTRIM(ISNULL(@HoTen, N''))) = N'' OR LTRIM(RTRIM(ISNULL(@TenDangNhap, ''))) = ''
    BEGIN
        RAISERROR(N'Nhập họ tên và tên đăng nhập.', 16, 1);
        RETURN;
    END
    IF @ChucVu NOT IN (N'QuanLy', N'BanVe', N'KyThuat', N'LaiTau')
    BEGIN
        RAISERROR(N'Chức vụ không hợp lệ.', 16, 1);
        RETURN;
    END
    IF LEN(ISNULL(@MatKhau, '')) <> 64
    BEGIN
        RAISERROR(N'Mật khẩu không hợp lệ.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM NhanVien WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        RAISERROR(N'Tên đăng nhập đã tồn tại.', 16, 1);
        RETURN;
    END
    INSERT INTO NhanVien (HoTen, ChucVu, TenDangNhap, MatKhau, DienThoai, TrangThai)
    VALUES (LTRIM(RTRIM(@HoTen)), @ChucVu, LTRIM(RTRIM(@TenDangNhap)), @MatKhau, @DienThoai, N'DangLam');
END
GO

CREATE PROCEDURE sp_NhanVien_Sua
    @MaNV INT,
    @HoTen NVARCHAR(100),
    @ChucVu NVARCHAR(20),
    @DienThoai VARCHAR(20) = NULL,
    @TrangThai NVARCHAR(20),
    @MatKhau VARCHAR(64) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @MaNV)
    BEGIN
        RAISERROR(N'Không tìm thấy nhân viên.', 16, 1);
        RETURN;
    END
    IF @ChucVu NOT IN (N'QuanLy', N'BanVe', N'KyThuat', N'LaiTau')
       OR @TrangThai NOT IN (N'DangLam', N'NghiViec')
    BEGIN
        RAISERROR(N'Chức vụ hoặc trạng thái không hợp lệ.', 16, 1);
        RETURN;
    END
    IF @MatKhau IS NOT NULL AND LEN(@MatKhau) <> 64
    BEGIN
        RAISERROR(N'Mật khẩu không hợp lệ.', 16, 1);
        RETURN;
    END
    UPDATE NhanVien
    SET HoTen = LTRIM(RTRIM(@HoTen)),
        ChucVu = @ChucVu,
        DienThoai = @DienThoai,
        TrangThai = @TrangThai,
        MatKhau = COALESCE(@MatKhau, MatKhau)
    WHERE MaNV = @MaNV;
END
GO

CREATE PROCEDURE sp_BaoTri_Select
    @MaTau INT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        bt.MaBT,
        bt.MaTau,
        tau.TenTau,
        bt.NgayBatDau,
        bt.NgayKetThuc,
        bt.NoiDung,
        bt.ChiPhi,
        bt.MaNV,
        ISNULL(nv.HoTen, N'') AS TenNV,
        bt.TrangThai,
        dbo.fn_TenTrangThai(bt.TrangThai) AS TenTrangThai
    FROM BaoTri AS bt
    INNER JOIN Tau AS tau ON bt.MaTau = tau.MaTau
    LEFT JOIN NhanVien AS nv ON bt.MaNV = nv.MaNV
    WHERE @MaTau = 0 OR bt.MaTau = @MaTau
    ORDER BY bt.NgayBatDau DESC, bt.MaBT DESC;
END
GO

CREATE PROCEDURE sp_BaoTri_Them
    @MaTau INT,
    @NgayBatDau DATE,
    @NgayKetThuc DATE = NULL,
    @NoiDung NVARCHAR(300),
    @ChiPhi DECIMAL(18, 0),
    @MaNV INT,
    @TrangThai NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Tau WHERE MaTau = @MaTau)
    BEGIN
        RAISERROR(N'Không tìm thấy tàu.', 16, 1);
        RETURN;
    END
    IF LTRIM(RTRIM(ISNULL(@NoiDung, N''))) = N''
    BEGIN
        RAISERROR(N'Nhập nội dung bảo trì.', 16, 1);
        RETURN;
    END
    IF @ChiPhi < 0
    BEGIN
        RAISERROR(N'Chi phí không được âm.', 16, 1);
        RETURN;
    END
    IF @TrangThai NOT IN (N'DangLam', N'HoanThanh')
    BEGIN
        RAISERROR(N'Trạng thái bảo trì không hợp lệ.', 16, 1);
        RETURN;
    END
    IF @NgayKetThuc IS NOT NULL AND @NgayKetThuc < @NgayBatDau
    BEGIN
        RAISERROR(N'Ngày kết thúc phải sau ngày bắt đầu.', 16, 1);
        RETURN;
    END
    IF @TrangThai = N'HoanThanh' AND @NgayKetThuc IS NULL
        SET @NgayKetThuc = @NgayBatDau;

    INSERT INTO BaoTri (MaTau, NgayBatDau, NgayKetThuc, NoiDung, ChiPhi, MaNV, TrangThai)
    VALUES (@MaTau, @NgayBatDau, @NgayKetThuc, LTRIM(RTRIM(@NoiDung)), @ChiPhi, @MaNV, @TrangThai);

    IF @TrangThai = N'DangLam'
        UPDATE Tau SET TrangThai = N'BaoTri' WHERE MaTau = @MaTau AND TrangThai <> N'Hong';
END
GO

CREATE PROCEDURE sp_BaoTri_Sua
    @MaBT INT,
    @MaTau INT,
    @NgayBatDau DATE,
    @NgayKetThuc DATE = NULL,
    @NoiDung NVARCHAR(300),
    @ChiPhi DECIMAL(18, 0),
    @MaNV INT,
    @TrangThai NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM BaoTri WHERE MaBT = @MaBT)
    BEGIN
        RAISERROR(N'Không tìm thấy phiếu bảo trì.', 16, 1);
        RETURN;
    END
    IF LTRIM(RTRIM(ISNULL(@NoiDung, N''))) = N'' OR @ChiPhi < 0
    BEGIN
        RAISERROR(N'Nội dung và chi phí không hợp lệ.', 16, 1);
        RETURN;
    END
    IF @TrangThai NOT IN (N'DangLam', N'HoanThanh')
    BEGIN
        RAISERROR(N'Trạng thái bảo trì không hợp lệ.', 16, 1);
        RETURN;
    END
    IF @TrangThai = N'HoanThanh' AND @NgayKetThuc IS NULL
        SET @NgayKetThuc = CAST(GETDATE() AS DATE);
    IF @NgayKetThuc IS NOT NULL AND @NgayKetThuc < @NgayBatDau
    BEGIN
        RAISERROR(N'Ngày kết thúc phải sau ngày bắt đầu.', 16, 1);
        RETURN;
    END

    UPDATE BaoTri
    SET MaTau = @MaTau,
        NgayBatDau = @NgayBatDau,
        NgayKetThuc = @NgayKetThuc,
        NoiDung = LTRIM(RTRIM(@NoiDung)),
        ChiPhi = @ChiPhi,
        MaNV = @MaNV,
        TrangThai = @TrangThai
    WHERE MaBT = @MaBT;

    IF @TrangThai = N'DangLam'
        UPDATE Tau SET TrangThai = N'BaoTri' WHERE MaTau = @MaTau AND TrangThai <> N'Hong';
    ELSE IF NOT EXISTS (SELECT 1 FROM BaoTri WHERE MaTau = @MaTau AND TrangThai = N'DangLam')
        AND EXISTS (SELECT 1 FROM Tau WHERE MaTau = @MaTau AND TrangThai = N'BaoTri')
        UPDATE Tau SET TrangThai = N'SanSang' WHERE MaTau = @MaTau;
END
GO

CREATE PROCEDURE sp_BaoCaoDoanhThu
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Ngay, SoVe, DoanhThu
    FROM vw_DoanhThuTheoNgay
    WHERE Ngay >= @TuNgay AND Ngay <= @DenNgay
    ORDER BY Ngay;
END
GO

CREATE PROCEDURE sp_BaoCaoTheoTuyen
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TenTuyen, COUNT(*) AS SoVe, SUM(Gia) AS DoanhThu
    FROM vw_VeChiTiet
    WHERE TrangThai <> N'Huy'
      AND NgayMua >= @TuNgay
      AND NgayMua < DATEADD(DAY, 1, @DenNgay)
    GROUP BY TenTuyen
    ORDER BY DoanhThu DESC;
END
GO

CREATE PROCEDURE sp_BaoCaoBaoTri
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        bt.MaBT,
        tau.TenTau,
        bt.NgayBatDau,
        bt.NgayKetThuc,
        bt.NoiDung,
        bt.ChiPhi,
        dbo.fn_TenTrangThai(bt.TrangThai) AS TenTrangThai,
        ISNULL(nv.HoTen, N'') AS TenNV
    FROM BaoTri AS bt
    INNER JOIN Tau AS tau ON bt.MaTau = tau.MaTau
    LEFT JOIN NhanVien AS nv ON bt.MaNV = nv.MaNV
    WHERE bt.TrangThai = N'DangLam'
       OR bt.NgayBatDau BETWEEN @TuNgay AND @DenNgay
    ORDER BY bt.NgayBatDau DESC;
END
GO

PRINT N'Da tao xong database QuanLyTau.';
PRINT N'Tai khoan: admin / 123456 , banve / 123456 , kythuat / 123456 , laixe / 123456';
GO
