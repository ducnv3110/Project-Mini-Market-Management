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
    public class BUS_NhaCungCap
    {
        DAL_NhaCungCap dalNhaCC = new DAL_NhaCungCap();

        public DataTable getNhaCungCap()
        {
            return dalNhaCC.getNhaCungCap();
        }
        public DataTable timNhaCungCap(string tennhacc)
        {
            return dalNhaCC.timNhaCungCap(tennhacc);
        }
        public int themNhaCungCap(DTO_NhaCungCap nhacc)
        {
            return dalNhaCC.themNhaCungCap(nhacc);
        }
        public bool kiemTraTrungMa(string ma)
        {
            return dalNhaCC.kiemTraTrungMa(ma);
        }
        public int suaNhaCungCap(DTO_NhaCungCap nhacc)
        {
            return dalNhaCC.suaNhaCungCap(nhacc);
        }

        public int xoaNhaCungCap(string manhacc)
        {
            return dalNhaCC.xoaNhaCungCap(manhacc);
        }
    }
}
