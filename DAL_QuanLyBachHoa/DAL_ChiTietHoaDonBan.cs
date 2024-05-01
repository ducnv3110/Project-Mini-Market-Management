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
    public class DAL_ChiTietHoaDonBan: DBConnect
    {
        public DataTable getChiTietHoaDonBan()
        {
            return GetDataToTable("SELECT tblChiTietHoaDonBan.MaHDB, tblHang.TenHH, tblChiTietHoaDonBan.SoLuongBan, tblChiTietHoaDonBan.DonGiaBan, tblHang.VAT, tblChiTietHoaDonBan.ThanhTien "
                                    + " FROM tblChiTietHoaDonBan INNER JOIN "
                                    + " tblHang ON tblChiTietHoaDonBan.MaHH = tblHang.MaHH");
        }
        public DataTable getChiTietHoaDonBan(string ma)
        {
            return GetDataToTable("SELECT tblChiTietHoaDonBan.MaHDB, tblChiTietHoaDonBan.MaHH ,tblHang.TenHH, tblChiTietHoaDonBan.SoLuongBan, tblChiTietHoaDonBan.DonGiaBan, tblHang.VAT, tblChiTietHoaDonBan.ThanhTien "
                                    + " FROM tblChiTietHoaDonBan INNER JOIN "
                                    + " tblHang ON tblChiTietHoaDonBan.MaHH = tblHang.MaHH WHERE tblChiTietHoaDonBan.MaHDB = '"+ ma +"'");
        }
        public int themChiTietHoaDonBan(DTO_ChiTietHoaDonBan cthdb)
        {
            SqlParameter[] paracthdb = new SqlParameter[5];
            paracthdb[0] = new SqlParameter("@mahdb", cthdb.MaHDB);
            paracthdb[1] = new SqlParameter("@mahh", cthdb.MaHH);
            paracthdb[2] = new SqlParameter("@soluongban", cthdb.SoLuongBan);
            paracthdb[3] = new SqlParameter("@dongiaban", cthdb.DonGiaBan);
            paracthdb[4] = new SqlParameter("@thanhtien", cthdb.ThanhTien);

            string sql = "SELECT MaHDB, MaHH FROM tblChiTietHoaDonBan WHERE MaHDB = '" + cthdb.MaHDB + "' AND MaHH = '" + cthdb.MaHH + "'";
            if (CheckKey(sql))
            {
                MessageBox.Show("Mã hoá đơn hoặc mã hàng này đã nhập rồi.\nVui lòng nhập mã khác!!!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            else
            {
                sql = "INSERT INTO [dbo].[tblChiTietHoaDonBan]([MaHDB],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES (@mahdb, @mahh, @soluongban, @dongiaban, @thanhtien)";
                return RunSQL(sql, CommandType.Text, paracthdb);
            }
        }

        public int suaChiTietHoaDonBan(DTO_ChiTietHoaDonBan cthdb)
        {
            SqlParameter[] paracthdb = new SqlParameter[6];
            paracthdb[0] = new SqlParameter("@mahdb", cthdb.MaHDB);
            paracthdb[1] = new SqlParameter("@mahh", cthdb.MaHH);
            paracthdb[2] = new SqlParameter("@soluongban", cthdb.SoLuongBan);
            paracthdb[3] = new SqlParameter("@dongiaban", cthdb.DonGiaBan);
            paracthdb[4] = new SqlParameter("@thanhtien", cthdb.ThanhTien);

            string sql = "UPDATE tblChiTietHoaDonBan SET SoLuongBan = @soluongban, DonGiaBan = @dongiaban, ThanhTien = @thanhtien WHERE MaHDB = @mahdb AND MaHH = @mahh";
            return RunSQL(sql, CommandType.Text, paracthdb);
        }
        public int xoaChiTietHoaDonBan(string mahdb, string MaHH)
        {
            SqlParameter[] paracthdb = new SqlParameter[2];
            paracthdb[0] = new SqlParameter("@mahdb", mahdb);
            paracthdb[1] = new SqlParameter("@mahh", MaHH);

            string sql = "DELETE FROM tblChiTietHoaDonBan WHERE MaHDB = @mahdb AND MaHH = @mahh";
            return RunSQL(sql, CommandType.Text, paracthdb);
        }

        public int xoaChiTietHoaDonBan(string mahdb)
        {
            SqlParameter[] paracthdb = new SqlParameter[1];
            paracthdb[0] = new SqlParameter("@mahdb", mahdb);

            string sql = "DELETE FROM tblChiTietHoaDonBan WHERE MaHDB = @mahdb";
            return RunSQL(sql, CommandType.Text, paracthdb);
        }
        public bool kiemTraSoLuongTon(string MaHH, string soluongban)
        {
            float _sl = 0;

            _sl = laySoLuongTon(MaHH);
            if (float.Parse(soluongban) > _sl)
            {
                return false;
            }
            return true;
        }

        public float laySoLuongTon(string MaHH)
        {
            float _sl = 0;

            _sl = float.Parse(GetFieldValues("SELECT SoLuongTon FROM tblHang WHERE MaHH = '" + MaHH + "' "));

            return _sl;
        }
    }
}
