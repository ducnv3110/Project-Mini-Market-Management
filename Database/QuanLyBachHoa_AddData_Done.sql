-- --------------------------------------------------
-- Insert data in all table
-- --------------------------------------------------
use QLBachHoa
-- Insert data in tblLoaiHang
INSERT INTO [dbo].[tblLoaiHang]([MaLoai],[TenLoai]) VALUES ('THIT',N'Thịt')
INSERT INTO [dbo].[tblLoaiHang]([MaLoai],[TenLoai]) VALUES ('CA',N'Cá')
INSERT INTO [dbo].[tblLoaiHang]([MaLoai],[TenLoai]) VALUES ('TRUNG',N'Trứng')
INSERT INTO [dbo].[tblLoaiHang]([MaLoai],[TenLoai]) VALUES ('RAU',N'Rau , Củ , Trái Cây')
INSERT INTO [dbo].[tblLoaiHang]([MaLoai],[TenLoai]) VALUES ('DONG',N'Hàng đông mát')
INSERT INTO [dbo].[tblLoaiHang]([MaLoai],[TenLoai]) VALUES ('KHO',N'Thực phẩm đóng zip, hộp')
INSERT INTO [dbo].[tblLoaiHang]([MaLoai],[TenLoai]) VALUES ('SUA',N'Sữa')
INSERT INTO [dbo].[tblLoaiHang]([MaLoai],[TenLoai]) VALUES ('BIA',N'Bia')
INSERT INTO [dbo].[tblLoaiHang]([MaLoai],[TenLoai]) VALUES ('NUOC',N'Nước lọc, giải khát')
INSERT INTO [dbo].[tblLoaiHang]([MaLoai],[TenLoai]) VALUES ('BANH',N'Bánh')
INSERT INTO [dbo].[tblLoaiHang]([MaLoai],[TenLoai]) VALUES ('KEO',N'Kẹo')

-- Insert data in tblNhaCungCap
INSERT INTO [dbo].[tblNhaCungCap]([MaNCC],[TenNCC],[DiaChi]) VALUES('TPCD',N'Công ty TNHH MTV SX TM Thực Phẩm Công Danh',N'Lô A4- Đường NB, Cụm Nhị Xuân, X. Xuân Thới Sơn, H. Hóc Môn Tp. Hồ Chí Minh (TPHCM)')
INSERT INTO [dbo].[tblNhaCungCap]([MaNCC],[TenNCC],[DiaChi]) VALUES('TPDA',N'Công ty TNHH Xuất Nhập Khẩu Thực Phẩm Duy Anh',N'368/4 Tỉnh Lộ 15, Ấp Bến Cỏ, X. Phú Hòa Đông, H. Củ Chi, Tp. Hồ Chí Minh (TPHCM)')
INSERT INTO [dbo].[tblNhaCungCap]([MaNCC],[TenNCC],[DiaChi]) VALUES('TPTT',N'Công ty TNHH Phân Phối Thực Phẩm Trường Thịnh',N'Ô Vựa B3 - 031 Chợ Đầu Mối Nông Sản Thực Phẩm Bình Điền, Đường Nguyễn Văn Linh, Tp. Hồ Chí Minh')
INSERT INTO [dbo].[tblNhaCungCap]([MaNCC],[TenNCC],[DiaChi]) VALUES('TPAF',N'ANAN FOOD - Công ty Cổ Phần Thực Phẩm KB',N'Số 99, Đường Số 6, P. Long Bình, Thành Phố Thủ Đức, Tp. Hồ Chí Minh (TPHCM)')
INSERT INTO [dbo].[tblNhaCungCap]([MaNCC],[TenNCC],[DiaChi]) VALUES('TPPAT',N'Công Ty TNHH SX TM  DV Phát Anh Tiến',N'280/41 Cách Mạng Tháng Tám, P. 10, Q. 3, Tp. Hồ Chí Minh (TPHCM)')

--Insert data in tblChucVu
INSERT INTO [dbo].[tblChucVu]([MaCV],[TenCV]) VALUES ('QLK', N'Quản lý kho')
INSERT INTO [dbo].[tblChucVu]([MaCV],[TenCV]) VALUES ('TN', N'Thu ngân')
INSERT INTO [dbo].[tblChucVu]([MaCV],[TenCV]) VALUES ('KT', N'Kế toán')
INSERT INTO [dbo].[tblChucVu]([MaCV],[TenCV]) VALUES ('ADM', N'Quản trị viên')
INSERT INTO [dbo].[tblChucVu]([MaCV],[TenCV]) VALUES ('NV', N'Nhân viên')

