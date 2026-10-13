-- Chạy script này trong SQL Server Management Studio để tạo CSDL mẫu
IF DB_ID('QLSinhVien') IS NULL CREATE DATABASE QLSinhVien;
GO
USE QLSinhVien;
GO

CREATE TABLE Khoa (
    MaKhoa  NVARCHAR(10)  PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);
CREATE TABLE Lop (
    MaLop   NVARCHAR(10)  PRIMARY KEY,
    TenLop  NVARCHAR(100) NOT NULL,
    MaKhoa  NVARCHAR(10)  NOT NULL REFERENCES Khoa(MaKhoa)
);
CREATE TABLE SinhVien (
    MaSinhVien NVARCHAR(10)  PRIMARY KEY,
    HoTen      NVARCHAR(100) NOT NULL,
    NgaySinh   DATE,
    MaLop      NVARCHAR(10)  NOT NULL REFERENCES Lop(MaLop)
);
CREATE TABLE MonHoc (
    MaMonHoc  NVARCHAR(10)  PRIMARY KEY,
    TenMonHoc NVARCHAR(100) NOT NULL
);
CREATE TABLE Diem (
    MaSinhVien NVARCHAR(10) NOT NULL REFERENCES SinhVien(MaSinhVien),
    MaMonHoc   NVARCHAR(10) NOT NULL REFERENCES MonHoc(MaMonHoc),
    Diem       FLOAT,
    PRIMARY KEY (MaSinhVien, MaMonHoc)
);
GO

INSERT INTO Khoa VALUES (N'CNTT', N'Công nghệ thông tin'), (N'CNTP', N'Công nghệ thực phẩm'),
    (N'KT', N'Kinh tế'), (N'NN', N'Ngoại ngữ'), (N'HH', N'Hóa học');

INSERT INTO Lop VALUES (N'DHTH1', N'Đại học Tin học 1', N'CNTT'), (N'DHTH2', N'Đại học Tin học 2', N'CNTT'),
    (N'DHTP1', N'Đại học Thực phẩm 1', N'CNTP'), (N'DHKT1', N'Đại học Kinh tế 1', N'KT'),
    (N'DHNN1', N'Đại học Ngoại ngữ 1', N'NN');

INSERT INTO SinhVien VALUES (N'SV001', N'Nguyễn Văn An', '2004-03-12', N'DHTH1'),
    (N'SV002', N'Trần Thị Bình', '2004-07-25', N'DHTH1'),
    (N'SV003', N'Lê Hoàng Cường', '2003-11-02', N'DHTH2'),
    (N'SV004', N'Phạm Minh Dũng', '2004-01-30', N'DHTP1'),
    (N'SV005', N'Võ Thị Em', '2004-09-18', N'DHKT1');

INSERT INTO MonHoc VALUES (N'MH01', N'Lập trình .NET'), (N'MH02', N'Cơ sở dữ liệu'),
    (N'MH03', N'Cấu trúc dữ liệu'), (N'MH04', N'Mạng máy tính'), (N'MH05', N'Tiếng Anh');

INSERT INTO Diem VALUES (N'SV001', N'MH01', 8.5), (N'SV001', N'MH02', 9),
    (N'SV002', N'MH01', 7), (N'SV003', N'MH03', 6.5), (N'SV004', N'MH05', 8);
GO
