using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyBachHoa;
using System.Data;

namespace BUS_QuanLyBachHoa
{
    public class DangNhapModel : ConnectSqlEx
    {
        public User DangNhap(string id, string password)
        {
            User user = null;
            try
            {
                SqlParameter pID = new SqlParameter("@id", id);
                SqlParameter pMatkhau = new SqlParameter("@mat_khau", password);

                SqlDataReader read = Reader("sp_dang_nhap", CommandType.StoredProcedure, pID, pMatkhau);

                while (read.Read())
                {
                    user = new User
                    {
                        ID = read[0].ToString(),
                        MaNV = read[1].ToString(),
                        HoTen = read[2].ToString(),
                        MaCV = read[3].ToString(),
                        TenCV = read[4].ToString()
                    };
                }


            }
            catch
            {


            }

            connection.Close();
            return user;
        }
    }
}

