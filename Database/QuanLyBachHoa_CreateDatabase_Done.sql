USE [master]
GO

IF EXISTS(SELECT NAME FROM SYS.DATABASES WHERE NAME = 'QLBachHoa')
BEGIN
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'QLBachHoa'


	USE [master]


	ALTER DATABASE [QLBachHoa] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE


	USE [master]


	DROP DATABASE [QLBachHoa]

END


CREATE DATABASE [QLBachHoa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLBachHoa', FILENAME = N'E:\Courses CNTT\Project_QuanLyBachHoa_NguyenVuDuc\Database\QLBachHoa.mdf' , SIZE = 30720KB , MAXSIZE = 153600KB, FILEGROWTH = 10240KB )
 LOG ON 
( NAME = N'QLBachHoa_log', FILENAME = N'E:\Courses CNTT\Project_QuanLyBachHoa_NguyenVuDuc\Database\QLBachHoa_log.ldf' , SIZE = 10240KB , MAXSIZE = 2048GB , FILEGROWTH = 5120KB)
GO
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QLBachHoa];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tblLoaiHang'
CREATE TABLE [dbo].[tblLoaiHang] (
    [MaLoai] varchar(15)  NOT NULL,
    [TenLoai] nvarchar(100)  NULL
);
GO

-- Creating table 'tblKhachHang'
CREATE TABLE [dbo].[tblKhachHang] (
    [MaKH] varchar(15)  NOT NULL,
    [TenKH] nvarchar(100)  NOT NULL,
    [SDT] varchar(10)  NOT NULL,
    [DiaChi] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'tblNhanVien'
CREATE TABLE [dbo].[tblNhanVien] (
    [MaNV] varchar(15) NOT NULL,
    [TenNV] nvarchar(100)  NOT NULL,
	[CMND] varchar(12) not null,
    [NgaySinh] datetime  NOT NULL,
    [Phai] bit  NOT NULL,
    [SDT] varchar(10)  NOT NULL,
    [DiaChi] nvarchar(100)  NOT NULL,
	[MaCV] varchar(15)
);
GO

-- Creating table 'tblHang'
CREATE TABLE [dbo].[tblHang] (
    [MaHH] varchar(15)  NOT NULL,
	[MaLoai] varchar(15)  NOT NULL,
    [TenHH] nvarchar(100)  NOT NULL,
	[HinhMinhHoa] varchar(256) NOT NULL,
    [DVT] nvarchar(15)  NOT NULL,
    [SoLuongTon] int  NOT NULL,
    [DonGiaNhap] float  NOT NULL,
	[DonGiaBan] float  NOT NULL,
	[VAT] int not null,
    [NgaySanXuat] datetime  NOT NULL,
    [NgayHetHan] datetime  NOT NULL,
	[BaoQuan] nvarchar(100),
	[Value] int
);
GO


-- Creating table 'tblTaiKhoan'
CREATE TABLE [dbo].[tblTaiKhoan] (
	[ID] varchar(15)  NOT NULL,
    [MaNV] varchar(15)  NOT NULL,
    [Password] varchar(15)  NOT NULL,
    
);
GO

-- Creating table 'tblHoaDonNhap'
CREATE TABLE [dbo].[tblHoaDonNhap] (
    [MaHDN] varchar(15)  NOT NULL,
	[MaNV] varchar(15)  NOT NULL,
	[MaNCC] varchar(15)  NOT NULL,
    [NgayNhap] datetime  NOT NULL,
    [TongTien] float  
);
GO

-- Creating table 'tblChiTietHoaDonNhap'
CREATE TABLE [dbo].[tblChiTietHoaDonNhap] (
	[MaHDN] varchar(15)  NOT NULL,
    [MaHH] varchar(15)  NOT NULL,
    [SoLuongNhap] int  NOT NULL,
    [DonGiaNhap] float  NOT NULL,
	[ThanhTien] float
);
GO

-- Creating table 'tblHoaDonBan'
CREATE TABLE [dbo].[tblHoaDonBan] (
    [MaHDB] varchar(15)  NOT NULL,
	[MaNV] varchar(15)  NOT NULL,
    [MaKH] varchar(15)  NOT NULL,
    [NgayBan] datetime  NOT NULL,
    [TongTien] float  NOT NULL
);
GO

-- Creating table 'tblChiTietHoaDonBan'
CREATE TABLE [dbo].[tblChiTietHoaDonBan] (
	[MaHDB] varchar(15)  NOT NULL,
    [MaHH] varchar(15)  NOT NULL,
    [SoLuongBan] int  NOT NULL,
    [DonGiaBan] float  NOT NULL,
	[ThanhTien] float
);
GO

-- Creating table 'tblNhaCungCap'
CREATE TABLE [dbo].[tblNhaCungCap] (
	[MaNCC] varchar(15) NOT NULL,
	[TenNCC] nvarchar(100) NOT NULL,
	[DiaChi] nvarchar(100) 
);
GO

--Creating table 'tblChucVu'
CREATE TABLE tblChucVu(
	MaCV varchar(15) not null,
	TenCV nvarchar(100) not null
);
GO

--Creating table 'tblPhieuThanhToan'
CREATE TABLE tblPhieuThanhToan(
	SoHD varchar(15) not null,
	MaNV varchar(15) not null,
	NgayBan datetime not null,
	TongTien float 
);
GO

--Creating table 'tblChiTietPhieuTT'
CREATE TABLE tblChiTietPhieuTT(
	SoHD varchar(15) not null,
	MaHH varchar(15) not null,
	SoLuongBan int not null,
	DonGiaBan float not null,
	ThanhTien float 
);
GO

--Creating table 'sys_Barcode'
CREATE TABLE sys_Barcode(
	seqValue int primary key not null,
	seqName varchar(15) not null
);
GO
-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MaLoai] in table 'tblLoaiHang'
ALTER TABLE [dbo].[tblLoaiHang]
ADD CONSTRAINT [PK_tblLoaiHang]
    PRIMARY KEY CLUSTERED ([MaLoai] ASC);
