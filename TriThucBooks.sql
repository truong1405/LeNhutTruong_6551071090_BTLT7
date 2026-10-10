-- =======================================================
-- CSDL: TriThucBooks
-- Đề bài: Quản lý Thể loại Sách — Nhà sách mini "Tri Thức Books"
-- =======================================================

USE master;
GO

-- 1. Tạo cơ sở dữ liệu TriThucBooks (nếu chưa có)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'TriThucBooks')
BEGIN
    CREATE DATABASE TriThucBooks;
END
GO

USE TriThucBooks;
GO

-- 2. Tạo bảng TheLoaiSach theo cấu trúc đề bài:
-- MaTL (int, PK, Identity)
-- TenTheLoai (nvarchar(100), NOT NULL, duy nhất)
-- MoTa (nvarchar(255), NULL)
-- SoLuongSach (int, mặc định 0)
-- NgayTao (datetime, mặc định GETDATE())

IF OBJECT_ID('dbo.TheLoaiSach', 'U') IS NOT NULL
    DROP TABLE dbo.TheLoaiSach;
GO

CREATE TABLE TheLoaiSach (
    MaTL INT IDENTITY(1, 1) NOT NULL,
    TenTheLoai NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255) NULL,
    SoLuongSach INT NOT NULL CONSTRAINT DF_TheLoaiSach_SoLuong DEFAULT (0),
    NgayTao DATETIME NOT NULL CONSTRAINT DF_TheLoaiSach_NgayTao DEFAULT (GETDATE()),
    
    CONSTRAINT PK_TheLoaiSach PRIMARY KEY (MaTL),
    CONSTRAINT UQ_TheLoaiSach_TenTheLoai UNIQUE (TenTheLoai)
);
GO

-- 3. Chèn dữ liệu mẫu chuẩn (Khớp với dữ liệu trong ảnh đề bài)
SET IDENTITY_INSERT TheLoaiSach ON;
GO

INSERT INTO TheLoaiSach (MaTL, TenTheLoai, MoTa, SoLuongSach, NgayTao) VALUES
(1, N'Tiểu thuyết', N'Thể loại tiểu thuyết', 1, '2026-10-10 23:39:04'),
(2, N'Kỹ năng sống', N'Kỹ năng sống nâng sống', 15, '2026-10-10 23:39:04'),
(3, N'Thiếu nhi', N'Sách thiếu nhi', 2, '2026-10-10 23:39:04'),
(4, N'Sách giáo khoa', N'Sách giáo khoa chính thống', 2, '2026-10-10 23:39:04'),
(5, N'Truyện tranh', N'Truyện tranh', 1, '2026-10-10 23:39:04');
GO

SET IDENTITY_INSERT TheLoaiSach OFF;
GO

-- 4. Kiểm tra dữ liệu vừa tạo
SELECT * FROM TheLoaiSach;
GO
