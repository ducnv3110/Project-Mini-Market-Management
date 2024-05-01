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
    public class DAL_TaiKhoan : DBConnect
    {
        public DataTable getLogin()
        {
            return GetDataToTable("SELECT ID, Password, TenNV FROM tblTaiKhoan inner join tblNhanVien on tblTaiKhoan.MaNV = tblNhanVien.MaNV");
        }
        public DataTable timLogin(string tennv)
        {
            return GetDataToTable("SELECT ID, Password, TenNV FROM tblTaiKhoan inner join tblNhanVien on tblTaiKhoan.MaNV = tblNhanVien.MaNV"
                                    +" WHERE TenNV like N'%"+ tennv +"%'");
        }
        public int themLogin(DTO_TaiKhoan l)
        {
            SqlParameter[] paralogin = new SqlParameter[3];
            paralogin[0] = new SqlParameter("@id", l.ID);
            paralogin[1] = new SqlParameter("@mk", l.Password);
            paralogin[2] = new SqlParameter("@manv", l.MaNV);
            

            string sql = "SELECT ID FROM tblTaiKhoan WHERE ID = '" + l.ID + "'";
            if (CheckKey(sql))
            {
                MessageBox.Show("Mã ID này đã nhập rồi.\nVui lòng nhập mã khác!!!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            else
            {
                sql = "INSERT INTO [dbo].[tblTaiKhoan]([ID],[MaNV],[Password]) VALUES (@id, @manv, @mk)";
                return RunSQL(sql, CommandType.Text, paralogin);
            }
                
        }
        public int xoaLogin(string id)
        {
            SqlParameter[] paralogin = new SqlParameter[1];
            paralogin[0] = new SqlParameter("@id", id);

            string sql = "DELETE FROM tblTaiKhoan WHERE ID = @id";
            return RunSQL(sql, CommandType.Text, paralogin);
        }

        public int suaLogin(DTO_TaiKhoan l)
        {
            SqlParameter[] paralogin = new SqlParameter[2];
            paralogin[0] = new SqlParameter("@id", l.ID);
            paralogin[1] = new SqlParameter("@mk", l.Password);
            

            string sql = "UPDATE tblTaiKhoan SET Password = @mk WHERE ID = @id";
            return RunSQL(sql, CommandType.Text, paralogin);
        }
    }
}
