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
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dalLg = new DAL_TaiKhoan();

        public DataTable getLogin()
        {
            return dalLg.getLogin();
        }
        public DataTable timLogin(string tennv)
        {
            return dalLg.timLogin(tennv);
        }
        public int themLogin(DTO_TaiKhoan l)
        {
            return dalLg.themLogin(l);
        }

        public int suaLogin(DTO_TaiKhoan l)
        {
            return dalLg.suaLogin(l);
        }

        public int xoaLogin(string id)
        {
            return dalLg.xoaLogin(id);
        }
    }
}