-- Insert data in tblKhachHang
INSERT INTO [dbo].[tblKhachHang]([MaKH],[TenKH],[SDT],[DiaChi]) VALUES ('KH00000001',N'Nguyễn Vũ Đức','1234567891',N'Long Thành')
INSERT INTO [dbo].[tblKhachHang]([MaKH],[TenKH],[SDT],[DiaChi]) VALUES ('KH00000002',N'Phùng Thanh Độ','1324567891',N'Cao Bằng')
INSERT INTO [dbo].[tblKhachHang]([MaKH],[TenKH],[SDT],[DiaChi]) VALUES ('KH00000003',N'Trần Tiến','1423567891',N'Sài Gòn')
INSERT INTO [dbo].[tblKhachHang]([MaKH],[TenKH],[SDT],[DiaChi]) VALUES ('KH00000004',N'Hoàng Văn Khoa','1523467891',N'Hải Phòng')
INSERT INTO [dbo].[tblKhachHang]([MaKH],[TenKH],[SDT],[DiaChi]) VALUES ('KH00000005',N'Mai Nam Tiến','1623457891',N'Sài Gòn')

-- Insert data in tblNhanVien
INSERT INTO [dbo].[tblNhanVien]([MaNV],[TenNV],[CMND],[NgaySinh],[Phai],[SDT],[DiaChi],[MaCV]) VALUES ('NV000',N'Nguyễn Vũ Đức','123456789012','2001-10-31',0,'1523467891',N'Đồng Nai','ADM')
INSERT INTO [dbo].[tblNhanVien]([MaNV],[TenNV],[CMND],[NgaySinh],[Phai],[SDT],[DiaChi],[MaCV]) VALUES ('NV001',N'Đỗ Phước An','123456789021','1999-12-27',0,'1234567891',N'Đồng Nai','QLK')
INSERT INTO [dbo].[tblNhanVien]([MaNV],[TenNV],[CMND],[NgaySinh],[Phai],[SDT],[DiaChi],[MaCV]) VALUES ('NV002',N'Vũ Thị Ngọc Ánh','123456789102','2000-01-28',1,'1324567891',N'DakLak','KT')
INSERT INTO [dbo].[tblNhanVien]([MaNV],[TenNV],[CMND],[NgaySinh],[Phai],[SDT],[DiaChi],[MaCV]) VALUES ('NV003',N'Nguyễn Đại Cảnh','123456789120','1999-10-27',0,'1423567891',N'Đồng Nai','NV')
INSERT INTO [dbo].[tblNhanVien]([MaNV],[TenNV],[CMND],[NgaySinh],[Phai],[SDT],[DiaChi],[MaCV]) VALUES ('NV004',N'Nguyễn Thị Gấm','123456789011','1999-03-11',1,'1623457891',N'An Giang','TN')

--Insert data in tblTaiKhoan
INSERT INTO [dbo].[tblTaiKhoan]([ID],[MaNV],[Password]) VALUES ('QLK_1','NV001','123')
INSERT INTO [dbo].[tblTaiKhoan]([ID],[MaNV],[Password]) VALUES ('KT_1','NV002','123')
INSERT INTO [dbo].[tblTaiKhoan]([ID],[MaNV],[Password]) VALUES ('admin','NV000','admin')
INSERT INTO [dbo].[tblTaiKhoan]([ID],[MaNV],[Password]) VALUES ('TN_1','NV004','123')

--Insert data in sys_Barcode
INSERT INTO [dbo].[sys_Barcode]([seqValue],[seqName]) VALUES(1,'HH')
INSERT INTO [dbo].[sys_Barcode]([seqValue],[seqName]) VALUES(2,'HH')
INSERT INTO [dbo].[sys_Barcode]([seqValue],[seqName]) VALUES(3,'HH')
INSERT INTO [dbo].[sys_Barcode]([seqValue],[seqName]) VALUES(4,'HH')
INSERT INTO [dbo].[sys_Barcode]([seqValue],[seqName]) VALUES(5,'HH')
INSERT INTO [dbo].[sys_Barcode]([seqValue],[seqName]) VALUES(6,'HH')
INSERT INTO [dbo].[sys_Barcode]([seqValue],[seqName]) VALUES(7,'HH')
INSERT INTO [dbo].[sys_Barcode]([seqValue],[seqName]) VALUES(8,'HH')
INSERT INTO [dbo].[sys_Barcode]([seqValue],[seqName]) VALUES(9,'HH')
INSERT INTO [dbo].[sys_Barcode]([seqValue],[seqName]) VALUES(10,'HH')

