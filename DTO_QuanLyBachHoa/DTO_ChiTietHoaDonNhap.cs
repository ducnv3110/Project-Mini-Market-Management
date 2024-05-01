using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_ChiTietHoaDonNhap 
    {
        public string MaHDN { get; set; }
        public string MaHH { get; set; }
        
        public int SoLuongNhap { get; set; }
        public float DonGiaNhap { get; set; }

        public float ThanhTien { get; set; }
        public DTO_ChiTietHoaDonNhap()
        {

        }

        public DTO_ChiTietHoaDonNhap(string mahdn, string mahang, int soluongnhap, float dongianhap, float thanhtien)
        {
            this.MaHDN = mahdn;
            this.MaHH = mahang;
            this.SoLuongNhap = soluongnhap;
            this.DonGiaNhap = dongianhap;
            this.ThanhTien = thanhtien;
        }

    }
}
