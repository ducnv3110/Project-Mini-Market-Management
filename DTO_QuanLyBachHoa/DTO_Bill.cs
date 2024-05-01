using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_Bill
    {
        public string SoHD { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayBan { get; set; }
        public float TongTien { get; set; }

        public DTO_Bill()
        {

        }

        public DTO_Bill(string sohd, string manv, DateTime ngayban, float tongtien)
        {
            this.SoHD = sohd;
            this.MaNV = manv;
            this.NgayBan = ngayban;
            this.TongTien = tongtien;
        }
    }
}
