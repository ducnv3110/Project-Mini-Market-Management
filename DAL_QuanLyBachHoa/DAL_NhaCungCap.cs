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
    public class DAL_NhaCungCap : DBConnect
    {
        public DataTable getNhaCungCap()
        {
            return GetDataToTable("SELECT * FROM tblNhaCungCap");
        }
        public DataTable timNhaCungCap(string TenNCC)
        {
            return GetDataToTable("SELECT * FROM tblNhaCungCap WHERE TenNCC like N'%"+ TenNCC +"%'");
        }
        public int themNhaCungCap(DTO_NhaCungCap nhacc)
        {
            SqlParameter[] paranhacc = new SqlParameter[3];
            paranhacc[0] = new SqlParameter("@MaNCC", nhacc.MaNCC);
            paranhacc[1] = new SqlParameter("@TenNCC", nhacc.TenNCC);
            paranhacc[2] = new SqlParameter("@diachi", nhacc.DiaChi);

            string sql = "INSERT INTO [dbo].[tblNhaCungCap]([MaNCC],[TenNCC],[DiaChi]) VALUES (@MaNCC, @TenNCC, @diachi)";
            return RunSQL(sql, CommandType.Text, paranhacc);

        }
        public bool kiemTraTrungMa(string ma)
        {
            string sql = "SELECT MaNCC FROM tblNhaCungCap WHERE MaNCC = '" + ma + "'";

            if (CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã nhập rồi.\nVui lòng nhập mã khác!!!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public int suaNhaCungCap(DTO_NhaCungCap nhacc)
        {
            SqlParameter[] paranhacc = new SqlParameter[3];
            paranhacc[0] = new SqlParameter("@MaNCC", nhacc.MaNCC);
            paranhacc[1] = new SqlParameter("@TenNCC", nhacc.TenNCC);
            paranhacc[2] = new SqlParameter("@diachi", nhacc.DiaChi);

            string sql = "UPDATE tblNhaCungCap SET TenNCC = @TenNCC , DiaChi = @diachi WHERE MaNCC = @MaNCC";
            return RunSQL(sql, CommandType.Text, paranhacc);
        }

        public int xoaNhaCungCap(string MaNCC)
        {
            SqlParameter[] paranhacc = new SqlParameter[1];
            paranhacc[0] = new SqlParameter("@MaNCC", MaNCC);

            string sql = "DELETE FROM tblNhaCungCap WHERE MaNCC = @MaNCC";
            return RunSQL(sql, CommandType.Text, paranhacc);
        }

        
    }
}
