using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DAL_QuanLyBachHoa
{
    public class DBConnect
    {
        public string strConnect = @"Data Source = localhost\sqlexpress;Initial Catalog = QLBachHoa; Integrated Security = True";

        SqlConnection conn = new SqlConnection();
        public DBConnect()
        {
            conn.ConnectionString = strConnect;
        }
        public void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public DataTable GetDataToTable(string sql)
        {

            SqlDataAdapter dap = new SqlDataAdapter();


            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = conn;
            dap.SelectCommand.CommandText = sql;

            DataTable table = new DataTable();

            dap.Fill(table);

            dap.Dispose();
            return table;

        }
        //them sua xoa
        public int RunSQL(string sql, CommandType type, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            int data;
            try
            {
                cmd.Connection = conn;
                OpenConnection();
                cmd.CommandType = type;
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(para);
                data = cmd.ExecuteNonQuery();
                CloseConnection();
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public void RunSQL(string sql)
        {
            SqlCommand cmd; 
            cmd = new SqlCommand();
            cmd.Connection = conn;
            
            cmd.CommandText = sql; 
            try
            {
                OpenConnection();
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }

        //tra ve cau truy van sum,count,max....
        public string TongHop(string strSql)
        {
            string th = "";
            SqlCommand cmd;

            try
            {

                OpenConnection();


                cmd = new SqlCommand(strSql, conn);
                th = cmd.ExecuteScalar().ToString();

            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {

                if (conn != null)
                {
                    CloseConnection();
                }

            }
            return th;
        }
        //kiem tra khoa
        public bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader;
            OpenConnection();
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            CloseConnection();
            return ma;
        }

        public string CreateKey()
        {
            string key ="";
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);

            key = key + d;

            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);

            key = key + t;
            return key;
        }

        private string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
        public string buildEan13(string code)
        {
            int iSum = 0;
            int iDigit = 0;

            //Tính số kiểm tra
            for (int i = code.Length; i >= 1; i--)
            {
                iDigit = Convert.ToInt32(code.Substring(i - 1, 1));
                if (i % 2 == 0)
                    iSum += iDigit * 3;
                else
                    iSum += iDigit * 1;
            }
            int checkSum = (10 - (iSum % 10)) % 10;

            code += checkSum.ToString();
            return code;
        }
    }
}