--Insert data in tblHang
INSERT INTO [dbo].[tblHang]([MaHH],[MaLoai],[TenHH],[DVT],[SoLuongTon],[DonGiaNhap],[DonGiaBan],[NgaySanXuat],[NgayHetHan],[BaoQuan],[HinhMinhHoa],[Value],[VAT]) VALUES ('8932022000015','THIT',N'Vai bò Úc tươi Trung Đồng hút chân không ',N'Khay(250g)',0,80000,105000,'2022-02-15','2022-03-15',N'Từ 0-5 độ C','vai-bo-uc-tuoi-hut-chan-khong-khay-250g.jpg',1,0)
INSERT INTO [dbo].[tblHang]([MaHH],[MaLoai],[TenHH],[DVT],[SoLuongTon],[DonGiaNhap],[DonGiaBan],[NgaySanXuat],[NgayHetHan],[BaoQuan],[HinhMinhHoa],[Value],[VAT]) VALUES ('8932022000022','THIT',N'Gầu bò Úc tươi Trung Đồng hút chân không',N'Khay(250g)',0,75000,89000,'2022-02-15','2022-03-15',N'Từ 0-5 độ C','gau-bo-uc-tuoi-trung-dong-hut-chan-khong.jpg',2,0)
INSERT INTO [dbo].[tblHang]([MaHH],[MaLoai],[TenHH],[DVT],[SoLuongTon],[DonGiaNhap],[DonGiaBan],[NgaySanXuat],[NgayHetHan],[BaoQuan],[HinhMinhHoa],[Value],[VAT]) VALUES ('8932022000039','THIT',N'Thịt heo xay xẵn C.P',N'Khay(300g)',0,30000,34500,'2022-02-10','2022-02-20',N'Từ 0-4 độ C','thit-heo-xay-cp-khay-300g.jpg',3,0)
INSERT INTO [dbo].[tblHang]([MaHH],[MaLoai],[TenHH],[DVT],[SoLuongTon],[DonGiaNhap],[DonGiaBan],[NgaySanXuat],[NgayHetHan],[BaoQuan],[HinhMinhHoa],[Value],[VAT]) VALUES ('8932022000046','THIT',N'Cốt lết heo có xương',N'Khay(300g)',0,30000,37500,'2022-02-10','2022-02-13',N'Từ 0-4 độ C','cot-let-heo-co-xuong-g-khay-300g-4-6-mieng.jpg',4,0)
INSERT INTO [dbo].[tblHang]([MaHH],[MaLoai],[TenHH],[DVT],[SoLuongTon],[DonGiaNhap],[DonGiaBan],[NgaySanXuat],[NgayHetHan],[BaoQuan],[HinhMinhHoa],[Value],[VAT]) VALUES ('8932022000053','THIT',N'Xương gà',N'Gói (1kg)',0,24000,29000,'2022-02-09','2022-02-15',N'Từ 0-4 độ C','xuong-ga-cp-goi-1kg.jpg',5,0)
INSERT INTO [dbo].[tblHang]([MaHH],[MaLoai],[TenHH],[DVT],[SoLuongTon],[DonGiaNhap],[DonGiaBan],[NgaySanXuat],[NgayHetHan],[BaoQuan],[HinhMinhHoa],[Value],[VAT]) VALUES ('8932022000060','CA',N'Lườn cá hồi đông lạnh',N'Túi (300g)',0,20000,39000,'2022-02-27','2022-03-05',N'Từ 0-4 độ C','luon-ca-hoi-dong-lanh-tran-gia-khay-500g-.jpg',6,0)
INSERT INTO [dbo].[tblHang]([MaHH],[MaLoai],[TenHH],[DVT],[SoLuongTon],[DonGiaNhap],[DonGiaBan],[NgaySanXuat],[NgayHetHan],[BaoQuan],[HinhMinhHoa],[Value],[VAT]) VALUES ('8932022000077','CA',N'Đầu cá hồi tươi',N'Khay (500g)',0,40000,59000,'2022-02-27','2022-03-10',N'Từ 0-4 độ C','dau-ca-hoi-khay-500g-300g-500g-cai.jpg',7,0)
INSERT INTO [dbo].[tblHang]([MaHH],[MaLoai],[TenHH],[DVT],[SoLuongTon],[DonGiaNhap],[DonGiaBan],[NgaySanXuat],[NgayHetHan],[BaoQuan],[HinhMinhHoa],[Value],[VAT]) VALUES ('8932022000084','TRUNG',N'Trứng gà tươi',N'Hộp (10 trứng)',0,19000,30000,'2022-03-01','2022-03-31',N'Từ 7-10 độ C','hop-10-trung-ga-tuoi-4kfarm.jpg',8,0)
INSERT INTO [dbo].[tblHang]([MaHH],[MaLoai],[TenHH],[DVT],[SoLuongTon],[DonGiaNhap],[DonGiaBan],[NgaySanXuat],[NgayHetHan],[BaoQuan],[HinhMinhHoa],[Value],[VAT]) VALUES ('8932022000091','TRUNG',N'Trứng gà ta',N'Hộp (6 trứng)',0,15000,22000,'2022-03-01','2022-03-13',N'Nơi khô ráo thoáng mát','hop-6-trung-ga-ta-tfood-6-trung.jpg',9,0)
INSERT INTO [dbo].[tblHang]([MaHH],[MaLoai],[TenHH],[DVT],[SoLuongTon],[DonGiaNhap],[DonGiaBan],[NgaySanXuat],[NgayHetHan],[BaoQuan],[HinhMinhHoa],[Value],[VAT]) VALUES ('8932022000107','BIA',N'Bia Tiger Crystal 330ml',N'Thùng (24 lon)',0,300000,410000,'2022-01-01','2022-12-01',N'','thung-24-lon-bia-tiger-crystal-330ml.jpg',10,0)

