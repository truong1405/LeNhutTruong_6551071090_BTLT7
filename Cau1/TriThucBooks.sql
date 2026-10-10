USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'TriThucBooks')
BEGIN
    CREATE DATABASE TriThucBooks;
END
GO

USE TriThucBooks;
GO


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

SELECT * FROM TheLoaiSach;
GO
