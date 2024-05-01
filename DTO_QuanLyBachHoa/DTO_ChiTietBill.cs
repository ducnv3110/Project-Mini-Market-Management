using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_ChiTietBill
    {
        public string SoHD { get; set; }
        public string MaHH { get; set; }
        public int SoLuongBan { get; set; }
        public float DonGiaBan { get; set; }
        public float ThanhTien { get; set; }

        public DTO_ChiTietBill()
        {

        }

        public DTO_ChiTietBill(string sohd, string mahh, int soluongban, float dongiaban, float thanhtien)
        {
            this.SoHD = sohd;
            this.MaHH = mahh;
            this.SoLuongBan = soluongban;
            this.DonGiaBan = dongiaban;
            this.ThanhTien = thanhtien;
        }
    }
}
