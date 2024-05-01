using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLyBachHoa
{
    public class DoiMatKhauModel :ConnectSqlEx
    {
        public string LayMatKhauCu(string id)
        {
            SqlDataReader reader = Reader("SELECT Password FROM tblTaiKhoan WHERE ID='" + id + "'");

            string matKhau = "";

            while (reader.Read())
            {
                matKhau = reader.GetValue(0).ToString();
                break;
            }

            reader.Close();
            connection.Close();

            return matKhau;
        }

        public int DoiMatKhau(string id, string matkhau)
        {
            return ExecuteUpdate("UPDATE tblTaiKhoan SET Password='" + matkhau + "' WHERE ID='" + id + "'");

        }
    }
}
