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
    public class DAL_ChiTietHoaDonNhap: DBConnect
    {
        public DataTable getChiTietHoaDonNhap()
        {
            return GetDataToTable("SELECT tblChiTietHoaDonNhap.MaHDN, tblHang.TenHH, tblChiTietHoaDonNhap.SoLuongNhap, tblChiTietHoaDonNhap.DonGiaNhap, tblChiTietHoaDonNhap.ThanhTien "
                                    + " FROM tblChiTietHoaDonNhap INNER JOIN "
                                    + " tblHang ON tblChiTietHoaDonNhap.MaHH = tblHang.MaHH");
        }

        public DataTable getChiTietHoaDonNhap(string ma)
        {
            return GetDataToTable("SELECT tblChiTietHoaDonNhap.MaHDN, tblChiTietHoaDonNhap.MaHH, tblHang.TenHH, tblHang.DVT, tblChiTietHoaDonNhap.SoLuongNhap, tblChiTietHoaDonNhap.DonGiaNhap, tblChiTietHoaDonNhap.ThanhTien "
                                    + " FROM tblChiTietHoaDonNhap INNER JOIN "
                                    + " tblHang ON tblChiTietHoaDonNhap.MaHH = tblHang.MaHH WHERE tblChiTietHoaDonNhap.MaHDN= '" + ma + "'");

        }
        
        public int themChiTietHoaDonNhap(DTO_ChiTietHoaDonNhap cthdn)
        {
            SqlParameter[] paracthdn = new SqlParameter[5];
            paracthdn[0] = new SqlParameter("@mahdn", cthdn.MaHDN);
            paracthdn[1] = new SqlParameter("@MaHH", cthdn.MaHH);
            paracthdn[2] = new SqlParameter("@soluongnhap", cthdn.SoLuongNhap);
            paracthdn[3] = new SqlParameter("@dongianhap", cthdn.DonGiaNhap);
            paracthdn[4] = new SqlParameter("@thanhtien", cthdn.ThanhTien);

            string sql = "SELECT MaHDN, MaHH FROM tblChiTietHoaDonNhap WHERE MaHDN = '" + cthdn.MaHDN + "' AND MaHH = '" + cthdn.MaHH + "'";
            if (CheckKey(sql))
            {
                MessageBox.Show("Mã hoá đơn hoặc mã hàng này đã nhập rồi.\nVui lòng nhập mã khác!!!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            else
            {
                sql = "INSERT INTO [dbo].[tblChiTietHoaDonNhap]([MaHDN],[MaHH],[SoLuongNhap],[DonGiaNhap],[ThanhTien]) VALUES (@mahdn, @MaHH, @soluongnhap, @dongianhap, @thanhtien)";
                return RunSQL(sql, CommandType.Text, paracthdn);
            }
        }

        public int suaChiTietHoaDonNhap(DTO_ChiTietHoaDonNhap cthdn)
        {
            SqlParameter[] paracthdn = new SqlParameter[5];
            paracthdn[0] = new SqlParameter("@mahdn", cthdn.MaHDN);
            paracthdn[1] = new SqlParameter("@MaHH", cthdn.MaHH);
            paracthdn[2] = new SqlParameter("@soluongnhap", cthdn.SoLuongNhap);
            paracthdn[3] = new SqlParameter("@dongianhap", cthdn.DonGiaNhap);
            paracthdn[4] = new SqlParameter("@thanhtien", cthdn.ThanhTien);
            
            string sql = "UPDATE tblChiTietHoaDonNhap SET SoLuongNhap = @soluongnhap, DonGiaNhap = @dongianhap, ThanhTien = @thanhtien WHERE MaHDN = @mahdn AND MaHH = @MaHH";
            return RunSQL(sql, CommandType.Text, paracthdn);
            
        }

        public int xoaChiTietHoaDonNhap(string mahdn , string MaHH)
        {
            SqlParameter[] paracthdn = new SqlParameter[2];
            paracthdn[0] = new SqlParameter("@mahdn", mahdn);
            paracthdn[1] = new SqlParameter("@MaHH", MaHH);

            string sql = "DELETE FROM tblChiTietHoaDonNhap WHERE MaHDN = @mahdn AND MaHH = @MaHH";
            return RunSQL(sql, CommandType.Text, paracthdn);
        }

        public int xoaChiTietHoaDonNhap(string mahdn)
        {
            SqlParameter[] paracthdn = new SqlParameter[1];
            paracthdn[0] = new SqlParameter("@mahdn", mahdn);
            

            string sql = "DELETE FROM tblChiTietHoaDonNhap WHERE MaHDN = @mahdn";
            return RunSQL(sql, CommandType.Text, paracthdn);
        }

    }
}