GO

-- Creating primary key on [MaKH] in table 'tblKhachHang'
ALTER TABLE [dbo].[tblKhachHang]
ADD CONSTRAINT [PK_tblKhachHang]
    PRIMARY KEY CLUSTERED ([MaKH] ASC);
GO

-- Creating primary key on [MaNV] in table 'tblNhanVien'
ALTER TABLE [dbo].[tblNhanVien]
ADD CONSTRAINT [PK_tblNhanVien]
    PRIMARY KEY CLUSTERED ([MaNV] ASC);
GO

-- Creating primary key on [MaHH] in table 'tblHang'
ALTER TABLE [dbo].[tblHang]
ADD CONSTRAINT [PK_tblHang]
    PRIMARY KEY CLUSTERED ([MaHH] ASC);
GO

-- Creating primary key on [ID] in table 'tblTaiKhoan'
ALTER TABLE [dbo].[tblTaiKhoan]
ADD CONSTRAINT [PK_tblTaiKhoan]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [MaHDN] in table 'tblHoaDonNhap'
ALTER TABLE [dbo].[tblHoaDonNhap]
ADD CONSTRAINT [PK_tblHoaDonNhap]
    PRIMARY KEY CLUSTERED ([MaHDN] ASC);
GO

-- Creating primary key on [MaHDN], [MaHH] in table 'tblChiTietHoaDonNhap'
ALTER TABLE [dbo].[tblChiTietHoaDonNhap]
ADD CONSTRAINT [PK_tblChiTietHoaDonNhap]
    PRIMARY KEY CLUSTERED ([MaHDN], [MaHH] ASC);
GO

-- Creating primary key on [MaHDB] in table 'tblHoaDonBan'
ALTER TABLE [dbo].[tblHoaDonBan]
ADD CONSTRAINT [PK_tblHoaDonBan]
    PRIMARY KEY CLUSTERED ([MaHDB] ASC);
GO

-- Creating primary key on [MaHDB], [MaHH] in table 'tblChiTietHoaDonBan'
ALTER TABLE [dbo].[tblChiTietHoaDonBan]
ADD CONSTRAINT [PK_tblChiTietHoaDonBan]
    PRIMARY KEY CLUSTERED ([MaHDB], [MaHH] ASC);
GO

-- Creating primary key on [MaNCC] in table 'tblNhaCungCap'
ALTER TABLE [dbo].[tblNhaCungCap]
ADD CONSTRAINT [PK_tblNhaCungCap]
    PRIMARY KEY CLUSTERED ([MaNCC] ASC);
GO

