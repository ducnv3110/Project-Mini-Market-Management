using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_HoaDonNhap
    {
        public string MaHDN { get; set; }
        public string MaNV { get; set; }
        public string MaNCC { get; set; }
        public System.DateTime NgayNhap { get; set; }
        public float TongTien { get; set; }

        public DTO_HoaDonNhap()
        {

        }

        public DTO_HoaDonNhap(string mahdn, string manv, string mancc, System.DateTime ngaynhap, float tongtien)
        {
            this.MaHDN = mahdn;
            this.MaNV = manv;
            this.MaNCC = mancc;
            this.NgayNhap = ngaynhap;
            this.TongTien = tongtien;
        }
    }
}