--Insert data in tblHoaDonNhap
INSERT INTO [dbo].[tblHoaDonNhap]([MaHDN],[MaNV],[MaNCC],[NgayNhap],[TongTien]) VALUES ('1','NV001','TPCD','2022-02-16',535000)
INSERT INTO [dbo].[tblHoaDonNhap]([MaHDN],[MaNV],[MaNCC],[NgayNhap],[TongTien]) VALUES ('2','NV001','TPTT','2022-02-11',348000)
INSERT INTO [dbo].[tblHoaDonNhap]([MaHDN],[MaNV],[MaNCC],[NgayNhap],[TongTien]) VALUES ('3','NV001','TPDA','2022-02-28',180000)
INSERT INTO [dbo].[tblHoaDonNhap]([MaHDN],[MaNV],[MaNCC],[NgayNhap],[TongTien]) VALUES ('4','NV001','TPDA','2022-01-02',900000)
INSERT INTO [dbo].[tblHoaDonNhap]([MaHDN],[MaNV],[MaNCC],[NgayNhap],[TongTien]) VALUES ('5','NV001','TPPAT','2022-03-02',68000)

--Insert data in tblChiTietHoaDonNhap
INSERT INTO [dbo].[tblChiTietHoaDonNhap]([MaHDN],[MaHH],[SoLuongNhap],[DonGiaNhap],[ThanhTien]) VALUES ('1','8932022000015',2,80000,160000)
INSERT INTO [dbo].[tblChiTietHoaDonNhap]([MaHDN],[MaHH],[SoLuongNhap],[DonGiaNhap],[ThanhTien]) VALUES ('1','8932022000022',5,75000,375000)
INSERT INTO [dbo].[tblChiTietHoaDonNhap]([MaHDN],[MaHH],[SoLuongNhap],[DonGiaNhap],[ThanhTien]) VALUES ('2','8932022000039',5,30000,150000)
INSERT INTO [dbo].[tblChiTietHoaDonNhap]([MaHDN],[MaHH],[SoLuongNhap],[DonGiaNhap],[ThanhTien]) VALUES ('2','8932022000046',5,30000,150000)
INSERT INTO [dbo].[tblChiTietHoaDonNhap]([MaHDN],[MaHH],[SoLuongNhap],[DonGiaNhap],[ThanhTien]) VALUES ('2','8932022000053',2,24000,48000)
INSERT INTO [dbo].[tblChiTietHoaDonNhap]([MaHDN],[MaHH],[SoLuongNhap],[DonGiaNhap],[ThanhTien]) VALUES ('3','8932022000060',3,20000,60000)
INSERT INTO [dbo].[tblChiTietHoaDonNhap]([MaHDN],[MaHH],[SoLuongNhap],[DonGiaNhap],[ThanhTien]) VALUES ('3','8932022000077',3,40000,120000)
INSERT INTO [dbo].[tblChiTietHoaDonNhap]([MaHDN],[MaHH],[SoLuongNhap],[DonGiaNhap],[ThanhTien]) VALUES ('4','8932022000107',3,300000,900000)
INSERT INTO [dbo].[tblChiTietHoaDonNhap]([MaHDN],[MaHH],[SoLuongNhap],[DonGiaNhap],[ThanhTien]) VALUES ('5','8932022000084',2,19000,38000)
INSERT INTO [dbo].[tblChiTietHoaDonNhap]([MaHDN],[MaHH],[SoLuongNhap],[DonGiaNhap],[ThanhTien]) VALUES ('5','8932022000091',2,15000,30000)

