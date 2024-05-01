using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyBachHoa;
using System.Data;
using DTO_QuanLyBachHoa;
using System.Collections.ObjectModel;

namespace BUS_QuanLyBachHoa
{
    public class BUS_ChucVu
    {
        DAL_ChucVu dalCV = new DAL_ChucVu();

        public DataTable getChucVu()
        {
            return dalCV.getChucVu();
        }
        public DataTable timChucVu(string tencv)
        {
            return dalCV.timChucVu(tencv);
        }
        public int themChucVu(DTO_ChucVu cv)
        {
            return dalCV.themChucVu(cv);
        }
        public bool kiemTraTrungMa(string ma)
        {
            return dalCV.kiemTraTrungMa(ma);
        }
        public int suaChucVu(DTO_ChucVu cv)
        {
            return dalCV.suaChucVu(cv);
        }

        public int xoaChucVu(string macv)
        {
            return dalCV.xoaChucVu(macv);
        }
        public ObservableCollection<DTO_ChucVu> GetAllDataChucVu()
        {
            return dalCV.TestGetAll();
        }
    }
}
