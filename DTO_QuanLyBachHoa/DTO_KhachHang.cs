using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }

        public DTO_KhachHang()
        {

        }

        public DTO_KhachHang(string makh, string tenkh, string sdt, string diachi)
        {
            this.MaKH = makh;
            this.TenKH = tenkh;
            this.SDT = sdt;
            this.DiaChi = diachi;
        }
    }
}
