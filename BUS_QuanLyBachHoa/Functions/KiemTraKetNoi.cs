using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLyBachHoa
{
    public class KiemTraKetNoi
    {
        public bool KiemTra()
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(System.IO.File.ReadAllText("connectionString.txt"));

            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
