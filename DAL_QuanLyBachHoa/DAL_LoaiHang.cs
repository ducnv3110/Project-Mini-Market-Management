using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyBachHoa;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL_QuanLyBachHoa
{
    public class DAL_LoaiHang : DBConnect
    {
        public DataTable getLoaiHang()
        {
            return GetDataToTable("SELECT MaLoai, TenLoai FROM tblLoaiHang");
        }
        public DataTable timLoaiHang(string tenloai)
        {
            return GetDataToTable("SELECT * FROM tblLoaiHang WHERE TenLoai like N'%"+ tenloai +"%'"); 
        }
        public int themLoaiHang(DTO_LoaiHang lh)
        {
            
            SqlParameter[] paraLoaiHang = new SqlParameter[2];
            paraLoaiHang[0] = new SqlParameter("@maloai", lh.MaLoai);
            paraLoaiHang[1] = new SqlParameter("@tenloai", lh.TenLoai);
            
            string sql = "SELECT MaLoai FROM tblLoaiHang WHERE MaLoai = '"+ lh.MaLoai +"'";
            if (CheckKey(sql)) 
            {
                MessageBox.Show("Mã loại hàng này đã nhập rồi.\nVui lòng nhập mã loại khác!!!","Chú ý",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return 0;
            }
            else
            {
                sql = "INSERT INTO [dbo].[tblLoaiHang]([MaLoai],[TenLoai]) VALUES( @maloai, @tenloai)";
                return RunSQL(sql, CommandType.Text, paraLoaiHang);
            }
           
        }

        public int xoaLoaiHang(string maloai)
        {
            SqlParameter[] paraLoaiHang = new SqlParameter[1];
            paraLoaiHang[0] = new SqlParameter("@maloai", maloai);

            string sql = "DELETE FROM tblLoaiHang WHERE MaLoai = @maloai";
            return RunSQL(sql, CommandType.Text, paraLoaiHang);
        }

        public int suaLoaiHang(DTO_LoaiHang lh)
        {
            SqlParameter[] paraLoaiHang = new SqlParameter[2];
            paraLoaiHang[0] = new SqlParameter("@maloai", lh.MaLoai);
            paraLoaiHang[1] = new SqlParameter("@tenloai", lh.TenLoai);

            string sql = "UPDATE tblLoaiHang SET TenLoai = @tenloai WHERE MaLoai = @maloai";
            return RunSQL(sql, CommandType.Text, paraLoaiHang);
        }
    }
}
