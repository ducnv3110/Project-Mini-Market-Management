using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS_QuanLyBachHoa
{
    public class ConnectSql
    {
        protected static SqlConnection connection = null;

        protected void OpenConnection()
        {
            if (connection == null)
                connection = new SqlConnection(System.IO.File.ReadAllText("connectionString.txt"));

            try
            {
                connection.Open();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
