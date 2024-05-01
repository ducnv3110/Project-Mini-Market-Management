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
    public class DAL_KhachHang : DBConnect
    {
        public DataTable getKhachHang()
        {
            return GetDataToTable("SELECT * FROM tblKhachHang");
        }
        public DataTable timKhachHang(string tenKH)
        {
            return GetDataToTable("SELECT * FROM tblKhachHang WHERE TenKH like N'%"+ tenKH +"%'");
        }
        public int themKhachHang(DTO_KhachHang kh)
        {
            SqlParameter[] parakh = new SqlParameter[3];
            parakh[0] = new SqlParameter("@ten", kh.TenKH);
            parakh[1] = new SqlParameter("@sdt", kh.SDT);
            parakh[2] = new SqlParameter("@diachi", kh.DiaChi);

            string sql = "sp_them_kh";
            return RunSQL(sql, CommandType.StoredProcedure, parakh);
        }

        public int xoaKhachHang(string makh)
        {
            SqlParameter[] parakh = new SqlParameter[1];
            parakh[0] = new SqlParameter("@makh", makh);

            string sql = "DELETE FROM tblKhachHang WHERE MaKH = @makh";
            return RunSQL(sql, CommandType.Text, parakh);
        }

        public int suaKhachHang(DTO_KhachHang kh)
        {
            SqlParameter[] parakh = new SqlParameter[5];
            parakh[0] = new SqlParameter("@kh_id", kh.MaKH);
            parakh[1] = new SqlParameter("@ten", kh.TenKH);
            parakh[2] = new SqlParameter("@sdt", kh.SDT);
            parakh[3] = new SqlParameter("@diachi", kh.DiaChi);

            string sql = "sp_sua_kh";
            return RunSQL(sql, CommandType.StoredProcedure, parakh);
        }
    }
}
