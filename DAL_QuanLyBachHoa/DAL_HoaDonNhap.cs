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
    public class DAL_HoaDonNhap : DBConnect
    {
        public DataTable getHoaDonNhap()
        {
            return GetDataToTable("SELECT MaHDN, TenNV, TenNCC, NgayNhap, TongTien FROM tblHoaDonNhap inner join tblNhanVien on tblHoaDonNhap.MaNV = tblNhanVien.MaNV"
                                            + " inner join tblNhaCungCap on tblHoaDonNhap.MaNCC = tblNhaCungCap.MaNCC ");
        }
        public DataTable timHoaDonNhap(string mahdn)
        {
            return GetDataToTable("SELECT MaHDN, TenNV, TenNCC, NgayNhap, TongTien FROM tblHoaDonNhap inner join tblNhanVien on tblHoaDonNhap.MaNV = tblNhanVien.MaNV"
                                            + " inner join tblNhaCungCap on tblHoaDonNhap.MaNCC = tblNhaCungCap.MaNCC "
                                            + " WHERE MaHDN like N'%" + mahdn + "%' ");
        }

        public DataTable getHoaDonNhap(DateTime tungay, DateTime denngay, string MaNCC, string manv)
        {
            return GetDataToTable("SELECT MaHDN, TenNV, TenNCC, NgayNhap, TongTien FROM tblHoaDonNhap inner join tblNhanVien on tblHoaDonNhap.MaNV = tblNhanVien.MaNV"
                                            + " inner join tblNhaCungCap on tblHoaDonNhap.MaNCC = tblNhaCungCap.MaNCC "
                                            + " WHERE (NgayNhap BETWEEN '" + tungay + "' AND '" + denngay + "') AND tblHoaDonNhap.MaNCC = '" + MaNCC + "' "
                                            + " AND tblHoaDonNhap.MaNV = '" + manv + "'");
        }

        public int themHoaDonNhap(DTO_HoaDonNhap hdn)
        {
            SqlParameter[] parahdn = new SqlParameter[5];
            parahdn[0] = new SqlParameter("@manv", hdn.MaNV);
            parahdn[1] = new SqlParameter("@MaNCC", hdn.MaNCC);
            parahdn[2] = new SqlParameter("@ngaynhap", hdn.NgayNhap);
            parahdn[3] = new SqlParameter("@tongtien", hdn.TongTien);
            parahdn[4] = new SqlParameter("@mahdn", hdn.MaHDN);

            string sql = "INSERT INTO [dbo].[tblHoaDonNhap]([MaHDN],[MaNV],[MaNCC],[NgayNhap],[TongTien]) VALUES (@mahdn, @manv , @MaNCC, @ngaynhap, @tongtien)";

            return RunSQL(sql, CommandType.Text, parahdn);
        }

        public int suaHoaDonNhap(DTO_HoaDonNhap hdn)
        {
            SqlParameter[] parahdn = new SqlParameter[5];
            parahdn[0] = new SqlParameter("@manv", hdn.MaNV);
            parahdn[1] = new SqlParameter("@MaNCC", hdn.MaNCC);
            parahdn[2] = new SqlParameter("@ngaynhap", hdn.NgayNhap);
            parahdn[3] = new SqlParameter("@tongtien", hdn.TongTien);
            parahdn[4] = new SqlParameter("@mahdn", hdn.MaHDN);

            string sql = "UPDATE tblHoaDonNhap SET MaNV = @manv , MaNCC = @MaNCC, NgayNhap = @ngaynhap, TongTien = @tongtien WHERE MaHDN = @mahdn";
            return RunSQL(sql, CommandType.Text, parahdn);
        }
        public int xoaHoaDonNhap(string mahdn)
        {
            SqlParameter[] parahdn = new SqlParameter[1];
            parahdn[0] = new SqlParameter("@mahdn", mahdn);

            string sql = "DELETE FROM tblHoaDonNhap WHERE MaHDN = @mahdn";
            return RunSQL(sql, CommandType.Text, parahdn);
        }

        public int capNhatTongTien(string ma, string tongtien)
        {
            float _tong = 0;

            SqlParameter[] parahdb = new SqlParameter[1];
            parahdb[0] = new SqlParameter("@ma", ma);

            _tong = float.Parse(tongtien);

            string sql = "UPDATE tblHoaDonNhap SET TongTien = " + _tong + " WHERE MaHDN = @ma";
            return RunSQL(sql, CommandType.Text, parahdb);
        }

        public string taoMaHoaDon()
        {
            return CreateKey();
        }
    }
}
