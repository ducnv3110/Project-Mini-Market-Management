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
    public class BUS_NhanVien
    {
        DAL_NhanVien dalNV = new DAL_NhanVien();
        
        public DataTable getNhanVien()
        {
            return dalNV.getNhanVien();
        }
        public DataTable timNhanVien(string tennv)
        {
            return dalNV.timNhanVien(tennv);
        }
        public List<DTO_NhanVien> getListNV()
        {
            return dalNV.getListNV();
        }
        public int themNhanVien(DTO_NhanVien nv)
        {
            return dalNV.themNhanVien(nv);
        }

        public int suaNhanVien(DTO_NhanVien nv)
        {
            return dalNV.suaNhanVien(nv);
        }

        public int xoaNhanVien(string manv)
        {
            return dalNV.xoaNhanVien(manv);
        }
    }
}
