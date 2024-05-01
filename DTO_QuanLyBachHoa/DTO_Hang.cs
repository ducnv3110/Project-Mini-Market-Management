using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_Hang : DTO_LoaiHang
    {
        public string MaHH { get; set; }
        public string TenHH { get; set; }
        public string HinhMinhHoa { get; set; }
        public string DVT { get; set; }
        public int SoLuongTon { get; set; }
        public float DonGiaNhap { get; set; }
        public float DonGiaBan { get; set; }
        public System.DateTime NgaySanXuat { get; set; }
        public System.DateTime NgayHetHan { get; set; }
        public string BaoQuan { get; set; }
        public int Value { get; set; }
        public int VAT { get; set; }
        public DTO_Hang()
        {

        }

        public DTO_Hang(string mahh, string tenhh, string maloai, string hinhminhhoa, string dvt, int soluongton, float dongianhap, float dongiaban, System.DateTime ngaysx , 
                            System.DateTime ngayhh, string baoquan, int value, int vat)
        {
            this.MaHH = mahh;
            this.TenHH = tenhh;
            this.MaLoai = maloai;
            this.HinhMinhHoa = hinhminhhoa;
            this.DVT = dvt;
            this.SoLuongTon = soluongton;
            this.DonGiaNhap = dongianhap;
            this.DonGiaBan = dongiaban;
            this.NgaySanXuat = ngaysx;
            this.NgayHetHan = ngayhh;
            this.Value = value;
            this.BaoQuan = baoquan;
            this.VAT = vat;
        }
    }
}
