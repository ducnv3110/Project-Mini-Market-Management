using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyBachHoa;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Collections.ObjectModel;
namespace DAL_QuanLyBachHoa
{
    public class DAL_ChucVu:DBConnect
    {
        private ObservableCollection<DTO_ChucVu> _List;
        public DataTable getChucVu()
        {
            return GetDataToTable("SELECT * FROM tblChucVu");
        }
        public DataTable timChucVu(string tencv)
        {
            return GetDataToTable("SELECT * FROM tblChucVu WHERE TenCV like N'%"+ tencv +"%'");
        }

        public ObservableCollection<DTO_ChucVu> TestGetAll()
        {
            return new ObservableCollection<DTO_ChucVu>(getChucVu().AsEnumerable().Where(p => !string.IsNullOrEmpty(p[0].ToString().Trim())).ToList().Cast<DTO_ChucVu>());
        }
        public int themChucVu(DTO_ChucVu cv)
        {
            SqlParameter[] paracv = new SqlParameter[2];
            paracv[0] = new SqlParameter("@macv", cv.MaCV);
            paracv[1] = new SqlParameter("@tencv", cv.TenCV);
            
            string sql = "INSERT INTO [dbo].[tblChucVu]([MaCV],[TenCV]) VALUES (@macv, @tencv)";
            return RunSQL(sql, CommandType.Text, paracv);
        }

        public bool kiemTraTrungMa(string ma)
        {
            string sql = "SELECT MaCV FROM tblChucVu WHERE MaCV = '" + ma + "'";
            if (CheckKey(sql))
            {
                MessageBox.Show("Mã chức vụ này đã nhập\nVui lòng nhập mã khác!!!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        public int suaChucVu(DTO_ChucVu cv)
        {
            SqlParameter[] paracv = new SqlParameter[2];
            paracv[0] = new SqlParameter("@macv", cv.MaCV);
            paracv[1] = new SqlParameter("@tencv", cv.TenCV);

            string sql = "UPDATE tblChucVu SET TenCV = @tencv WHERE MaCV = @macv";
            return RunSQL(sql, CommandType.Text, paracv);
        }

        public int xoaChucVu(string macv)
        {
            SqlParameter[] paracv = new SqlParameter[1];
            paracv[0] = new SqlParameter("@macv", macv);

            string sql = "DELETE FROM tblChucVu WHERE MaCV = @macv";
            return RunSQL(sql, CommandType.Text, paracv);
        }
    }
}
