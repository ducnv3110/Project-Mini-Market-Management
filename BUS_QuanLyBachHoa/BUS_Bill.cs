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
    public class BUS_Bill
    {
        DAL_Bill dalBill = new DAL_Bill();
        public DataTable getBill(DateTime tuNgay, DateTime denNgay)
        {
            return dalBill.getBill(tuNgay,denNgay);
        }
        public DataTable timBill(string ma)
        {
            return dalBill.timBill(ma);
        }
        public int themBill(DTO_Bill bill)
        {
            return dalBill.themBill(bill);
        }
        public int suaBill(DTO_Bill bill)
        {
            return dalBill.suaBill(bill);
        }
        public int xoaBill(string ma)
        {
            return dalBill.xoaBill(ma);
        }
        public int capNhatTongTien(string ma, string tongtien)
        {
            return dalBill.capNhatTongTien(ma, tongtien);
        }
        public string taoSoPhieu()
        {
            return dalBill.taoSoPhieu();
        }
    }
}