-- Creating primary key on [MaCV] in table 'tblChucVu'
ALTER TABLE tblChucVu
ADD CONSTRAINT [PK_tblChucVu]
	PRIMARY KEY CLUSTERED ([MaCV] ASC);
GO

-- Creating primary key on [SoHD] in table 'tblPhieuThanhToan'
ALTER TABLE tblPhieuThanhToan
ADD CONSTRAINT [PK_tblPhieuThanhToan]
	PRIMARY KEY CLUSTERED ([SoHD] ASC);
GO

-- Creating primary key on [SoHD], [MaHH] in table 'tblChiTietPhieuTT'
ALTER TABLE tblChiTietPhieuTT
ADD CONSTRAINT [PK_tblChiTietPhieuTT]
	PRIMARY KEY CLUSTERED ([SoHD], [MaHH] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MaLoai] in table 'tblHang'
ALTER TABLE [dbo].[tblHang]
ADD CONSTRAINT [FK_tblLoaiHangtblHang]
    FOREIGN KEY ([MaLoai])
    REFERENCES [dbo].[tblLoaiHang]
        ([MaLoai])
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [Value] in table 'tblHang'
ALTER TABLE [dbo].[tblHang]
ADD CONSTRAINT [FK_sys_BarcodetblHang]
	FOREIGN KEY ([Value])
	REFERENCES [dbo].[sys_Barcode]
		([seqValue])
	ON DELETE CASCADE ON UPDATE CASCADE;
GO
-- Creating foreign key on [MaNV] in table 'tblHoaDonNhap'
ALTER TABLE [dbo].[tblHoaDonNhap]
ADD CONSTRAINT [FK_tblNhanVientblHoaDonNhap]
    FOREIGN KEY ([MaNV])
    REFERENCES [dbo].[tblNhanVien]
        ([MaNV])
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [MaHDN] in table 'tblChiTietHoaDonNhap'
ALTER TABLE [dbo].[tblChiTietHoaDonNhap]
ADD CONSTRAINT [FK_tblHoaDonNhaptblChiTietHoaDonNhap]
    FOREIGN KEY ([MaHDN])
    REFERENCES [dbo].[tblHoaDonNhap]
        ([MaHDN])
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [MaHH] in table 'tblChiTietHoaDonNhap'
ALTER TABLE [dbo].[tblChiTietHoaDonNhap]
ADD CONSTRAINT [FK_tblHangtblChiTietHoaDonNhap]
    FOREIGN KEY ([MaHH])
    REFERENCES [dbo].[tblHang]
        ([MaHH])
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [MaNV] in table 'tblHoaDonBan'
ALTER TABLE [dbo].[tblHoaDonBan]
ADD CONSTRAINT [FK_tblNhanVientblHoaDonBan]
    FOREIGN KEY ([MaNV])
    REFERENCES [dbo].[tblNhanVien]
        ([MaNV])
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [MaKH] in table 'tblHoaDonBan'
ALTER TABLE [dbo].[tblHoaDonBan]
ADD CONSTRAINT [FK_tblKhachHangtblHoaDonBan]
    FOREIGN KEY ([MaKH])
    REFERENCES [dbo].[tblKhachHang]
        ([MaKH])
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [MaHDB] in table 'tblChiTietHoaDonBan'
ALTER TABLE [dbo].[tblChiTietHoaDonBan]
ADD CONSTRAINT [FK_tblHoaDonBantblChiTietHoaDonBan]
    FOREIGN KEY ([MaHDB])
    REFERENCES [dbo].[tblHoaDonBan]
        ([MaHDB])
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [MaHH] in table 'tblChiTietHoaDonBan'
ALTER TABLE [dbo].[tblChiTietHoaDonBan]
ADD CONSTRAINT [FK_tblHangtblChiTietHoaDonBan]
    FOREIGN KEY ([MaHH])
    REFERENCES [dbo].[tblHang]
        ([MaHH])
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [MaNV] in table 'tblTaiKhoan'
ALTER TABLE [dbo].[tblTaiKhoan]
ADD CONSTRAINT [FK_tblNhanVientblTaiKhoan]
    FOREIGN KEY ([MaNV])
    REFERENCES [dbo].[tblNhanVien]
        ([MaNV])
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [MaNCC] in table 'tblHoaDonNhap'
ALTER TABLE [dbo].[tblHoaDonNhap]
ADD CONSTRAINT [FK_tblNhaCungCaptblHoaDonNhap]
    FOREIGN KEY ([MaNCC])
    REFERENCES [dbo].[tblNhaCungCap]
        ([MaNCC])
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [MaCV] in table 'tblNhanVien'
ALTER TABLE [dbo].[tblNhanVien]
ADD CONSTRAINT [FK_tblChucVutblNhanVien]
	FOREIGN KEY ([MaCV])
	REFERENCES [dbo].[tblChucVu]
		([MaCV])
	ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [SoHD] in table 'tblChiTietPhieuTT'
