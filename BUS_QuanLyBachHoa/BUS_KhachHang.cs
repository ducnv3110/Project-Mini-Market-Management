using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyBachHoa;
using System.Data;
using DTO_QuanLyBachHoa;

namespace BUS_QuanLyBachHoa
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dalKH = new DAL_KhachHang();

        public DataTable getKhachHang()
        {
            return dalKH.getKhachHang();
        }
        public DataTable timKhachHang(string tenkh)
        {
            return dalKH.timKhachHang(tenkh);
        }
        public int themKhachHang(DTO_KhachHang kh)
        {
            return dalKH.themKhachHang(kh);
        }

        public int suaKhachHang(DTO_KhachHang kh)
        {
            return dalKH.suaKhachHang(kh);
        }

        public int xoaKhachHang(string makh)
        {
            return dalKH.xoaKhachHang(makh);
        }
    }
}
