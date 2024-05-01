using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_NhanVien 
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public bool Phai { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string MaCV { get; set; }
        public string CMND { get; set; }
        

        public DTO_NhanVien()
        {

        }

        public DTO_NhanVien(string manv, string tennv,string cmnd, System.DateTime ngaysinh, bool phai, string sdt, string diachi,string macv)
        {
            this.MaNV = manv;
            this.TenNV = tennv;
            this.CMND = cmnd;
            this.NgaySinh = ngaysinh;
            this.Phai = phai;
            this.SDT = sdt;
            this.DiaChi = diachi;
            this.MaCV = macv;
        } 
    }
}