ALTER TABLE tblChiTietPhieuTT
ADD CONSTRAINT [FK_tblPhieuThanhToantblChiTietPhieuTT]
	FOREIGN KEY ([SoHD])
	REFERENCES tblPhieuThanhToan
		([SoHD])
	ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [MaHH] in table 'tblChiTietPhieuTT'
ALTER TABLE tblChiTietPhieuTT
ADD CONSTRAINT [FK_tblHangtblChiTietPhieuTT]
	FOREIGN KEY ([MaHH])
	REFERENCES tblHang
		([MaHH])
	ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [MaNV] in table 'tblPhieuThanhToan'
ALTER TABLE tblPhieuThanhToan
ADD CONSTRAINT [FK_tblNhanVientblPhieuThanhToan]
	FOREIGN KEY ([MaNV])
	REFERENCES tblNhanVien
		([MaNV])
	ON DELETE CASCADE ON UPDATE CASCADE;
GO
/*===========================================================================================================================================
=======================================================TẠO TRIGGER===========================================================================
=============================================================================================================================================*/

/* Cập nhật số lượng tồn khi thêm chi tiết nhập */
CREATE TRIGGER tr_Tang_SoLuongTon_Nhap ON [dbo].[tblChiTietHoaDonNhap]
FOR INSERT
AS
	UPDATE [dbo].[tblHang] SET [dbo].[tblHang].SoLuongTon = [dbo].[tblHang].SoLuongTon + I.SoLuongNhap
	FROM inserted I WHERE [dbo].[tblHang].MaHH = I.MaHH
GO

/* Cập nhật lại số lượng tồn khi sửa chi tiết nhập */
CREATE TRIGGER tr_Sua_SoLuongTon_Nhap ON [dbo].[tblChiTietHoaDonNhap]
FOR UPDATE 
AS
	UPDATE [dbo].[tblHang] SET [dbo].[tblHang].SoLuongTon = [dbo].[tblHang].SoLuongTon + I.SoLuongNhap - D.SoLuongNhap
	FROM inserted I, deleted D WHERE [dbo].[tblHang].MaHH = I.MaHH AND [dbo].[tblHang].MaHH = D.MaHH
GO

/* Cập nhật lại số lượng tồn khi xoá chi tiết nhập */
CREATE TRIGGER tr_Xoa_SoLuongTon_Nhap ON [dbo].[tblChiTietHoaDonNhap]
FOR DELETE
AS
	UPDATE [dbo].[tblHang] SET [dbo].[tblHang].SoLuongTon = [dbo].[tblHang].SoLuongTon - D.SoLuongNhap
	FROM deleted D WHERE [dbo].[tblHang].MaHH = D.MaHH
GO

--/* Cập nhật số lượng tồn khi thêm chi tiết bán */
--CREATE TRIGGER tr_Giam_SoLuongTon_Ban ON [dbo].[tblChiTietHoaDonBan]
--FOR INSERT
--AS
--		UPDATE [dbo].[tblHang] SET [dbo].[tblHang].SoLuongTon = [dbo].[tblHang].SoLuongTon - I.SoLuongBan
--		FROM inserted I WHERE [dbo].[tblHang].MaHH = I.MaHH
--GO


--/* Cập nhật lại số lượng tồn khi sửa chi tiết bán */
--CREATE TRIGGER tr_Sua_SoLuongTon_Ban ON [dbo].[tblChiTietHoaDonBan]
--FOR UPDATE
--AS
--	UPDATE [dbo].[tblHang] SET [dbo].[tblHang].SoLuongTon = [dbo].[tblHang].SoLuongTon + I.SoLuongBan - D.SoLuongBan
--	FROM inserted I, deleted D WHERE [dbo].[tblHang].MaHH = I.MaHH AND [dbo].[tblHang].MaHH = D.MaHH
--GO

