using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLyBachHoa
{
    public class ConnectSqlEx:ConnectSql
    {
        protected SqlDataReader Reader(string query, CommandType type = CommandType.Text, params SqlParameter[] p)
        {
            OpenConnection();
            SqlDataReader read;

            try
            {
                SqlCommand cmd = new SqlCommand(query, connection)
                {
                    CommandType = type
                };
                if (type == CommandType.StoredProcedure)
                    cmd.Parameters.AddRange(p);

                read = cmd.ExecuteReader();

                cmd.Dispose();
            }
            catch
            {
                read = null;
            }

            return read;
        }

        protected int ExecuteUpdate(string query, CommandType type = CommandType.Text, params SqlParameter[] p)
        {
            OpenConnection();

            int result;

            try
            {
                SqlCommand cmd = new SqlCommand(query, connection)
                {
                    CommandType = type
                };

                if (type == CommandType.StoredProcedure)
                    cmd.Parameters.AddRange(p);

                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                result = -1;
            }
            connection.Close();
            return result;
        }

        protected int ExecuteUpateReturnValue(string query, CommandType type = CommandType.Text, params SqlParameter[] p)
        {
            OpenConnection();

            int result;

            try
            {
                SqlCommand cmd = new SqlCommand(query, connection)
                {
                    CommandType = type
                };

                if (type == CommandType.StoredProcedure)
                    cmd.Parameters.AddRange(p);

                result = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                result = -1;
            }
            connection.Close();
            return result;
        }
    }
}

