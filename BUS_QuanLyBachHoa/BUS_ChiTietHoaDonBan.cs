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
    public class BUS_ChiTietHoaDonBan
    {
        DAL_ChiTietHoaDonBan dalCTHDB = new DAL_ChiTietHoaDonBan();

        public DataTable getChiTietHoaDonBan()
        {
            return dalCTHDB.getChiTietHoaDonBan();
        }
        public DataTable getChiTietHoaDonBan(string ma)
        {
            return dalCTHDB.getChiTietHoaDonBan(ma);
        }
        public int themChiTietHoaDonBan(DTO_ChiTietHoaDonBan cthdb)
        {
            return dalCTHDB.themChiTietHoaDonBan(cthdb);
        }

        public int suaChiTietHoaDonBan(DTO_ChiTietHoaDonBan cthdb)
        {
            return dalCTHDB.suaChiTietHoaDonBan(cthdb);
        }

        public int xoaChiTietHoaDonBan(string mahdb)
        {
            return dalCTHDB.xoaChiTietHoaDonBan(mahdb);
        }
        public int xoaChiTietHoaDonBan(string mahdb, string mahang)
        {
            return dalCTHDB.xoaChiTietHoaDonBan(mahdb, mahang);
        }

        public bool kiemTraSoLuongTon(string mahang, string soluongban)
        {
            return dalCTHDB.kiemTraSoLuongTon(mahang, soluongban);
        }

        public float laySoLuongTon(string mahang)
        {
            return dalCTHDB.laySoLuongTon(mahang);
        }
    }
}