--/* Cập nhật lại số lượng tồn khi xoá chi tiết bán */
--CREATE TRIGGER tr_Xoa_SoLuongTon_Ban ON [dbo].[tblChiTietHoaDonBan]
--FOR DELETE
--AS
--	UPDATE [dbo].[tblHang] SET [dbo].[tblHang].SoLuongTon = [dbo].[tblHang].SoLuongTon + D.SoLuongBan
--	FROM deleted D WHERE [dbo].[tblHang].MaHH = D.MaHH
--GO

/* Cập nhật lại số lượng tồn khi thêm chi tiết bill */
CREATE TRIGGER tr_Giam_SoLuongTon_Bill  ON tblChiTietPhieuTT
FOR INSERT 
AS
	UPDATE [dbo].[tblHang] SET [dbo].[tblHang].SoLuongTon = [dbo].[tblHang].SoLuongTon - I.SoLuongBan
	FROM inserted I WHERE [dbo].[tblHang].MaHH = I.MaHH
GO

/* Cập nhật lại số lượng tồn khi sửa chi tiết bill */
CREATE TRIGGER tr_Sua_SoLuongTon_Bill ON tblChiTietPhieuTT
FOR UPDATE
AS
	UPDATE [dbo].[tblHang] SET [dbo].[tblHang].SoLuongTon = [dbo].[tblHang].SoLuongTon + I.SoLuongBan - D.SoLuongBan
	FROM inserted I, deleted D WHERE [dbo].[tblHang].MaHH = I.MaHH AND [dbo].[tblHang].MaHH = D.MaHH
GO

/* Cập nhật lại số lượng tồn khi xoá chi tiết bill */
CREATE TRIGGER tr_Xoa_SoLuongTon_Bill ON tblChiTietPhieuTT
FOR DELETE
AS
	UPDATE [dbo].[tblHang] SET [dbo].[tblHang].SoLuongTon = [dbo].[tblHang].SoLuongTon + D.SoLuongBan
	FROM deleted D WHERE [dbo].[tblHang].MaHH = D.MaHH
GO
/*===========================================================================================================================================
=======================================================TẠO HÀM KIẾM TRA KẾT NỐI==============================================================
=============================================================================================================================================*/
CREATE PROC sp_kiem_tra_ket_noi
AS
BEGIN
	DECLARE @result BIT
	SET @result=0
	IF OBJECT_ID('[dbo].[tblLoaiHang]') IS NOT NULL
	IF OBJECT_ID('[dbo].[tblKhachHang]') IS NOT NULL
	IF OBJECT_ID('[dbo].[tblNhanVien]') IS NOT NULL
	IF OBJECT_ID('[dbo].[tblHang]') IS NOT NULL
	IF OBJECT_ID('[dbo].[tblTaiKhoan]') IS NOT NULL
	IF OBJECT_ID('[dbo].[tblNhaCungCap]') IS NOT NULL
		SET @result = 1
	SELECT @result
END
GO

/*===========================================================================================================================================
=======================================================TẠO TẠO THỦ TỤC ĐĂNG NHẬP=============================================================
=============================================================================================================================================*/
CREATE PROC sp_dang_nhap
(
	@id VARCHAR(50),
	@mat_khau VARCHAR(50)	
)
AS
SELECT ID, tblTaiKhoan.MaNV,TenNV, tblNhanVien.MaCV, TenCV FROM [dbo].[tblTaiKhoan] inner join [dbo].[tblNhanVien] on [dbo].[tblTaiKhoan].MaNV = [dbo].[tblNhanVien].MaNV inner join tblChucVu on  tblNhanVien.MaCV = tblChucVu.MaCV
WHERE id = @id AND Password = @mat_khau
GO

