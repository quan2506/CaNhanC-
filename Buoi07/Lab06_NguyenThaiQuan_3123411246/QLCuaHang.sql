-- Chạy script này trong SQL Server Management Studio để tạo CSDL QLCuaHang
IF DB_ID('QLCuaHang') IS NULL CREATE DATABASE QLCuaHang;
GO
USE QLCuaHang;
GO

-- Bảng SANPHAM: MaSP tự động tăng
CREATE TABLE SANPHAM (
    MaSP   INT IDENTITY(1,1) PRIMARY KEY,
    TenSP  NVARCHAR(100) NOT NULL
);

-- Bảng TONKHO: theo dõi tồn kho theo ngày
CREATE TABLE TONKHO (
    MaSP    INT NOT NULL REFERENCES SANPHAM(MaSP),
    NgayTon DATE NOT NULL,
    SLDau   INT NOT NULL DEFAULT 0,
    SLNhap  INT NOT NULL DEFAULT 0,
    SLBan   INT NOT NULL DEFAULT 0,
    PRIMARY KEY (MaSP, NgayTon)
);

-- Bảng HOADON: MaHD tự động tăng
CREATE TABLE HOADON (
    MaHD               INT IDENTITY(1,1) PRIMARY KEY,
    NgayTao            DATE NOT NULL DEFAULT GETDATE(),
    TinhTrangThanhToan INT NOT NULL DEFAULT 0   -- 0: chưa thanh toán, 1: đã thanh toán
);

-- Bảng CHITIET_HOADON
CREATE TABLE CHITIET_HOADON (
    MaHD     INT NOT NULL REFERENCES HOADON(MaHD),
    MaSP     INT NOT NULL REFERENCES SANPHAM(MaSP),
    SoLuong  INT NOT NULL,
    PRIMARY KEY (MaHD, MaSP)
);
GO

-- Dữ liệu ban đầu
INSERT INTO SANPHAM(TenSP) VALUES (N'Trà xanh'), (N'Mức dâu'), (N'Cafe');

INSERT INTO TONKHO(MaSP, NgayTon, SLDau, SLNhap, SLBan)
VALUES (1, '2016-10-29', 50, 0, 0),
       (2, '2016-10-29', 50, 0, 0),
       (3, '2016-10-29', 50, 0, 0);
GO
