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
    public class DAL_Bill : DBConnect
    {
        public DataTable getBill(DateTime tuNgay, DateTime denNgay)
        {
            return GetDataToTable("SELECT dbo.tblPhieuThanhToan.SoHD, dbo.tblNhanVien.TenNV, dbo.tblPhieuThanhToan.NgayBan, dbo.tblPhieuThanhToan.TongTien"
                                    +" FROM dbo.tblPhieuThanhToan INNER JOIN"
                                    +" dbo.tblNhanVien ON dbo.tblPhieuThanhToan.MaNV = dbo.tblNhanVien.MaNV"
                                    +" WHERE NgayBan BETWEEN '"+ tuNgay +"' AND '"+ denNgay +"'");
        }
        public DataTable timBill(string ma)
        {
            return GetDataToTable("SELECT dbo.tblPhieuThanhToan.SoHD, dbo.tblNhanVien.TenNV, dbo.tblPhieuThanhToan.NgayBan, dbo.tblPhieuThanhToan.TongTien"
                                    + " FROM dbo.tblPhieuThanhToan INNER JOIN"
                                    + " dbo.tblNhanVien ON dbo.tblPhieuThanhToan.MaNV = dbo.tblNhanVien.MaNV"
                                    + " WHERE SoHD ='"+ ma +"' ");
        }
        public int themBill(DTO_Bill bill)
        {
            SqlParameter[] parabill = new SqlParameter[4];
            parabill[0] = new SqlParameter("@sohd", bill.SoHD);
            parabill[1] = new SqlParameter("@manv", bill.MaNV);
            parabill[2] = new SqlParameter("@ngayban", bill.NgayBan);
            parabill[3] = new SqlParameter("@tongtien", bill.TongTien);

            string sql = "INSERT INTO [dbo].[tblPhieuThanhToan]([SoHD],[MaNV],[NgayBan],[TongTien]) VALUES (@sohd, @manv, @ngayban, @tongtien)";

            return RunSQL(sql, CommandType.Text, parabill);
        }

        public int suaBill(DTO_Bill bill)
        {
            SqlParameter[] parabill = new SqlParameter[4];
            parabill[0] = new SqlParameter("@sohd", bill.SoHD);
            parabill[1] = new SqlParameter("@manv", bill.MaNV);
            parabill[2] = new SqlParameter("@ngayban", bill.NgayBan);
            parabill[3] = new SqlParameter("@tongtien", bill.TongTien);

            string sql = "UPDATE tblPhieuThanhToan SET MaNV = @manv, NgayBan = @ngayban, TongTien = @tongtien WHERE SoHD = @sohd";

            return RunSQL(sql, CommandType.Text, parabill);
        }

        public int xoaBill(string ma)
        {
            SqlParameter[] parabill = new SqlParameter[1];
            parabill[0] = new SqlParameter("@sohd", ma);

            string sql = "DELETE FROM tblPhieuThanhToan WHERE SoHD = @sohd";
            return RunSQL(sql, CommandType.Text, parabill);
        }

        public int capNhatTongTien(string ma , string tongtien)
        {
            float _tong = 0;

            SqlParameter[] parabill = new SqlParameter[1];
            parabill[0] = new SqlParameter("@ma", ma);

            _tong = float.Parse(tongtien);

            string sql = "UPDATE tblPhieuThanhToan SET TongTien = " + _tong + " WHERE SoHD = @ma";
            return RunSQL(sql, CommandType.Text, parabill);
        }

        public string taoSoPhieu()
        {
            return CreateKey();
        }
    }
}
