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
    public class DAL_Hang : DBConnect
    {
        public DataTable getHang()
        {
            return GetDataToTable("SELECT MaHH, TenLoai, TenHH, HinhMinhHoa, DVT, SoLuongTon, DonGiaNhap, DonGiaBan, NgaySanXuat, NgayHetHan, BaoQuan, Value, VAT"
                                               + " FROM tblHang inner join tblLoaiHang on tblHang.MaLoai = tblLoaiHang.MaLoai");
        }
        public DataTable getHang(string ma)
        {
            return GetDataToTable("SELECT MaHH, TenLoai, TenHH, HinhMinhHoa, DVT, SoLuongTon, DonGiaNhap, DonGiaBan, NgaySanXuat, NgayHetHan,BaoQuan, Value, VAT"
                                               + " FROM tblHang inner join tblLoaiHang on tblHang.MaLoai = tblLoaiHang.MaLoai"
                                               + " WHERE MaHH = '"+ ma +"'");
        }
        public DataTable getHangfromMaloai(string maloai)
        {
            return GetDataToTable("SELECT * FROM tblHang WHERE MaLoai = '" + maloai + "'");
        }
        public DataTable timHang(string tenHH)
        {
            return GetDataToTable("SELECT MaHH, TenLoai, TenHH, HinhMinhHoa, DVT, SoLuongTon, DonGiaNhap, DonGiaBan, NgaySanXuat, NgayHetHan, BaoQuan, Value, VAT"
                                               +" FROM tblHang inner join tblLoaiHang on tblHang.MaLoai = tblLoaiHang.MaLoai"
                                               +" WHERE TenHH like N'%"+ tenHH +"%' ");
        }
        public int themHang(DTO_Hang h)
        {
            SqlParameter[] parahang = new SqlParameter[13];
            parahang[0] = new SqlParameter("@maloai", h.MaLoai);
            parahang[1] = new SqlParameter("@tenhh", h.TenHH);
            parahang[2] = new SqlParameter("@hinhminhhoa", h.HinhMinhHoa);
            parahang[3] = new SqlParameter("@dvt", h.DVT);
            parahang[4] = new SqlParameter("@soluongton", h.SoLuongTon);
            parahang[5] = new SqlParameter("@dongianhap", h.DonGiaNhap);
            parahang[6] = new SqlParameter("@dongiaban", h.DonGiaBan);
            parahang[7] = new SqlParameter("@ngaysanxuat", h.NgaySanXuat);
            parahang[8] = new SqlParameter("@ngayhethan", h.NgayHetHan);
            parahang[9] = new SqlParameter("@baoquan", h.BaoQuan);
            parahang[10] = new SqlParameter("@hang_id", h.MaHH);
            parahang[11] = new SqlParameter("@value", h.Value);
            parahang[12] = new SqlParameter("@vat", h.VAT);

            string sql = "INSERT INTO [dbo].[tblHang]([MaHH],[MaLoai],[TenHH],[DVT],[SoLuongTon],[DonGiaNhap],[DonGiaBan],[NgaySanXuat],[NgayHetHan],[BaoQuan],[HinhMinhHoa],[Value]),[VAT]"
                                           + " VALUES (@hang_id, @maloai, @tenhh, @dvt, @soluongton, @dongianhap, @dongiaban, @ngaysanxuat, @ngayhethan, @baoquan, @hinhminhhoa, @value, @vat)";
            return RunSQL(sql, CommandType.Text, parahang);
              
        }

        public int xoaHang(string ma)
        {
            SqlParameter[] parahang = new SqlParameter[1];
            parahang[0] = new SqlParameter("@mahh", ma);

            string sql = "DELETE FROM tblHang WHERE MaHH = @mahh";
            return RunSQL(sql, CommandType.Text, parahang);
        }

        public int suaHang(DTO_Hang h)
        {
            SqlParameter[] parahang = new SqlParameter[13];
            parahang[0] = new SqlParameter("@maloai", h.MaLoai);
            parahang[1] = new SqlParameter("@tenhh", h.TenHH);
            parahang[2] = new SqlParameter("@hinhminhhoa", h.HinhMinhHoa);
            parahang[3] = new SqlParameter("@dvt", h.DVT);
            parahang[4] = new SqlParameter("@soluongton", h.SoLuongTon);
            parahang[5] = new SqlParameter("@dongianhap", h.DonGiaNhap);
            parahang[6] = new SqlParameter("@dongiaban", h.DonGiaBan);
            parahang[7] = new SqlParameter("@ngaysanxuat", h.NgaySanXuat);
            parahang[8] = new SqlParameter("@ngayhethan", h.NgayHetHan);
            parahang[9] = new SqlParameter("@baoquan", h.BaoQuan);
            parahang[10] = new SqlParameter("@hang_id", h.MaHH);
            parahang[11] = new SqlParameter("@value", h.Value);
            parahang[12] = new SqlParameter("@vat", h.VAT);

            string sql = "UPDATE [dbo].[tblHang] "
                        +" SET [MaLoai] = @maloai "
                        +" ,[TenHH] = @tenhh"
                        +" ,[HinhMinhHoa] = @hinhminhhoa"
                        +" ,[DVT] = @dvt"
                        +" ,[SoLuongTon] = @soluongton"
                        +" ,[DonGiaNhap] = @dongianhap"
                        +" ,[DonGiaBan] = @dongiaban"
                        +" ,[NgaySanXuat] = @ngaysanxuat"
                        +" ,[NgayHetHan] = @ngayhethan"
                        +" ,[BaoQuan] = @baoquan"
                        +" ,[Value] = @value "
                        +" ,[Vat] = @vat "
                        +" WHERE MaHH = @hang_id";
            return RunSQL(sql, CommandType.Text, parahang);
        }
        void TEST(string maloai)
        {
            DataTable dt = getHangfromMaloai(maloai);
            List < DTO_Bill > test= new List<DTO_Bill>();
        }
        public List<DTO_PrintBarcode> getDMPrintBarcode(string maloai)
        {
            DataTable dt = getHangfromMaloai(maloai);
            List<DTO_Hang> lstHH = new List<DTO_Hang>();
            lstHH = lstHH.Select(s =>
            {
                DataTable dt1 = getHangfromMaloai(s.MaLoai);
            if (dt1 != null)
            {
                    s.TenLoai = dt.Rows[0]["TenLoai"].ToString();

            }
                return s;
            }).ToList();
            lstHH = (from DataRow dr in dt.Rows
                     select new DTO_Hang()
                     {
                         MaHH = dr["MaHH"].ToString(),
                         TenHH = dr["TenHH"].ToString(),
                         DonGiaBan = float.Parse(dr["DonGiaBan"].ToString())
                     }).ToList();

            List <DTO_PrintBarcode> lstPrintBarcode = new List<DTO_PrintBarcode>();
            DTO_PrintBarcode dtoBar;
            foreach (var item in lstHH)
            {
                dtoBar = new DTO_PrintBarcode();
                dtoBar.Barcode = item.MaHH;
                dtoBar.TenHH = item.TenHH;
                dtoBar.DonGia = item.DonGiaBan;
                dtoBar.SoTem = null;
                lstPrintBarcode.Add(dtoBar);
            }
            return lstPrintBarcode;
        }
        #region tạo mã vạch cho hàng
        public void tangValue(string name)
        {
            int value = getFinalValue() + 1;

            string sql = "INSERT INTO [dbo].[sys_Barcode]([seqValue],[seqName]) VALUES("+ value +", '"+ name +"')";
            RunSQL(sql);
        }
        public void giamValue()
        {
            int value = getFinalValue();

            string sql = "DELETE FROM sys_Barcode WHERE seqValue = "+ value +"";
            RunSQL(sql);
        }
        public int getFinalValue()
        {
            int finalValue = 0;
            finalValue = int.Parse(GetFieldValues("SELECT MAX(seqValue) FROM sys_Barcode"));

            return finalValue;
        }

        public string taoBarcode()
        {
            string ma = "";
            int value = getFinalValue();
            // mã quốc gia + năm hiện hành + mã hàng tăng dần + check sum
            ma = buildEan13("893" + DateTime.Now.Year.ToString() + value.ToString("00000"));

            return ma;
        }
        #endregion
    }
}
