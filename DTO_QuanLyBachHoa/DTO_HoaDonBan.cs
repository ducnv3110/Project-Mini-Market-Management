using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_HoaDonBan
    {
        public string MaHDB { get; set; }
        public string MaNV { get; set; }
       
        public string MaKH { get; set; }
       
        public System.DateTime NgayBan { get; set; }
        public float TongTien { get; set; }

        public DTO_HoaDonBan()
        {

        }

        public DTO_HoaDonBan(string mahdb, string manv, string makh, System.DateTime ngayban, float tongtien)
        {
            this.MaHDB = mahdb;
            this.MaNV = manv;
            this.MaKH = makh;
            this.NgayBan = ngayban;
            this.TongTien = tongtien;
        }
    }
}
