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
    public class BUS_HoaDonBan
    {
        DAL_HoaDonBan dalHDB = new DAL_HoaDonBan();

        public DataTable getHoaDonBan()
        {
            return dalHDB.getHoaDonBan();
        }
        public DataTable getHoaDonBan(DateTime tungay, DateTime denngay, string makh, string manv)
        {
            return dalHDB.getHoaDonBan(tungay, denngay, makh, manv);
        }
        public DataTable timHoaDonBan(string mahdb)
        {
            return dalHDB.timHoaDonBan(mahdb);
        }
        public int themHoaDonBan(DTO_HoaDonBan hdb)
        {
            return dalHDB.themHoaDonBan(hdb);
        }

        public int suaHoaDonBan(DTO_HoaDonBan hdb)
        {
            return dalHDB.suaHoaDonBan(hdb);
        }

        public int xoaHoaDonBan(string mahdb)
        {
            return dalHDB.xoaHoaDonBan(mahdb);
        }

        public int capNhatTongTien(string ma , string tongtien)
        {
            return dalHDB.capNhatTongTien(ma, tongtien);
        }

        public string taoMaHoaDon()
        {
            return dalHDB.taoMaHoaDon();
        }
    }
}
