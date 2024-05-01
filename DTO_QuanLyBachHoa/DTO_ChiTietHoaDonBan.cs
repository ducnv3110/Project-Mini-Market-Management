using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_ChiTietHoaDonBan
    {
        public string MaHDB { get; set; }
        public string MaHH { get; set; }

        public int SoLuongBan { get; set; }
        public float DonGiaBan { get; set; }
        public float ThanhTien { get; set; }
        public DTO_ChiTietHoaDonBan()
        {

        }

        public DTO_ChiTietHoaDonBan(string mahdb, string mahh, int soluongban, float dongiaban, float thanhtien)
        {
            this.MaHDB = mahdb;
            this.MaHH = mahh;
            this.SoLuongBan = soluongban;
            this.DonGiaBan = dongiaban;
            this.ThanhTien = thanhtien;
        }
    }
}
