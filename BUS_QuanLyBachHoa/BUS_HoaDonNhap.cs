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
    public class BUS_HoaDonNhap
    {
        DAL_HoaDonNhap dalHDN = new DAL_HoaDonNhap();

        public  DataTable getHoaDonNhap()
        {
            return dalHDN.getHoaDonNhap();
        }
        public DataTable timHoaDonNhap(string mahdn)
        {
            return dalHDN.timHoaDonNhap(mahdn);
        }

        public DataTable getHoaDonNhap(DateTime tungay, DateTime denngay, string manhacc, string manv)
        {
            return dalHDN.getHoaDonNhap(tungay, denngay, manhacc, manv);
        }

        public int themHoaDonNhap(DTO_HoaDonNhap hdn)
        {
            return dalHDN.themHoaDonNhap(hdn);
        }

        public int suaHoaDonNhap(DTO_HoaDonNhap hdn)
        {
            return dalHDN.suaHoaDonNhap(hdn);
        }

        public int xoaHoaDonNhap(string mahdn)
        {
            return dalHDN.xoaHoaDonNhap(mahdn);
        }

        public int capNhatTongTien(string mahdn, string tongtien)
        {
            return dalHDN.capNhatTongTien(mahdn, tongtien);
        }

        public string taoMaHD()
        {
            return dalHDN.taoMaHoaDon();
        }
    }
}