/*===========================================================================================================================================
===========================================TẠO THỦ TỤC THÊM VÀ CẬP NHẬT CHO HỒ SƠ NHÂN VIÊN==================================================
=============================================================================================================================================*/
CREATE PROC sp_them_nv (
	@ten nvarchar(100),
	@cmnd varchar(12),
	@ngaysinh datetime,
	@phai bit,
	@sdt varchar(10),
	@diachi nvarchar(100),
	@macv varchar(15)
)
AS
BEGIN
	DECLARE @nv_id VARCHAR(10)
	SET @nv_id = (SELECT MAX(MaNV) FROM [dbo].[tblNhanVien])

	DECLARE @so_nv INT

	IF @nv_id IS NULL
		SET @so_nv = 1
	ELSE
		SET @so_nv = CAST(SUBSTRING(@nv_id, 3, LEN(@nv_id)) AS INT) + 1
	
	IF @so_nv < 10
	BEGIN
		SET @nv_id='NV00' + CAST(@so_nv AS CHAR(1))
		
	END
	ELSE
	IF @so_nv < 100
	BEGIN
		SET @nv_id='NV0' + CAST(@so_nv AS CHAR(2))
	END
	ELSE
	IF @so_nv < 1000
	BEGIN
		SET @nv_id='NV' + CAST(@so_nv AS CHAR(2))
	END

	INSERT INTO [dbo].[tblNhanVien]([MaNV],[TenNV],[CMND],[NgaySinh],[Phai],[SDT],[DiaChi],[MaCV]) VALUES (@nv_id, @ten,@cmnd, @ngaysinh, @phai, @sdt, @diachi, @macv)

	SELECT @nv_id
END
GO

CREATE PROC sp_sua_nv(
	@nv_id varchar(15),
	@ten nvarchar(100),
	@cmnd varchar(12),
	@phai bit,
	@ngaysinh datetime,
	@sdt varchar(10),
	@diachi nvarchar(100),
	@macv varchar(15)
)
AS 
BEGIN
	UPDATE dbo.tblNhanVien set TenNV = @ten, CMND = @cmnd, Phai = @phai, SDT = @sdt, NgaySinh = @ngaysinh, DiaChi = @diachi, MaCV = @macv WHERE MaNV = @nv_id
END
GO

/*===========================================================================================================================================
===========================================TẠO THỦ TỤC THÊM VÀ CẬP NHẬT CHO HỒ SƠ KHÁCH HÀNG=================================================
=============================================================================================================================================*/
CREATE PROC sp_them_kh (
	@ten nvarchar(100),
	@sdt varchar(10),
	@diachi nvarchar(100)
)
AS
BEGIN
	DECLARE @kh_id VARCHAR(10)
	SET @kh_id = (SELECT MAX(MaKH) FROM [dbo].[tblKhachHang])

	DECLARE @so_kh INT

	IF @kh_id IS NULL
		SET @so_kh = 1
	ELSE
		SET @so_kh = CAST(SUBSTRING(@kh_id, 3, LEN(@kh_id)) AS INT) + 1
	
	IF @so_kh < 10
	BEGIN
		SET @kh_id='KH0000000' + CAST(@so_kh AS CHAR(1))
		
	END
	ELSE
	IF @so_kh < 100
	BEGIN
		SET @kh_id='KH000000' + CAST(@so_kh AS CHAR(2))
	END
	ELSE
	IF @so_kh < 1000
	BEGIN
		SET @kh_id='KH00000' + CAST(@so_kh AS CHAR(3))
	END
	ELSE
	IF @so_kh < 10000
	BEGIN
		SET @kh_id='KH0000' + CAST(@so_kh AS CHAR(4))
	END
	ELSE
	IF @so_kh < 100000
	BEGIN
		SET @kh_id='KH000' + CAST(@so_kh AS CHAR(5))
	END
	ELSE
	IF @so_kh < 1000000
	BEGIN
		SET @kh_id='KH00' + CAST(@so_kh AS CHAR(6))
	END
	ELSE
	IF @so_kh < 10000000
	BEGIN
		SET @kh_id='KH0' + CAST(@so_kh AS CHAR(7))
	END
	ELSE
	IF @so_kh < 100000000
	BEGIN
		SET @kh_id='KH' + CAST(@so_kh AS CHAR(8))
	END

	INSERT INTO [dbo].[tblKhachHang]([MaKH],[TenKH],[SDT],[DiaChi]) VALUES (@kh_id, @ten, @sdt, @diachi)

	SELECT @kh_id
END
GO

CREATE PROC [dbo].[sp_sua_kh](
	@kh_id varchar(15),
	@ten nvarchar(100),
	@sdt varchar(10),
	@diachi nvarchar(100)
)
AS 
BEGIN
	UPDATE dbo.tblKhachHang set TenKH = @ten, SDT = @sdt, DiaChi = @diachi WHERE MaKH = @kh_id
END
GO