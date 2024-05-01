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
    public class BUS_Hang
    {
        DAL_Hang dalH = new DAL_Hang();

        public DataTable getHang()
        {
            return dalH.getHang();
        }
        public DataTable getHang(string ma)
        {
            return dalH.getHang(ma);
        }
        public DataTable timHang(string tenhang)
        {
            return dalH.timHang(tenhang);
        }
        public int themHang(DTO_Hang h)
        {
            return dalH.themHang(h);
        }

        public int xoaHang(string mahang)
        {
            return dalH.xoaHang(mahang);
        }

        public int suaHang(DTO_Hang h)
        {
            return dalH.suaHang(h);
        }
        public void tangValue(string name)
        {
            dalH.tangValue(name);
        }
        public void giamValue()
        {
            dalH.giamValue();
        }
        public string taoBarcode()
        {
            return dalH.taoBarcode();
        }
        public int getFinalValue()
        {
            return dalH.getFinalValue();
        }
        public List<DTO_PrintBarcode> getDMPrintBarcode(string maloai)
        {
            return dalH.getDMPrintBarcode(maloai);
        }
    }
}
