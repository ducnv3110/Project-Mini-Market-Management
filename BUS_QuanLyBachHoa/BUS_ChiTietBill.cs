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
    public class BUS_ChiTietBill
    {
        DAL_ChiTietBill dalCTBill = new DAL_ChiTietBill();

        public DataTable getChiTietBill()
        {
            return dalCTBill.getChiTietBill();
        }
        public DataTable getChiTietBill(string ma)
        {
            return dalCTBill.getChiTietBill(ma);
        }
        public int themChiTietBill(DTO_ChiTietBill chiTietBill)
        {
            return dalCTBill.themChiTietBill(chiTietBill);
        }
        public int suaChiTietBill(DTO_ChiTietBill chiTietBill)
        {
            return dalCTBill.suaChiTietBill(chiTietBill);
        }
        public int xoaChiTietBill(string ma)
        {
            return dalCTBill.xoaChiTietBill(ma);
        }
        public int xoaChiTietBill(string ma , string hang)
        {
            return dalCTBill.xoaChiTietBill(ma, hang);
        }
        public float laySoLuongTon(string mahang)
        {
            return dalCTBill.laySoLuongTon(mahang);
        }
        public bool kiemTraSoLuongTon(string mahang, string soluongban)
        {
            return dalCTBill.kiemTraSoLuongTon(mahang, soluongban);
        }
    }
}
