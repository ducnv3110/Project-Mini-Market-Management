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
    public class DAL_NhanVien : DBConnect
    {
        public DataTable getNhanVien()
        {
            return GetDataToTable("SELECT MaNV, TenNV, CMND, NgaySinh, Phai, SDT, DiaChi, TenCV FROM tblNhanVien "
                                            + " inner join tblChucVu on tblNhanVien.MaCV = tblChucVu.MaCV");
        }
        public DataTable timNhanVien(string ten)
        {
            return GetDataToTable("SELECT MaNV, TenNV, CMND, NgaySinh, Phai, SDT, DiaChi, TenCV FROM tblNhanVien "
                                            + " inner join tblChucVu on tblNhanVien.MaCV = tblChucVu.MaCV"
                                            + " WHERE TenNV like N'%"+ ten +"%' ");
        }
        public List<DTO_NhanVien> getListNV()
        {
            DataTable dt = getNhanVien();
            List<DTO_NhanVien> lstNV = new List<DTO_NhanVien>();
            lstNV = (from DataRow dr in dt.Rows
                     select new DTO_NhanVien()
                     {
                         MaNV = dr["MaNV"].ToString(),
                         TenNV = dr["TenNV"].ToString(),
                         NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()),
                         Phai = (bool)dr["Phai"],
                         SDT = dr["SDT"].ToString(),
                         DiaChi = dr["DiaChi"].ToString(),
                         MaCV = dr["TenCV"].ToString(),
                         CMND = dr["CMND"].ToString()
                     }
                ).ToList();

            return lstNV;
        }
        public int themNhanVien(DTO_NhanVien nv)
        {
            SqlParameter[] paranv = new SqlParameter[7];
            paranv[0] = new SqlParameter("@ten", nv.TenNV);
            paranv[1] = new SqlParameter("@ngaysinh", nv.NgaySinh);
            paranv[2] = new SqlParameter("@phai", nv.Phai);
            paranv[3] = new SqlParameter("@sdt", nv.SDT);
            paranv[4] = new SqlParameter("@diachi", nv.DiaChi);
            paranv[5] = new SqlParameter("@cmnd", nv.CMND);
            paranv[6] = new SqlParameter("@macv", nv.MaCV);

            string sql = "sp_them_nv";
            return RunSQL(sql, CommandType.StoredProcedure, paranv);
        }

        public int suaNhanVien(DTO_NhanVien nv)
        {
            SqlParameter[] paranv = new SqlParameter[8];
            paranv[0] = new SqlParameter("@nv_id", nv.MaNV);
            paranv[1] = new SqlParameter("@ten", nv.TenNV);
            paranv[2] = new SqlParameter("@ngaysinh", nv.NgaySinh);
            paranv[3] = new SqlParameter("@phai", nv.Phai);
            paranv[4] = new SqlParameter("@sdt", nv.SDT);
            paranv[5] = new SqlParameter("@diachi", nv.DiaChi);
            paranv[6] = new SqlParameter("@cmnd", nv.CMND);
            paranv[7] = new SqlParameter("@macv", nv.MaCV);

            string sql = "sp_sua_nv";
            return RunSQL(sql, CommandType.StoredProcedure, paranv);
        }

        public int xoaNhanVien(string manv)
        {
            SqlParameter[] paranv = new SqlParameter[1];
            paranv[0] = new SqlParameter("@manv", manv);

            string sql = "DELETE FROM tblNhanVien WHERE MaNV = @manv";

            return RunSQL(sql, CommandType.Text, paranv);
        }
    }
}
