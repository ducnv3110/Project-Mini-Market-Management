using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_LoaiHang
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }

        public DTO_LoaiHang()
        {

        }

        public DTO_LoaiHang(string maloai, string tenloai)
        {
            this.MaLoai = maloai;
            this.TenLoai = tenloai;
        }
    }
}
