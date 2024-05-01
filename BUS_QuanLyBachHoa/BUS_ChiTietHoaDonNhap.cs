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
    public class BUS_ChiTietHoaDonNhap
    {
        DAL_ChiTietHoaDonNhap dalCTHDN = new DAL_ChiTietHoaDonNhap();

        public DataTable getChiTietHoaDonNhap()
        {
            return dalCTHDN.getChiTietHoaDonNhap();
        }
        public DataTable getChiTietHoaDonNhap(string mahdn)
        {
            return dalCTHDN.getChiTietHoaDonNhap(mahdn);
        }
        public int themChiTietHoaDonNhap(DTO_ChiTietHoaDonNhap cthdn)
        {
            return dalCTHDN.themChiTietHoaDonNhap(cthdn);
        }

        public int suaChiTietHoaDonNhap(DTO_ChiTietHoaDonNhap cthdn)
        {
            return dalCTHDN.suaChiTietHoaDonNhap(cthdn);
        }

        public int xoaChiTietHoaDonNhap(string mahdn, string mahang)
        {
            return dalCTHDN.xoaChiTietHoaDonNhap(mahdn, mahang);
        }

        public int xoaChiTietHoaDonNhap(string mahdn)
        {
            return dalCTHDN.xoaChiTietHoaDonNhap(mahdn);
        }
    }
}
