using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyBachHoa;
using DTO_QuanLyBachHoa;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BUS_QuanLyBachHoa
{
    public class BUS_LoaiHang
    {
        DAL_LoaiHang dalLH = new DAL_LoaiHang();

        public DataTable getLoaiHang()
        {
            return dalLH.getLoaiHang();   
        }
        public DataTable timLoaiHang(string tenloai)
        {
            return dalLH.timLoaiHang(tenloai);
        }
        public int themLoaiHang(DTO_LoaiHang lh)
        {
            return dalLH.themLoaiHang(lh);
        }

        public int xoaLoaiHang(string maloai)
        {
            return dalLH.xoaLoaiHang(maloai);
        }

        public int suaLoaiHang(DTO_LoaiHang lh)
        {
            return dalLH.suaLoaiHang(lh);
        }
    }
}