--Insert data in tblHoaDonBan
INSERT INTO [dbo].[tblHoaDonBan]([MaHDB],[MaNV],[MaKH],[NgayBan],[TongTien]) VALUES ('1','NV002','KH00000002','2022-02-18',299000)
INSERT INTO [dbo].[tblHoaDonBan]([MaHDB],[MaNV],[MaKH],[NgayBan],[TongTien]) VALUES ('2','NV002','KH00000002','2022-02-12',72000)
INSERT INTO [dbo].[tblHoaDonBan]([MaHDB],[MaNV],[MaKH],[NgayBan],[TongTien]) VALUES ('3','NV002','KH00000001','2022-03-01',98000)
INSERT INTO [dbo].[tblHoaDonBan]([MaHDB],[MaNV],[MaKH],[NgayBan],[TongTien]) VALUES ('4','NV002','KH00000004','2022-05-05',820000)
INSERT INTO [dbo].[tblHoaDonBan]([MaHDB],[MaNV],[MaKH],[NgayBan],[TongTien]) VALUES ('5','NV002','KH00000005','2022-03-09',104000)

--Insert data in tblChiTietHoaDonBan
INSERT INTO [dbo].[tblChiTietHoaDonBan]([MaHDB],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('1','8932022000015',2,105000,210000)
INSERT INTO [dbo].[tblChiTietHoaDonBan]([MaHDB],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('1','8932022000022',1,89000,89000)
INSERT INTO [dbo].[tblChiTietHoaDonBan]([MaHDB],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('2','8932022000039',1,34500,34500)
INSERT INTO [dbo].[tblChiTietHoaDonBan]([MaHDB],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('2','8932022000046',1,37500,37500)
INSERT INTO [dbo].[tblChiTietHoaDonBan]([MaHDB],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('3','8932022000060',1,39000,39000)
INSERT INTO [dbo].[tblChiTietHoaDonBan]([MaHDB],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('3','8932022000077',1,59000,59000)
INSERT INTO [dbo].[tblChiTietHoaDonBan]([MaHDB],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('4','8932022000107',2,410000,820000)
INSERT INTO [dbo].[tblChiTietHoaDonBan]([MaHDB],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('5','8932022000084',2,30000,60000)
INSERT INTO [dbo].[tblChiTietHoaDonBan]([MaHDB],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('5','8932022000091',2,22000,44000)


--Insert data in tblPhieuThanhToan
INSERT INTO [dbo].[tblPhieuThanhToan]([SoHD],[MaNV],[NgayBan],[TongTien]) VALUES ('1','NV002','2022-02-18',299000)
INSERT INTO [dbo].[tblPhieuThanhToan]([SoHD],[MaNV],[NgayBan],[TongTien]) VALUES ('2','NV002','2022-02-12',72000)
INSERT INTO [dbo].[tblPhieuThanhToan]([SoHD],[MaNV],[NgayBan],[TongTien]) VALUES ('3','NV002','2022-03-01',98000)
INSERT INTO [dbo].[tblPhieuThanhToan]([SoHD],[MaNV],[NgayBan],[TongTien]) VALUES ('4','NV002','2022-05-05',820000)
INSERT INTO [dbo].[tblPhieuThanhToan]([SoHD],[MaNV],[NgayBan],[TongTien]) VALUES ('5','NV002','2022-03-09',104000)

--Insert data in tblChiTietPhieuThanhToan
INSERT INTO [dbo].[tblChiTietPhieuTT] ([SoHD],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('1','8932022000015',2,105000,210000)
INSERT INTO [dbo].[tblChiTietPhieuTT] ([SoHD],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('1','8932022000022',1,89000,89000)
INSERT INTO [dbo].[tblChiTietPhieuTT] ([SoHD],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('2','8932022000039',1,34500,34500)
INSERT INTO [dbo].[tblChiTietPhieuTT] ([SoHD],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('2','8932022000046',1,37500,37500)
INSERT INTO [dbo].[tblChiTietPhieuTT] ([SoHD],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('3','8932022000060',1,39000,39000)
INSERT INTO [dbo].[tblChiTietPhieuTT] ([SoHD],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('3','8932022000077',1,59000,59000)
INSERT INTO [dbo].[tblChiTietPhieuTT] ([SoHD],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('4','8932022000107',2,410000,820000)
INSERT INTO [dbo].[tblChiTietPhieuTT] ([SoHD],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('5','8932022000084',2,30000,60000)
INSERT INTO [dbo].[tblChiTietPhieuTT] ([SoHD],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES ('5','8932022000091',2,22000,44000)

