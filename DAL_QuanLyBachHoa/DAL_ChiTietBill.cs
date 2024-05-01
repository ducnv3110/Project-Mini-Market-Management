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
    public class DAL_ChiTietBill : DBConnect
    {
        public DataTable getChiTietBill()
        {
            return GetDataToTable("SELECT dbo.tblChiTietPhieuTT.SoHD, dbo.tblHang.MaHH , dbo.tblHang.TenHH, dbo.tblChiTietPhieuTT.SoLuongBan, dbo.tblChiTietPhieuTT.DonGiaBan, dbo.tblChiTietPhieuTT.ThanhTien, VAT"
                                    + " FROM dbo.tblChiTietPhieuTT INNER JOIN "
                                    + " dbo.tblHang ON dbo.tblChiTietPhieuTT.MaHH = dbo.tblHang.MaHH");
        }
        public DataTable getChiTietBill(string ma)
        {
            return GetDataToTable("SELECT dbo.tblChiTietPhieuTT.SoHD, dbo.tblHang.MaHH , dbo.tblHang.TenHH, dbo.tblChiTietPhieuTT.SoLuongBan, dbo.tblChiTietPhieuTT.DonGiaBan, dbo.tblChiTietPhieuTT.ThanhTien, VAT"
                                    + " FROM dbo.tblChiTietPhieuTT INNER JOIN "
                                    + " dbo.tblHang ON dbo.tblChiTietPhieuTT.MaHH = dbo.tblHang.MaHH"
                                    + " WHERE dbo.tblChiTietPhieuTT.SoHD = '"+ ma +"'");
        }
        public int themChiTietBill(DTO_ChiTietBill ct)
        {
            SqlParameter[] paract = new SqlParameter[5];
            paract[0] = new SqlParameter("@sohd", ct.SoHD);
            paract[1] = new SqlParameter("@mahh", ct.MaHH);
            paract[2] = new SqlParameter("@soluongban", ct.SoLuongBan);
            paract[3] = new SqlParameter("@dongiaban", ct.DonGiaBan);
            paract[4] = new SqlParameter("@thanhtien", ct.ThanhTien);

            string sql = "SELECT SoHD, MaHH FROM tblChiTietPhieuTT WHERE SoHD = '" + ct.SoHD + "' AND MaHH = '" + ct.MaHH + "'";

            if (CheckKey(sql))
            {
                MessageBox.Show("Mặt hàng này đã có trong phiếu\nVui lòng kiểm tra lại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            else
            {
                sql = "INSERT INTO [dbo].[tblChiTietPhieuTT] ([SoHD],[MaHH],[SoLuongBan],[DonGiaBan],[ThanhTien]) VALUES (@sohd, @mahh, @soluongban, @dongiaban, @thanhtien)";
                return RunSQL(sql, CommandType.Text, paract);
            }
        }

        public int suaChiTietBill(DTO_ChiTietBill ct)
        {
            SqlParameter[] paract = new SqlParameter[5];
            paract[0] = new SqlParameter("@sohd", ct.SoHD);
            paract[1] = new SqlParameter("@mahh", ct.MaHH);
            paract[2] = new SqlParameter("@soluongban", ct.SoLuongBan);
            paract[3] = new SqlParameter("@dongiaban", ct.DonGiaBan);
            paract[4] = new SqlParameter("@thanhtien", ct.ThanhTien);

            string sql = "UPDATE tblChiTietPhieuTT SET MaHH = @mahh, SoLuongBan = @soluongban, DonGiaBan = @dongiaban, ThanhTien = @thanhtien WHERE SoHD = @sohd";
            return RunSQL(sql, CommandType.Text, paract);
        }
        public int xoaChiTietBill(string ma)
        {
            SqlParameter[] paract = new SqlParameter[1];
            paract[0] = new SqlParameter("@sohd", ma);

            string sql = "DELETE FROM tblChiTietPhieuTT WHERE SoHD = @sohd";
            return RunSQL(sql, CommandType.Text, paract);
        }
        public int xoaChiTietBill(string ma, string hang)
        {
            SqlParameter[] paract = new SqlParameter[2];
            paract[0] = new SqlParameter("@sohd", ma);
            paract[1] = new SqlParameter("@mahh", hang);

            string sql = "DELETE FROM tblChiTietPhieuTT WHERE SoHD= @sohd AND MaHH = @mahh";
            return RunSQL(sql, CommandType.Text, paract);
        }
        public float laySoLuongTon(string MaHH)
        {
            float _sl = 0;

            _sl = float.Parse(GetFieldValues("SELECT SoLuongTon FROM tblHang WHERE MaHH = '" + MaHH + "' "));

            return _sl;

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

    }
}
