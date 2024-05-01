using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyBachHoa;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace DAL_QuanLyBachHoa
{
    public class DAL_HoaDonBan : DBConnect
    {
        public DataTable getHoaDonBan()
        {
            return GetDataToTable("SELECT tblHoaDonBan.MaHDB, tblNhanVien.TenNV, tblKhachHang.TenKH, tblHoaDonBan.NgayBan, tblHoaDonBan.TongTien "
                                   + " FROM tblHoaDonBan INNER JOIN "
                                   + " tblNhanVien ON tblHoaDonBan.MaNV = tblNhanVien.MaNV INNER JOIN "
                                   + " tblKhachHang ON tblHoaDonBan.MaKH = tblKhachHang.MaKH");
        }
        public DataTable getHoaDonBan(DateTime tungay, DateTime denngay, string makh, string manv)
        {
            return GetDataToTable("SELECT tblHoaDonBan.MaHDB, tblNhanVien.TenNV, tblKhachHang.TenKH, tblHoaDonBan.NgayBan, tblHoaDonBan.TongTien "
                                   + " FROM tblHoaDonBan INNER JOIN "
                                   + " tblNhanVien ON tblHoaDonBan.MaNV = tblNhanVien.MaNV INNER JOIN "
                                   + " tblKhachHang ON tblHoaDonBan.MaKH = tblKhachHang.MaKH"
                                   + " WHERE (NgayBan BETWEEN '"+ tungay +"' AND '"+ denngay + "') AND  tblNhanVien.MaNV = '"+ manv +"'"
                                   + " AND tblKhachHang.MaKH = '"+ makh +"'");
        }
        public DataTable timHoaDonBan(string ma)
        {
            return GetDataToTable("SELECT tblHoaDonBan.MaHDB, tblNhanVien.TenNV, tblKhachHang.TenKH, tblHoaDonBan.NgayBan, tblHoaDonBan.TongTien "
                                   + " FROM tblHoaDonBan INNER JOIN "
                                   + " tblNhanVien ON tblHoaDonBan.MaNV = tblNhanVien.MaNV INNER JOIN "
                                   + " tblKhachHang ON tblHoaDonBan.MaKH = tblKhachHang.MaKH"
                                   + " WHERE MaHDB = '"+ ma +"'");
        }
        public int themHoaDonBan(DTO_HoaDonBan hdb)
        {
            SqlParameter[] parahdb = new SqlParameter[5];
            parahdb[0] = new SqlParameter("@manv", hdb.MaNV);
            parahdb[1] = new SqlParameter("@makh", hdb.MaKH);
            parahdb[2] = new SqlParameter("@ngayban", hdb.NgayBan);
            parahdb[3] = new SqlParameter("@tongtien", hdb.TongTien);
            parahdb[4] = new SqlParameter("@mahdb", hdb.MaHDB);

            string sql = "INSERT INTO [dbo].[tblHoaDonBan]([MaHDB],[MaNV],[MaKH],[NgayBan],[TongTien]) VALUES (@mahdb,@manv, @makh, @ngayban, @tongtien)";
            return RunSQL(sql, CommandType.Text, parahdb);
        }

        public int suaHoaDonBan(DTO_HoaDonBan hdb)
        {
            SqlParameter[] parahdb = new SqlParameter[5];
            parahdb[0] = new SqlParameter("@manv", hdb.MaNV);
            parahdb[1] = new SqlParameter("@makh", hdb.MaKH);
            parahdb[2] = new SqlParameter("@ngayban", hdb.NgayBan);
            parahdb[3] = new SqlParameter("@tongtien", hdb.TongTien);
            parahdb[4] = new SqlParameter("@mahdb", hdb.MaHDB);

            string sql = "UPDATE tblHoaDonBan SET MaNV = @manv, MaKH = @makh, NgayBan = @ngayban, TongTien = @tongtien WHERE MaHDB = @mahdb";
            return RunSQL(sql, CommandType.Text, parahdb);
        }

        public int xoaHoaDonBan(string mahdb)
        {
            SqlParameter[] parahdb = new SqlParameter[1];
            parahdb[0] = new SqlParameter("@mahdb", mahdb);

            string sql = "DELETE FROM tblHoaDonBan WHERE MaHDB = @mahdb";
            return RunSQL(sql, CommandType.Text, parahdb);
        }

        public int capNhatTongTien(string ma , string tongtien)
        {
            float _tong = 0;

            SqlParameter[] parahdb = new SqlParameter[1];
            parahdb[0] = new SqlParameter("@ma", ma);

            _tong = float.Parse(tongtien);

            string sql = "UPDATE tblHoaDonBan SET TongTien = " + _tong + " WHERE MaHDB = @ma";
            return RunSQL(sql, CommandType.Text, parahdb);
        }
        public string taoMaHoaDon()
        {
            return CreateKey();
        }
    }
}
